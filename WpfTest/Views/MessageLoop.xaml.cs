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

namespace WpfTest.Views
{
    /// <summary>
    /// Interaction logic for MessageLoop.xaml
    /// </summary>
    public partial class MessageLoop : Window
    {
        public MessageLoop()
        {
            InitializeComponent();
        }

        private IntPtr MessageHook(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            if (msg == MainWindow.WM_SENDTEST)
            {
                MessageBox.Show("send successfully");
            }

            return IntPtr.Zero;
        }

        private void MessageLoop_OnLoaded(object sender, RoutedEventArgs e)
        {
            WindowInteropHelper interopHelper = new WindowInteropHelper(this);
            HwndSource hwndSource = HwndSource.FromHwnd(interopHelper.Handle);
            if (hwndSource != null)
                hwndSource.AddHook(MessageHook);
        }
    }
}
