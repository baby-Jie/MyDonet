using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CommonToolLib.CommanTools;

namespace WpfTest.Views
{
    /// <summary>
    /// Interaction logic for WindowStyle.xaml
    /// </summary>
    public partial class WindowStyleWin : Window
    {
        public WindowStyleWin()
        {
            InitializeComponent();
        }

        private void GetHandleButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowInteropHelper interopHelper = new WindowInteropHelper(this);
            string stringFormat = string.Format("The handle of this window is:{0}", interopHelper.Handle.ToString("X"));
            MessageBox.Show(stringFormat);

        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            this.HideMinimizeBox();
            this.HideMaximizeBox();
            base.OnSourceInitialized(e);
        }

        private void GetScreenInfoButton_Click(object sender, RoutedEventArgs e)
        {
            //SystemParameters.scre
            int num = System.Windows.Forms.Screen.AllScreens.Count();
            //MessageBox.Show($"screen number:{num}");
            for (int i = 0; i < num; i++)
            {
                System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.AllScreens[i];
                string message = $"screen bounds:{screen.Bounds}\nIsPrimaryScreen:{screen.Primary}\nscreen workarea:{screen.WorkingArea}\ndevice name:{screen.DeviceName}";
                MessageBox.Show(message);
            }
        }
    }
}
