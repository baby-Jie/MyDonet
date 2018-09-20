using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace WpfApp1
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


        private void StartRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ZDSoft.SDK.ScnLib_IsRecording())
            {
                MessageBox.Show("is already recoding");
                return;
            }

            bool success = false;
            //bool success = ZDSoft.SDK.ScnLib_Initialize();
            //if (!success)
            //{
            //    MessageBox.Show("Initialize error");
            //    return;
            //}
            //ZDSoft.SDK.ScnLib_SetCaptureRegion(0, 0, 1920, 1080);
            int left = 0;
            int right = 0;
            int top = 0;
            int bottom = 0;
            ZDSoft.SDK.ScnLib_ShowCaptureRegionFrame(true);
            ZDSoft.SDK.ScnLib_SelectCaptureRegion(ref left, ref top, ref right, ref bottom); // 划选区域 接下来要设置区域


            //Console.WriteLine($"left:{left}, top:{top}, right:{right}, botttom:{bottom}");
            //ZDSoft.SDK.ScnLib_GetCaptureRegion(ref left, ref top, ref right, ref bottom);
            //Console.WriteLine($"left:{left}, top:{top}, right:{right}, botttom:{bottom}");
            //ZDSoft.SDK.ScnLib_SetCaptureRegion(-1920, 0, 0, 1080);  // 设置录屏区域


            ZDSoft.SDK.ScnLib_SetCaptureRegion(left, top, right, bottom);  // 设置录屏区域
            //ZDSoft.SDK.ScnLib_ConfigureAudioSourceDevices(true);
            //ZDSoft.SDK.ScnLib_SelectAudioSourceDevice(true, 0);
            ZDSoft.SDK.ScnLib_SetVideoPathW("d:\\World.mp4");  // 后缀名决定输出格式

            ZDSoft.SDK.ScnLib_AddCursorEffects(true, true, true, true);


            //ZDSoft.SDK.ScnLib_SetVideoResolution(1920, 1000);

            //ZDSoft.SDK.ScnLib_ShowCountdownBox(4); // 倒计时4秒  
            success = ZDSoft.SDK.ScnLib_StartRecording();
            //PreviewVideoWin win = new PreviewVideoWin();
            //WindowInteropHelper interopHelper = new WindowInteropHelper(win);
            //IntPtr hwnd = interopHelper.Handle;
            //ZDSoft.SDK.ScnLib_PreviewVideo(true, IntPtr.Zero, true, 0xff0000);

            if (!success)
            {
                MessageBox.Show("StartRecording error");
            }
        }

        private void StopRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            ZDSoft.SDK.ScnLib_StopRecording();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string strShow = string.Empty;
            //foreach (var screen in Screen.AllScreens)
            //{
            //    strShow += screen.WorkingArea.ToString() + "\r\n";
            //}
            ////int a = Add1(2, 3);
            //MessageBox.Show(strShow);

            //int count = ZDSoft.SDK.ScnLib_GetAudioSourceDeviceCount(true);
            //MessageBox.Show($"count:{count}");


            bool flag = ZDSoft.SDK.ScnLib_IsRecordAudioSource(true);
            MessageBox.Show(flag.ToString());
            flag = ZDSoft.SDK.ScnLib_IsRecordAudioSource(false);
            MessageBox.Show(flag.ToString());

            //int ret = ZDSoft.SDK.ScnLib_GetSelectedAudioSourceDevice(true);
            //MessageBox.Show(ret.ToString());
            //ret = ZDSoft.SDK.ScnLib_GetSelectedAudioSourceDevice(false);
            //MessageBox.Show(ret.ToString());

            //StringBuilder stringBuilder = new StringBuilder(30);
            //ZDSoft.SDK.ScnLib_GetAudioSourceDeviceW(true, -1, stringBuilder);
            //MessageBox.Show(stringBuilder.ToString());

            //ZDSoft.SDK.ScnLib_GetAudioSourceDeviceW(false, -1, stringBuilder);
            //MessageBox.Show(stringBuilder.ToString());


            //ZDSoft.SDK.ScnLib_SelectAudioSourceDevice(false, 0);
            //int ret = ZDSoft.SDK.ScnLib_GetSelectedAudioSourceDevice(false);
            //MessageBox.Show(ret.ToString());
            //bool flag = ZDSoft.SDK.ScnLib_IsRecordAudioSource(false);
            //MessageBox.Show(flag.ToString());
        }

        private void BothBtn_Click(object sender, RoutedEventArgs e)
        {
            ZDSoft.SDK.ScnLib_RecordAudioSource(true, true);
            ZDSoft.SDK.ScnLib_RecordAudioSource(false, true);
        }

        private void SpeakerBtn_Click(object sender, RoutedEventArgs e)
        {
            ZDSoft.SDK.ScnLib_RecordAudioSource(true, true);
            ZDSoft.SDK.ScnLib_RecordAudioSource(false, false);
        }

        private void InputBtn_Click(object sender, RoutedEventArgs e)
        {
            ZDSoft.SDK.ScnLib_RecordAudioSource(true, false);
            ZDSoft.SDK.ScnLib_RecordAudioSource(false, true);
        }

        private void NoneButton_Click(object sender, RoutedEventArgs e)
        {
            ZDSoft.SDK.ScnLib_RecordAudioSource(true, false);
            ZDSoft.SDK.ScnLib_RecordAudioSource(false, false);
        }

        private void CamBtn_Click(object sender, RoutedEventArgs e)
        {
            int count = ZDSoft.SDK.ScnLib_GetWebcamDeviceCount();
            MessageBox.Show(count.ToString());


            ZDSoft.SDK.ScnLib_RecordWebcamOnly(true);
        }

        private void PreviewCamBtn_Click(object sender, RoutedEventArgs e)
        {
            ZDSoft.SDK.ScnLib_PreviewWebcam(true, IntPtr.Zero, true, 0x000000);
        }

        private void LogoBtn_OnClick(object sender, RoutedEventArgs e)
        {
            // Set logo Opacity
            #region
            //double opacity = ZDSoft.SDK.ScnLib_GetLogoOpacity();
            //string message = $"logo opacity:{opacity}";
            //MessageBox.Show(message);
            //ZDSoft.SDK.ScnLib_SetLogoOpacity(0.1);
            //opacity = ZDSoft.SDK.ScnLib_GetLogoOpacity();
            //message = $"logo opacity:{opacity}";
            //MessageBox.Show(message);
            #endregion

            // set logo text
            #region set logo text

            //ZDSoft.SDK.ScnLib_GetLogoTextW();

            //bool success = ZDSoft.SDK.ScnLib_SetLogoTextW(String.Empty, new LOGFONT(), 0x000000, false);

            //MessageBox.Show($"success:{success}");

            #endregion


        }

        private void QualityBtn_OnClick(object sender, RoutedEventArgs e)
        {
            int quality = ZDSoft.SDK.ScnLib_GetVideoQuality();
            MessageBox.Show($"Quality:{quality}");
        }

        private void GetRecordTimeBtn_OnClick(object sender, RoutedEventArgs e)
        {
            uint duration = ZDSoft.SDK.ScnLib_GetRecTime();
         
            TimeSpan time = new TimeSpan(0, 0, 0, (int)duration);

            MessageBox.Show(time.ToString(@"dd\.hh\:mm\:ss"));
        }

        private void MoveFileBtn_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("1.mp4"))
            {
                if (File.Exists("d:\\1.mp4"))
                {
                    File.Delete("d:\\1.mp4");
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "1.mp4";
                saveFileDialog.Filter = ".mp4|*.mp4";

                bool? ret = saveFileDialog.ShowDialog();
                if (ret == true)
                {
                    File.Move("1.mp4", saveFileDialog.FileName);
                }
                else
                {
                    MessageBox.Show("cancel");
                    return;
                }
               
                MessageBox.Show("yes");
            }
            else
            {
                MessageBox.Show("file 1.mp4 not exists");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bool success = ZDSoft.SDK.ScnLib_Initialize();
            if (!success)
            {
                MessageBox.Show("Initialize error");
                return;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ZDSoft.SDK.ScnLib_Uninitialize();
        }

        private void DeleteFileBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists("1.mp4"))
                {
                    File.SetAttributes("1.mp4", FileAttributes.Normal);
                    File.Delete("1.mp4");
                }
                MessageBox.Show("success to delete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GetAudioDeviceCountBtn_OnClick(object sender, RoutedEventArgs e)
        {
            int count = ZDSoft.SDK.ScnLib_GetAudioSourceDeviceCount(false);
            //MessageBox.Show(count.ToString());
            StringBuilder stringBuilder = new StringBuilder(500);
            //for (int i = 0; i < count; i++)
            //{
                bool ret = ZDSoft.SDK.ScnLib_GetAudioSourceDeviceW(true, -1, stringBuilder);
                Console.WriteLine("index:{0}, deviceName:{1}, retz:{2}", -1, stringBuilder, ret);
            //}
        }

        private void SetCursorBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //ZDSoft.SDK.ScnLib_SetCursorEffectsColors();
            //uint highlightColor = 0;
            //uint leftClickColor = 0;
            //uint rightClickColor = 0;
            //uint trackColor = 0;
            //ZDSoft.SDK.ScnLib_GetCursorEffectsColors(ref highlightColor, ref leftClickColor, ref rightClickColor, ref trackColor);

            //highlightColor = 65535;

            //ZDSoft.SDK.ScnLib_SetCursorEffectsColors(highlightColor, leftClickColor, rightClickColor, trackColor);

            //MessageBox.Show(
            //    $"highlightColor:{highlightColor}, leftClick:{leftClickColor}, rightClickColor:{rightClickColor}, trackColor:{trackColor}");

            ZDSoft.SDK.ScnLib_SetCursorOriginalSize(true);
            bool isOriginalSize = ZDSoft.SDK.ScnLib_IsCursorOriginalSize();
            MessageBox.Show($"isOriginalSize:{isOriginalSize}");
        }
    }
}
