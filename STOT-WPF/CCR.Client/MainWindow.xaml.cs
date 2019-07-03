using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFMediaKit.DirectShow.Controls;

namespace CCR.Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitControlEvent();
        }

        private void InitControlEvent()
        {
            Loaded += MainWindow_Loaded;
            cbCamera.SelectionChanged += CbCamera_SelectionChanged;
            btnCapture.Click += BtnCapture_Click;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var lstCamera = MultimediaUtil.VideoInputNames;
            cbCamera.ItemsSource = lstCamera;

            if (lstCamera.Length <= 0)
                MessageBox.Show("电脑没有安装任何摄像头");
        }

        private void CbCamera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mdVideo.VideoCaptureSource = (string)cbCamera.SelectedItem;
        }

        private void BtnCapture_Click(object sender, RoutedEventArgs e)
        {
            ////抓取控件做成图片
            //RenderTargetBitmap bmp = new RenderTargetBitmap(
            //    (int)mdVideo.ActualWidth, (int)mdVideo.ActualHeight,
            //    96, 96, PixelFormats.Default);
            //bmp.Render(mdVideo);
            //BitmapEncoder encoder = new JpegBitmapEncoder();
            //encoder.Frames.Add(BitmapFrame.Create(bmp));
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    encoder.Save(ms);
            //    byte[] captureData = ms.ToArray();
            //    //保存图片
            //    File.WriteAllBytes("d:/1.jpg", captureData);
            //}
            //mdVideo.Pause();

            var img = new Image
            {
                Width = 80,
                Height = 80
            };
            //模拟
            FileStream fileStream = new FileStream(@"C:\Users\aa\Pictures\Saved Pictures\cattle.png", FileMode.Open, FileAccess.Read);
            byte[] desBytes = new byte[fileStream.Length];
            fileStream.Read(desBytes, 0, desBytes.Length);
            fileStream.Close();

            MemoryStream stream = new MemoryStream(desBytes);
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();//初始化
            bmp.StreamSource = stream;//设置源
            bmp.EndInit();//初始化结束

            img.Source = bmp;
            imgSource.Children.Add(img);
        }
    }
}
