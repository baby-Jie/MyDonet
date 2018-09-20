using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace CommonToolLib.CommanTools
{
    public static class WPFWindowHelper
    {

        /// <summary>
        /// 隐藏标题栏(包括ICon, titlebar的右键菜单, 三个系统窗口按钮)
        /// </summary>
        /// <param name="w"></param>
        public static void HideSysMenu(this Window w)
        {
            IntPtr hwnd = new WindowInteropHelper(w).Handle;
            int extendedStyle = WindowApiHelper.GetWindowLong(hwnd, WindowStaticMacro.GWL_EXSTYLE);
            WindowApiHelper.SetWindowLong(hwnd, WindowStaticMacro.GWL_EXSTYLE, extendedStyle | WindowStaticMacro.WS_EX_DLGMODALFRAME);
            WindowApiHelper.SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0, WindowStaticMacro.SWP_NOMOVE | WindowStaticMacro.SWP_NOSIZE | WindowStaticMacro.SWP_NOZORDER | WindowStaticMacro.SWP_FRAMECHANGED);
        }

        /// <summary>
        /// 禁用最小化按钮
        /// </summary>
        /// <param name="w"></param>
        public static void HideMinimizeBox(this Window w)
        {
            IntPtr hwnd = new WindowInteropHelper(w).Handle;
            WindowApiHelper.SetWindowLong(hwnd, WindowStaticMacro.GWL_STYLE,
                WindowApiHelper.GetWindowLong(hwnd, WindowStaticMacro.GWL_STYLE) & ~(WindowStaticMacro.WS_MINIMIZEBOX));
        }

        /// <summary>
        /// 禁用最大化按钮
        /// </summary>
        /// <param name="w"></param>
        public static void HideMaximizeBox(this Window w)
        {
            IntPtr hwnd = new WindowInteropHelper(w).Handle;
            WindowApiHelper.SetWindowLong(hwnd, WindowStaticMacro.GWL_STYLE,
                WindowApiHelper.GetWindowLong(hwnd, WindowStaticMacro.GWL_STYLE) & ~(WindowStaticMacro.WS_MAXIMIZEBOX));
        }

        /// <summary>
        /// 禁用最大最小化按钮并隐藏
        /// </summary>
        /// <param name="w"></param>
        public static void HideMinimizeAndMaximizeBoxes(this Window w)
        {
            IntPtr hwnd = new WindowInteropHelper(w).Handle;
            WindowApiHelper.SetWindowLong(hwnd, WindowStaticMacro.GWL_STYLE,
                WindowApiHelper.GetWindowLong(hwnd, WindowStaticMacro.GWL_STYLE) & ~(WindowStaticMacro.WS_MAXIMIZEBOX | WindowStaticMacro.WS_MINIMIZEBOX));
        }

        /// <summary>
        /// 移除Icon
        /// </summary>
        /// <param name="window"></param>
        public static void RemoveIcon(this Window window)
        {
            // Get this window's handle
            IntPtr hwnd = new WindowInteropHelper(window).Handle;
            // Change the extended window style to not show a window icon
            int extendedStyle = WindowApiHelper.GetWindowLong(hwnd, WindowStaticMacro.GWL_EXSTYLE);
            WindowApiHelper.SetWindowLong(hwnd, WindowStaticMacro.GWL_EXSTYLE, extendedStyle | WindowStaticMacro.WS_EX_DLGMODALFRAME);
            // Update the window's non-client area to reflect the changes
            WindowApiHelper.SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0, WindowStaticMacro.SWP_NOMOVE | WindowStaticMacro.SWP_NOSIZE |
    WindowStaticMacro.SWP_NOZORDER | WindowStaticMacro.SWP_FRAMECHANGED);
        }

        /// <summary>
        /// 删除最小化,最大化,移动菜单
        /// </summary>
        /// <param name="window"></param>
        public static void HiddenMenu(this Window window)
        {
            IntPtr hwnd = new WindowInteropHelper(window).Handle;
            IntPtr hMenu = WindowApiHelper.GetSystemMenu(hwnd, false); //获取程序窗体的句柄
            if (hMenu != IntPtr.Zero)
            {
                WindowApiHelper.DeleteMenu(hMenu, WindowStaticMacro.SC_MINI, WindowStaticMacro.MF_BYCOMMAND); //删除最小化菜单，禁用移动功能
                WindowApiHelper.DeleteMenu(hMenu, WindowStaticMacro.SC_MOVE, WindowStaticMacro.MF_BYCOMMAND); //删除移动菜单，禁用移动功能
                WindowApiHelper.DeleteMenu(hMenu, WindowStaticMacro.SC_MAX, WindowStaticMacro.MF_BYCOMMAND); //删除最大化菜单，禁用移动功能
                //  EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED | MF_DISABLED); //禁用关闭功能
            }
        }

        /// <summary>
        /// 获取系统Button的值
        /// </summary>
        /// <param name="window"></param>
        /// <param name="buttonType"></param>
        /// <param name="removeAccess"></param>
        /// <returns></returns>
        public static string GetButtonText(this Window window, ButtonType buttonType, bool removeAccess = false)
        {
            StringBuilder sb = new StringBuilder(256);

            IntPtr user32 = WindowApiHelper.LoadLibrary(Environment.SystemDirectory + "\\User32.dll");

            uint button_Caption;

            switch (buttonType)
            {
                case ButtonType.OK:
                    button_Caption = WindowStaticMacro.OK_CAPTION;
                    break;
                case ButtonType.CANCEL:
                    button_Caption = WindowStaticMacro.CANCEL_CAPTION;
                    break;
                case ButtonType.ABORT:
                    button_Caption = WindowStaticMacro.ABORT_CAPTION;
                    break;
                case ButtonType.RETRY:
                    button_Caption = WindowStaticMacro.RETRY_CAPTION;
                    break;
                case ButtonType.IGNORE:
                    button_Caption = WindowStaticMacro.IGNORE_CAPTION;
                    break;
                case ButtonType.YES:
                    button_Caption = WindowStaticMacro.YES_CAPTION;
                    break;
                case ButtonType.NO:
                    button_Caption = WindowStaticMacro.NO_CAPTION;
                    break;
                case ButtonType.CLOSE:
                    button_Caption = WindowStaticMacro.CLOSE_CAPTION;
                    break;
                case ButtonType.HELP:
                    button_Caption = WindowStaticMacro.HELP_CAPTION;
                    break;
                case ButtonType.TRYAGAIN:
                    button_Caption = WindowStaticMacro.TRYAGAIN_CAPTION;
                    break;
                case ButtonType.CONTINUE:
                    button_Caption = WindowStaticMacro.CONTINUE_CAPTION;
                    break;
                default:
                    button_Caption = WindowStaticMacro.OK_CAPTION;
                    break;

            }
            WindowApiHelper.LoadString(user32, button_Caption, sb, sb.Capacity);
            string text = sb.ToString();

            if (removeAccess)
            {
                int index = text.IndexOf("(");
                if (index >= 0)
                {
                    text = text.Substring(0, index);
                }
            }
            else
            {
                text = text.Replace('&', '_');
            }
            return text;
        }

    }

    public enum ButtonType
    {
        OK,
        CANCEL,
        ABORT,
        RETRY,
        IGNORE,
        YES,
        NO,
        CLOSE,
        HELP,
        TRYAGAIN,
        CONTINUE
    }
}
