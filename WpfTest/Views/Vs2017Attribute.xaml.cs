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

namespace WpfTest.Views
{
    /// <summary>
    /// Vs2017Attribute.xaml 的交互逻辑
    /// </summary>
    public partial class Vs2017Attribute : Window
    {
        public Vs2017Attribute()
        {
            InitializeComponent();
        }




        public int MyProperty { get; set; } = 999;


        private void OutFunction(out int a)
        {
            a = 999;
        }

        private void OutButton_OnClick(object sender, RoutedEventArgs e)
        {
            OutFunction(out int testa);
            MessageBox.Show(testa.ToString());
        }

        private void OutTryParseButton_OnClick(object sender, RoutedEventArgs e)
        {
            int a = 999;
            object obj = a;
            if (int.TryParse(obj.ToString(), out int testa))
            {
                MessageBox.Show(testa.ToString());
            }

        }

        private double sum = 0;

        private void SwitchAttribute(object obj)
        {
            
            switch (obj)
            {
                case int a:
                    sum += a;
                    break;
                case double b:
                    sum = sum + 2 * b;
                    break;
            }
        }
    }
}
