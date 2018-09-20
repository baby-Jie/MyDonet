using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfTest.Views
{
    /// <summary>
    /// ScreenCapture.xaml 的交互逻辑
    /// </summary>
    public partial class ScreenCapture : Window
    {
        public ScreenCapture()
        {
            InitializeComponent();
        }

        private void GetFullScreenImageBtn_OnClick(object sender, RoutedEventArgs e)
        {
            System.Drawing.Rectangle rectangle = SystemInformation.VirtualScreen;
            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            using (Graphics gra = Graphics.FromImage(bitmap))
            {
                gra.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, rectangle.Size, CopyPixelOperation.SourceCopy);
            }
            bitmap.Save("screencaputrue.png", ImageFormat.Png);
        }
    }
}
