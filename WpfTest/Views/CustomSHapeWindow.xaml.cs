using Microsoft.Win32;
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
    /// CustomSHapeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CustomShapeWindow : Window
    {
        public CustomShapeWindow()
        {
            InitializeComponent();
            SetWindowSizeAndPosition();
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            SetWindowSizeAndPosition();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void SetWindowSizeAndPosition()
        {
            double primaryScreenHeight = SystemParameters.WorkArea.Height;
            this.Height = primaryScreenHeight - 40;
            this.Width = this.Height * 56 / 566;
            this.Top = 20;
            this.Left = SystemParameters.WorkArea.Width - this.Width;
        }
    }
}
