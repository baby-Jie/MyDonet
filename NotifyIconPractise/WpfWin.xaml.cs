
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Windows.Threading;

namespace NotifyIconPractise
{
    /// <summary>
    /// WpfWin.xaml 的交互逻辑
    /// </summary>
    public partial class WpfWin : Window
    {
       

        public WpfWin()
        {
            InitializeComponent();
        }

        private void TestDoEventsButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                TestDoEventsLabel.Content = i.ToString();
                // System.Windows.Forms.Application.DoEvents();
                // 不能混搭
                //Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                //                           new Action(delegate { }));


            }
        }

    }
}
