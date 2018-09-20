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
using SharedResources.Controls;

namespace WpfTest.Views
{
    /// <summary>
    /// Interaction logic for VisualStateWin.xaml
    /// </summary>
    public partial class VisualStateWin : Window
    {
        public VisualStateWin()
        {
            InitializeComponent();
        }

        private void ChangedChineseButton_Click(object sender, RoutedEventArgs e)
        {
            SubjectPanel.ChangeVisualState(ContentType.Chinese);
        }

        private void ChangedMathButton_Click(object sender, RoutedEventArgs e)
        {
            SubjectPanel.ChangeVisualState(ContentType.Math);
        }

        private void ChangedEnglishButton_OnClick(object sender, RoutedEventArgs e)
        {
            SubjectPanel.ChangeVisualState(ContentType.English);
        }
    }
}
