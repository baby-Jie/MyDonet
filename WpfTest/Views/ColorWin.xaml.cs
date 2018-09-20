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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CommonToolLib.CommanTools;
using Color = System.Drawing.Color;

namespace WpfTest.Views
{
    /// <summary>
    /// ColorWin.xaml 的交互逻辑
    /// </summary>
    public partial class ColorWin : Window
    {
        private int m_inject_id = 1;
        public ColorWin()
        {
            InitializeComponent();
        }

        private void ColorToStringButton_OnClick(object sender, RoutedEventArgs e)
        {
            System.Drawing.Color color = Color.FromName("#00110000");

            string colorString = System.Drawing.ColorTranslator.ToHtml(color);

            MessageBox.Show(colorString);
        }

        private void NulableButton_OnClick(object sender, RoutedEventArgs e)
        {
            //其实 int? 是个结构体
            //public struct Nullable<T> where T : struct
            //private bool hasValue;
            //internal T value;
            int? tt = 1;
            MessageBox.Show(typeof(int?).ToString());

            TestStruct test = new TestStruct(2);

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            int num = 1;
            int num1 = num;
            CDeclFun(num++, num);

            CDeclFun(num1, num1++);
        }

        private void CDeclFun(int a, int b)
        {
            Console.WriteLine($"a:{a}, b:{b}");
        }

        private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
            object a = null;

            this.Dispatcher.BeginInvoke((Action)(() =>
            {
                MessageBox.Show("b");
            }));

            MessageBox.Show("a");
            System.Threading.Thread.Sleep(5000);
            Test1 test = new Test1();
            TestEnum2 enum1 = TestEnum2.Test1;
            switch (enum1)
            {
                case TestEnum2.Test1:
                    break;
                case TestEnum2.Test2:
                    break;
                case TestEnum2.Test3:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void DllInjectTestButton_OnClick(object sender, RoutedEventArgs e)
        {
            //this.HideMinimizeBox();
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            unsafe
            {
                fixed (int* p = &m_inject_id)
                {
                    string message = $"value:{*p}, address:{((int)p).ToString("X")}, HandlesScrolling:{hwnd.ToString("X")}";
                    MessageBox.Show(message);
                }
                
            }
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            
        }
    }

    public struct TestStruct
    {
        internal int value;

        public TestStruct(int value)
        {
            this.value = value;
        }

    }

    public class Test1
    {
        private int a;

        public  int b { get; set; }

    }

    public class Test2 : Test1
    {

    }

     enum TestEnum2
    {
        Test1,
        Test2,
        Test3
    }
}
