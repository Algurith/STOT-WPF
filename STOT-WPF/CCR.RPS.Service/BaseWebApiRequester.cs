using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace CCR.RPS.Service
{
    public class BaseWebApiRequester
    {
        private readonly HttpClient _httpClient = HttpClientFactory.HttpClientFactory.GetClient(300);

        private readonly string ApiFlag = "api";
        private readonly string RpsWebApiHost = ConfigurationManager.AppSettings["RpsWebApiHost"];

        /// <summary>
        /// 合并url
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="actionName"></param>
        /// <returns></returns>
        public string CombineApiUrl(string controllerName, string actionName)
        {
            return $"{RpsWebApiHost}/{ApiFlag}/{controllerName}/{actionName}";
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <param name="httpMethod"></param>
        /// <returns></returns>
        protected T Request<T>(string url, object content, HttpMethod httpMethod) where T : class, new()
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            try
            {
                var json = JsonConvert.SerializeObject(content);

                var httpRequestMessage = new HttpRequestMessage(httpMethod, url)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
                httpRequestMessage.Headers.Add("Accept", "application/json");

                var result = _httpClient.SendAsync(httpRequestMessage).Result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
