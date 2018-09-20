using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// PopUp.xaml 的交互逻辑
    /// </summary>
    public partial class PopUpWin : Window
    {
        public PopUpWin()
        {
            InitializeComponent();
        }

        private void PopButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PopUpTest");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //PopUpTest.IsOpen = false;
            //PopUpTest.IsOpen = true;
            HwndSource hwndSource = (HwndSource)HwndSource.FromVisual(PopUpTest.Child);
            WindowInteropHelper interopHelper = new WindowInteropHelper(this);
            Int32 handlerOwner = interopHelper.Handle.ToInt32();
            Int32 handler = hwndSource.Handle.ToInt32();
            Console.WriteLine($"PopUpTest.Handle:{handler}, handlerOwner:{handlerOwner}");
        }

        private void TestListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            if (!PopUpTest.IsOpen)
            {
                return;
            }
            //解决Popup随Window移动
            var methodInfo = typeof(Popup).GetMethod("UpdatePosition", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            methodInfo.Invoke(PopUpTest, null);
        }

        private void PopUpTest_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Activate();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            
        }
    }
}
