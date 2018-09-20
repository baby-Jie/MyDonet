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
    /// MenuWin.xaml 的交互逻辑
    /// </summary>
    public partial class MenuWin : Window
    {
        public MenuWin()
        {
            InitializeComponent();
        }

        private void Item1_OnClick(object sender, RoutedEventArgs e)
        {
            Border border = (Border)Item1.Template.FindName("templateRoot", Item1);
            if (border != null)
            {
                border.Background = new SolidColorBrush(Colors.Bisque);
            }
        }
    }
}
