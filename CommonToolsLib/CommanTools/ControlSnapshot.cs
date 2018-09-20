using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonToolLib.CommanTools
{
    public class ControlSnapshot
    {

        public static Bitmap Snapshot(IntPtr hwnd, Rectangle rect)
        {
            int width = 0, height = 0;
            int left = 0, top = 0;
            IntPtr dc = IntPtr.Zero;
            dc = WindowApiHelper.GetDC(hwnd);
            left = rect.Left;
            top = rect.Top;
            width = rect.Width;
            height = rect.Height;

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            if (dc != IntPtr.Zero)
            {
                try
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        IntPtr bdc = g.GetHdc();

                        try
                        {
                            WindowApiHelper.BitBlt(bdc, 0, 0, width, height, dc, left, top, TernaryRasterOperations.SRCCOPY);
                        }
                        catch (Exception)
                        {

                        }
                        finally
                        {
                            g.ReleaseHdc(bdc);
                        }
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    WindowApiHelper.ReleaseDC(hwnd, dc);
                }
            }
            return bmp;
        }
    }
}
