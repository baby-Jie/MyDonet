using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Image = System.Drawing.Image;
using Path = System.IO.Path;

namespace WpfTest.Views
{
    /// <summary>
    /// Interaction logic for BitmapSourceLeak.xaml
    /// </summary>
    public partial class BitmapSourceLeak : Window
    {
        public BitmapSourceLeak()
        {
            InitializeComponent();
        }

        private void BitmapSourceLeakButton_Click(object sender, RoutedEventArgs e)
        {
            //TestBitmapSourceLeak(); // 测试BitmapSource会不会占内存，怎么去清理它
            //NewBitmapImage();
            NewHistoryItemInfo();
        }

        private void NewBitmapImage()
        {
            for (int i = 0; i < 10000; i++)
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri("/Images/LocalLove.png", UriKind.Relative));
                TestImage.Source = bitmapImage;
            }
        }

        private void NewHistoryItemInfo()
        {
            for (int i = 0; i < 100; i++)
            {
                HistoryItemInfo item = new HistoryItemInfo();
                string appPath = Directory.GetCurrentDirectory();
                string imagePath = Path.Combine(appPath, "Images/LocalLove.png");
                item.ThumbImage = Image.FromFile(imagePath);
                item.BitmapImage = new BitmapImage(new Uri("/Images/LocalLove.png", UriKind.Relative));
                item.ThumbImage.Dispose();
            }
        }

        private void TestBitmapSourceLeak()
        {
            for (int i = 0; i < 100; i++)
            {
                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1000, 1000))
                {
                    var bitmapImage = BitmapToBitmapImage(bmp);
                    //IntPtr hBitmap = bmp.GetHbitmap();
                    //var handle = new SafeHBitmapHandle(hBitmap, true);
                    //using (handle)
                    //{
                    //    var source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(handle.DangerousGetHandle(), IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                    //   // source = null;
                    //    GC.Collect();
                    //}


                    //try
                    //{
                    //    var source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                    //    source = null;
                    //    GC.Collect();
                    //}
                    //finally
                    //{
                    //    DeleteObject(hBitmap);
                    //}
                }
            }

        }


        private BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap bitmap)
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                bitmap.Save(ms, bitmap.RawFormat);
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }
            return bitmapImage;
        }
    }


    public class SafeHBitmapHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        [SecurityCritical]
        public SafeHBitmapHandle(IntPtr preexistingHandle, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(preexistingHandle);
        }

        protected override bool ReleaseHandle()
        {
            return GdiNative.DeleteObject(handle);
        }
    }


    public class GdiNative
    {
        // at class level
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
    }

    public class HistoryItemInfo
    {

        public Image ThumbImage
        {
            get; set;
        }

        public BitmapImage BitmapImage { get; set; }
    }

}
