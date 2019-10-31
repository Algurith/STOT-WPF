using System;
using System.Collections.Concurrent;
using System.Net.Http;

namespace HttpClientFactory
{
    public class HttpClientFactory
    {
        private static readonly ConcurrentDictionary<string, HttpClient> HttpClients =
            new ConcurrentDictionary<string, HttpClient>();

        public static HttpClient GetClient(TimeSpan timeOut, string baseAddress = "")
        {
            baseAddress = baseAddress?.Trim() ?? "";
            var key = $"{baseAddress}|{timeOut}";
            return HttpClients.GetOrAdd(key, new HttpClient
            {
                BaseAddress = new Uri(baseAddress),
                Timeout = timeOut
            });
        }

        public static HttpClient GetClient(int timeOut, string baseAddress = "")
        {
            return GetClient(new TimeSpan(timeOut), baseAddress);
        }
    }
}
