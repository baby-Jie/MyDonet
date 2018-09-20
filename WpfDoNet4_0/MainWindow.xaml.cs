using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Color = System.Drawing.Color;

namespace WpfDoNet4_0
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            //System.Drawing.Color color = ConvertHex2Color("#00010000");
            //string colorString = ConvertColor2Hex(color);
            //MessageBox.Show(colorString);


            string str = "Test2";
            TestEnum test = (TestEnum)Enum.Parse(typeof(TestEnum), str);
            //MessageBox.Show(test.ToString());
            int? tt = null;
            MessageBox.Show(tt.ToString());
        }

        public static string ConvertColor2Hex(Color argcolor)
        {
            string ret = Convert.ToString(argcolor.ToArgb(), 16);
            int len = ret.Length;
            for (int i = 0; i < 8 - len; i++)
            {
                ret = "0" + ret;
            }
            return "#" + ret;
        }

        public static Color ConvertHex2Color(string hexColor)
        {
            return ColorTranslator.FromHtml(hexColor);
        }

        public enum  TestEnum
        {
            Test1,
            Test2
        }
    }
}
