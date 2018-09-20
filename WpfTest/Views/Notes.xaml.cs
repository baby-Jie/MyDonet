using System;
using System.Collections.Generic;
using System.IO;
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
    /// Notes.xaml 的交互逻辑
    /// </summary>
    public partial class Notes : Window
    {
        public Notes()
        {
            InitializeComponent();
        }

        private void EnumButton_OnClick(object sender, RoutedEventArgs e)
        {
            string str = string.Format($"Enum.GetValues(typeof(TestEnum).Length)):{Enum.GetValues(typeof(TestEnum)).Length}\n" +
                                       $"Enum.GetNames(typeof(TestEnum).Length):{Enum.GetNames(typeof(TestEnum)).Length}");
            MessageBox.Show(str);
        }

        private void StaticTestBtn_Click(object sender, RoutedEventArgs e)
        {
            TestBinding.Str = "234";
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GetDrivesInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            String[] drives = Environment.GetLogicalDrives();
            string driveInfo = string.Join(",", drives);

            string message = $"drives list:{driveInfo}\n";

            DriveInfo[] allDirves = DriveInfo.GetDrives();

            var DriveInfos = from driveinfo in allDirves where driveinfo.DriveType == DriveType.Fixed select driveinfo;
            DriveInfos = DriveInfos.OrderByDescending(new Func<DriveInfo, long>(CompareDriveSize));


            var driveinfo2 = DriveInfos.ElementAtOrDefault(0);
            Console.WriteLine(driveinfo2.TotalFreeSpace);

            foreach (DriveInfo item in allDirves)
            {
                Console.Write(item.Name + "---" + item.DriveType);
                if (item.IsReady)
                {
                    Console.Write(",容量：" + item.TotalSize + "，可用空间大小：" + item.TotalFreeSpace);
                }
                else
                {
                    Console.Write("没有就绪");
                }
                Console.WriteLine();
            }


            MessageBox.Show(message);
        }

        private long CompareDriveSize(DriveInfo driveInfo)
        {
            return driveInfo.TotalFreeSpace;
        }
    }


    public enum TestEnum
    {
        Test1,
        Test2
    }

    public class TestBinding
    {
        public static string Str = "123";
    }
}
