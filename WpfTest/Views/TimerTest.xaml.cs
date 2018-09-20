using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ThreadTimer = System.Threading.Timer;
using TimerTimer = System.Timers.Timer;
using DispatcherTimer = System.Windows.Threading.DispatcherTimer;
namespace WpfTest.Views
{
    /// <summary>
    /// TimerTest.xaml 的交互逻辑
    /// </summary>
    public partial class TimerTest : Window
    {
        //System.Threading.Timer
        //public Timer(TimerCallback callback, object state, int dueTime, int period);
        //callback委托将会在period时间间隔内重复执行，state参数可以传入想在callback委托中处理的对象，dueTime标识多久后callback开始执行，period标识多久执行一次callback。
        //Timer回掉方法执行是在另外ThreadPool中一条新线程中执行的。
        private ThreadTimer threadTimer;

        private TimerTimer timer;

        private DispatcherTimer dispatcherTimer;

        private int threadTimerCount = 0;

        private int timerCount = 0;

        private int dispatcherCount = 0;
            

        public TimerTest()
        {
            InitializeComponent();
            Console.WriteLine("Main Action.");
            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId}");

            timer = new TimerTimer(1000);
            timer.Elapsed += (sender, args) =>
            {
                if (!this.CheckAccess())
                {
                    TimerTimerBtn.Dispatcher.Invoke((Action)(() => { TimerTimerBtn.Content = timerCount++; }));
                }
                Console.WriteLine($"Timer Thread: {Thread.CurrentThread.ManagedThreadId}");

                Console.WriteLine($"Is Thread Pool: {Thread.CurrentThread.IsThreadPoolThread}");

                Console.WriteLine("Timer Action.");
            };

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0,0,0,1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            DisPatcherTimerBtn.Content = dispatcherCount++;

            Console.WriteLine($"Timer Thread: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine($"Is Thread Pool: {Thread.CurrentThread.IsThreadPoolThread}");

            Console.WriteLine("Timer Action.");
        }

        private void ThreadTimerBtn_OnClick(object sender, RoutedEventArgs e)
        {
            threadTimer = new ThreadTimer(delegate
                {
                    if (!this.CheckAccess())
                    {
                        ThreadTimerBtn.Dispatcher.Invoke((Action)(() => { ThreadTimerBtn.Content = threadTimerCount++; }));
                    }
                    Console.WriteLine($"Timer Thread: {Thread.CurrentThread.ManagedThreadId}");

                    Console.WriteLine($"Is Thread Pool: {Thread.CurrentThread.IsThreadPoolThread}");

                    Console.WriteLine("Timer Action.");
                },
                null,
                10000,
                1000);

        }


        private void ThreadTimerCallBack(object state)
        {

        }

        private void TimerTimerBtn_OnClick(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void DisPatcherTimerBtn_OnClick(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }
    }
}
