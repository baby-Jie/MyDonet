using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfTest.CommanTools;
using WpfTest.Views;

namespace WpfTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        

        #region Instance Fields
        #endregion

        #region Private Members
        #endregion

        #region Constants
        #endregion

        #region Events
        #endregion

        #region Event Handlers

        /// <summary>
        /// Application.DoEvents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestDoEventsButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                TestDoEventsLabel.Content = i.ToString();

                //Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                //                           new Action(delegate { }));

            }
        }

        /// <summary>
        /// Dependency Property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestDependencyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(sizeof(char).ToString());
          
           // MessageBox.Show(System.Runtime.InteropServices.Marshal.SizeOf(testButton).ToString());
        }

        private void TestDispatcherButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(()=> 
            {
                TestDoEventsLabel.Dispatcher.BeginInvoke((Action)(()=> 
                {
                    for (int i = 0;  i < 10; i++)
                    {
                        Console.WriteLine("hello");
                    }
                    TestDoEventsLabel.Content = "hello this dispatcher";
                }));
                Console.WriteLine("dispatcher end");
            });
        }




        #endregion

        #region Public Class Members
        #endregion

        #region Public Properties
        #endregion

        #region Public Members
        #endregion

        #region Public Constructors

        public MainWindow()
        {
            InitializeComponent();
            //if (!this._contentLoaded)
            //{
            //    this._contentLoaded = true;
            //    Uri resourceLocater = new Uri("/WpfTest;component/mainwindow.xaml", UriKind.Relative);
            //    Application.LoadComponent(this, resourceLocater);
            //}

        }





        #endregion

        #region Overridden Methods
        #endregion

        private void TestLogButton_Click(object sender, RoutedEventArgs e)
        {
            LogWriter.Instance.ActionLogger.Debug("this is a test about log");
           
        }

        private void PackUrlButton_Click(object sender, RoutedEventArgs e)
        {
            PackUrl win = new PackUrl();
            win.Show();
        }

        private void ListBoxPaging_Click(object sender, RoutedEventArgs e)
        {
            ListBoxPaging win = new ListBoxPaging();
            win.Show();
        }

        private void BitmapLeakButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapSourceLeak win = new BitmapSourceLeak();
            win.Show();
        }

        private MessageLoop _messageLoopWin;
        private void MessageLoopButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageLoop win= new MessageLoop();
            _messageLoopWin = win;
            win.Show();
        }

        private void SendMessageButton_OnClick(object sender, RoutedEventArgs e)
        {
            string intPtrStr = SendHandleTextBox.Text.Trim();
            int ptrInt = Convert.ToInt32(intPtrStr, 16);
            IntPtr ptr = new IntPtr(ptrInt);
            WindowInteropHelper interopHelper = new WindowInteropHelper(_messageLoopWin);
            SendMessage(interopHelper.Handle, WM_SENDTEST, IntPtr.Zero, "test send message");
        }

        public const int WM_SENDTEST = 1234;

        //声明:
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);

        private void WindowStyleButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowStyleWin win = new WindowStyleWin();
            win.Show();
        }

        private void CustomControlButton_OnClick(object sender, RoutedEventArgs e)
        {
            CustomControl win = new CustomControl();
            win.Show();
        }

        private void FlipPanelButton_OnClick(object sender, RoutedEventArgs e)
        {
            TestFlipPanel win = new TestFlipPanel();
            win.Show();
        }

        private void ApplyTemplateButton_OnClick(object sender, RoutedEventArgs e)
        {
            ApplyTemplate win= new ApplyTemplate();
            win.Show();
        }

        private void TestFlipPanelButton_OnClick(object sender, RoutedEventArgs e)
        {
            TestPanel win = new TestPanel();
            win.Show();
        }

        private void TestVisualStateButton_OnClick(object sender, RoutedEventArgs e)
        {
            VisualStateWin win = new VisualStateWin();
            win.Show();
        }

        private void NotesButton_OnClick(object sender, RoutedEventArgs e)
        {
            Notes win = new Notes();
            win.Show();
        }

        private void PopupWinButton_Click(object sender, RoutedEventArgs e)
        {
            PopUpWin win = new PopUpWin();
            win.Owner = this;
            win.Show();
        }

        private void DesignDataBindButton_OnClick(object sender, RoutedEventArgs e)
        {
            DesignDataBindWin win = new DesignDataBindWin();
            win.Show();
        }

        private void ListBoxSelectionChangedButton_OnClick(object sender, RoutedEventArgs e)
        {
            ListBoxSelectionChanged win = new ListBoxSelectionChanged();
            win.Show();
        }

        private void MenuWinButton_OnClick(object sender, RoutedEventArgs e)
        {
            MenuWin win = new MenuWin();
            win.Show();
        }

        private void ColorWinButton_OnClick(object sender, RoutedEventArgs e)
        {
            ColorWin win = new ColorWin();
            win.Show();
        }

        private void CliTestButton_Click(object sender, RoutedEventArgs e)
        {
            CliTest win = new CliTest();
            win.Show();
        }

        private void ScreenCaptureBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ScreenCapture win = new ScreenCapture();
            win.Show();
        }

        private void TimerTestBgtn_OnClick(object sender, RoutedEventArgs e)
        {
            TimerTest win = new TimerTest();
            win.Show();
        }

        private void ThumbTestWinBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ThumbTestWin win = new ThumbTestWin();
            win.Show();
        }

        private void HotKeyTestBtn_OnClick(object sender, RoutedEventArgs e)
        {
            HotKeyRegisterWin win = new HotKeyRegisterWin();
            win.Show();
        }

        private void WindowChromeExampleBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowChromeExample win = new WindowChromeExample();
            win.Show();
        }

        private void CustomShapeWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomShapeWindow win = new CustomShapeWindow();
            win.Show();
        }

        private void DpiTestBtn_Click(object sender, RoutedEventArgs e)
        {
            DpiTest win = new DpiTest();
            win.Show();
        }

        private void PathDataSvgTestBtn_Click(object sender, RoutedEventArgs e)
        {
            PathDataSvgTest win = new PathDataSvgTest();
            win.Show();
        }
    }
}
