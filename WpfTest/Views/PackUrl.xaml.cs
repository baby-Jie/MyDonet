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
    /// Interaction logic for PackUrl.xaml
    /// </summary>
    public partial class PackUrl : Window
    {
        public PackUrl()
        {
            InitializeComponent();
        }

        private void SetImageSourceButton_Click(object sender, RoutedEventArgs e)
        {
            string packUrl = "pack://application:,,,/SharedResources;component/Resources/Images/Love.png";
            Uri url = new Uri(packUrl);
            DynamicPack.Source = new BitmapImage(url);
        }
    }
}
