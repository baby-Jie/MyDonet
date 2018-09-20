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
using WpfTest.Models;

namespace WpfTest.Views
{
    /// <summary>
    /// DesignDataBindWin.xaml 的交互逻辑
    /// </summary>
    public partial class DesignDataBindWin : Window
    {
        public DesignDataBindWin()
        {
            InitializeComponent();
            this.DataContext = new Student() {Id = 222, Name = "xyj", Score = 999};
        }
    }

    public class StudentCollection : List<Student>
    {
        public StudentCollection()
        {

        }
    }
}
