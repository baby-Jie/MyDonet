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
    /// FullScreenWin.xaml 的交互逻辑
    /// </summary>
    public partial class FullScreenWin : Window
    {
        public FullScreenWin()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
            string message = GetSizeMessage();
            message += GetWindowState();
            MessageBox.Show(message);
            Console.WriteLine(message);
        }

        private string GetSizeMessage()
        {
            string windowSize = $"this.Width:{this.Width}, this.height:{this.Height}, this.ActualWidth:{this.ActualWidth}, this.ActualHeight:{this.ActualHeight}\n";

            string gridSize = $"MainGrid.ActualWidth{MainGrid.ActualWidth}, MainGrid.ActualHeight:{MainGrid.ActualHeight}\n";

            string screenSize =
                $"PrimaryScreenWidth:{SystemParameters.PrimaryScreenWidth}, PrimaryScreenHeight:{SystemParameters.PrimaryScreenHeight}" +
                $", VirtualScreenWidth:{SystemParameters.VirtualScreenWidth}, VirtualScreenHeight:{SystemParameters.VirtualScreenHeight}\n";

            return windowSize + gridSize + screenSize;
        }

        private string GetWindowState()
        {
            return  "Windowstate" + this.WindowState + "\n";
        }
    }
}
