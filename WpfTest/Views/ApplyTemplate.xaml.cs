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
    /// Interaction logic for ApplyTemplate.xaml
    /// </summary>
    public partial class ApplyTemplate : Window
    {
        public ApplyTemplate()
        {
            InitializeComponent();
        }

        private void ButtonLabel_OnButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("hello");
        }
    }
}
