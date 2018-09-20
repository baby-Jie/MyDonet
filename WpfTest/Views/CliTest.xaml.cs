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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClrTestDll;

namespace WpfTest.Views
{
    /// <summary>
    /// CliTest.xaml 的交互逻辑
    /// </summary>
    public partial class CliTest : Window
    {
        public CliTest()
        {
            InitializeComponent();
        }

        private void CliTest_Click(object sender, RoutedEventArgs e)
        {
            ClrTestDll.Calculator calculator = new Calculator();
            int ret = calculator.add(1, 2);
            MessageBox.Show(ret.ToString());
        }
    }
}
