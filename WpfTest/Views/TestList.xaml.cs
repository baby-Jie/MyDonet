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
    /// TestList.xaml 的交互逻辑
    /// </summary>
    public partial class TestList : Window
    {
        private List<int> _lstInts = new List<int>();
        public TestList()
        {
            InitializeComponent();
            
        }

        private int addItem = 0;

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_lstInts.Capacity.ToString());
        }


        private void AddOneButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddOne();
        }

        private void AddOne()
        {
            _lstInts.Add(addItem++);
        }

        private void AddTenButton_OnClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                AddOne();
            }
        }

        private void AddNumButton_OnClick(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(this.NumberTextBox.Text);
            for (int i = 0; i < num; i++)
            {
                AddOne();
            }
        }

        private void GetCountButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_lstInts.Count.ToString());

        }

        private void GetListAddressButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(GetMemory(_lstInts[0]));
        }

        private string GetMemory(object obj)
        {
            System.Runtime.InteropServices.GCHandle h = System.Runtime.InteropServices.GCHandle.Alloc(obj, System.Runtime.InteropServices.GCHandleType.Pinned);
            IntPtr addr = h.AddrOfPinnedObject();
            return addr.ToString("X");
        }

        private void ChangeFirstValueButton_Click(object sender, RoutedEventArgs e)
        {
            _lstInts[0]++;
            MessageBox.Show(_lstInts[0].ToString());
        }

        private void InsertItemButton_Click(object sender, RoutedEventArgs e)
        {
            _lstInts.Insert(1, 0x99);
        }
    }
}
