using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.CommanTools
{
    public class WindowStaticMacro
    {
        public const int GWL_STYLE = -16;
        public const int GWL_EXSTYLE = -20;
        
        public const int SWP_NOSIZE = 0x0001;
        public const int SWP_NOMOVE = 0x0002;
        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_FRAMECHANGED = 0x0020;

        public const int WS_EX_DLGMODALFRAME = 0x0001;
        public const int WS_MAXIMIZEBOX = 0x00010000;
        public const int WS_MINIMIZEBOX = 0x00020000;
        public const int WS_SYSMENU = 0x00080000;

        public const uint SC_MOVE = 0xF010; //移动
        public const uint SC_MAX = 0xf030;
        public const uint SC_MINI = 0xf020;
        public const uint SC_CLOSE = 0xF060;//关闭
        public const uint MF_BYCOMMAND = 0x00; //按命令方式
        public const uint MF_GRAYED = 0x01;    //灰掉
        public const uint MF_DISABLED = 0x02;  //不可用


        public const uint WM_SETICON = 0x0080;

        #region System Button Content

        public const uint OK_CAPTION = 800;
        public const uint CANCEL_CAPTION = 801;
        public const uint ABORT_CAPTION = 802;
        public const uint RETRY_CAPTION = 803;
        public const uint IGNORE_CAPTION = 804;
        public const uint YES_CAPTION = 805;
        public const uint NO_CAPTION = 806;
        public const uint CLOSE_CAPTION = 807;
        public const uint HELP_CAPTION = 808;
        public const uint TRYAGAIN_CAPTION = 809;
        public const uint CONTINUE_CAPTION = 810;

        #endregion
    }
}
