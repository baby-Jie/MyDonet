using System;
using System.Drawing;
using System.Windows;


namespace WpfTest.Views
{
    /// <summary>
    /// DpiTest.xaml 的交互逻辑
    /// </summary>
    public partial class DpiTest : Window
    {
        float _dpiX = 96f;
        float _dpiY = 96f;

        public DpiTest()
        {
            InitializeComponent();
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                _dpiX = graphics.DpiX;
                _dpiY = graphics.DpiY;
            }
        }

        private void GetPrimaryScreenBoundsBtn_Click(object sender, RoutedEventArgs e)
        {
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double screenWidth = SystemParameters.PrimaryScreenWidth;

            string message = string.Format($"width:{screenWidth}, height:{screenHeight}");
            MessageBox.Show(message);
            //string bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds.ToString();
            //MessageBox.Show("bounds:" + bounds);
        }

        private void GetWindowSizeBtn_Click(object sender, RoutedEventArgs e)
        {
            string size = string.Format($"width:{this.Width} height:{this.Height}");
            MessageBox.Show(size);
        }

        private void GetDpiBtn_Click(object sender, RoutedEventArgs e)
        {
            string message = $"dpiX:{_dpiX}, dpiY:{_dpiY}";
            MessageBox.Show(message);
        }
    }
}
