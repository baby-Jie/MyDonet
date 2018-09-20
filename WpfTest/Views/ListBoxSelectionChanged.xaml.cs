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
    /// ListBoxSelectionChanged.xaml 的交互逻辑
    /// </summary>
    public partial class ListBoxSelectionChanged : Window
    {
        List<string> strList = new List<string>();
        public ListBoxSelectionChanged()
        {
            InitializeComponent();
            strList.Add("111");
            strList.Add("222");
            strList.Add("333");
            TestListBox.ItemsSource = strList;
        }

        private void TestMyListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ListBox_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item =
                ItemsControl.ContainerFromElement(TestListBox, e.OriginalSource as DependencyObject) as ListBoxItem;

            if (item != null && item.IsSelected)
            {
                TestListBox.SelectedIndex = -1;
                e.Handled = true;
            }
        }
    }
}
