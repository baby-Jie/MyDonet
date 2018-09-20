using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;

namespace NotifyIconPractise
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);


        [DllImport("user32.dll")]
        private static extern int SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);

       
        public static void SetOwner(System.Windows.Forms.Form form, System.Windows.Window owner)
        {
            WindowInteropHelper helper = new WindowInteropHelper(owner);
            SetWindowLong(new HandleRef(form, form.Handle), -8, helper.Handle.ToInt32());
        }

        public static void SetFormAsWpfOwner(System.Windows.Window win, System.Windows.Forms.Form form)
        {
            IntPtr winHandle = new WindowInteropHelper(win).Handle;

            SetWindowLong(new HandleRef(win, winHandle), -8, form.Handle.ToInt32());
        }

        public static void setOwner(System.Windows.Forms.Form ownerForm, System.Windows.Window window)
        {
            WindowInteropHelper helper = new WindowInteropHelper(window);
            helper.Owner = ownerForm.Handle;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = !this.Visible;
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(3000, "this is title", "this is text", ToolTipIcon.Info);

        }

        private void ShowVisibleItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void WndProc(ref Message m)
        {
            switch(m.Msg)
            {
                case WM_SIZEING:
                    Console.WriteLine("this is a test about WndProc in winform!");
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }

        private const int WM_SIZEING = 0x0214;   //窗口改变大小消息

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                label1.Text = i.ToString();
                Application.DoEvents();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            WpfWin win = new WpfWin();
            IntPtr wpfHwnd = new WindowInteropHelper(win).Handle;
            // SetParent(wpfHwnd, this.Handle);
            //SetFormAsWpfOwner(win, this);
            setOwner(this, win);

            win.Show();

        }
    }
}
