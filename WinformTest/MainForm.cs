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
using WinformTest.Views;

namespace WinformTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            int id = 0;     // The id of the hotkey. 
            bool flag = RegisterHotKey(this.Handle, id, (int)(KeyModifiers.Shift | KeyModifiers.Control), (uint)Keys.A.GetHashCode());
            flag = RegisterHotKey(this.Handle, 100, (int)(KeyModifiers.Shift | KeyModifiers.Control), (uint)Keys.E);
            Console.WriteLine(flag);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
        }


        #region Hotkey
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //if (m.Msg == 0x0312)
            //{
            //    /* Note that the three lines below are not needed if you only want to register one hotkey.
            //     * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

            //    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
            //    KeyModifiers modifier = (KeyModifiers)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
            //    int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.


            //    MessageBox.Show("Hotkey has been pressed!");
            //    // do something
            //}
            if (m.WParam == (IntPtr)100)
            {
                Console.WriteLine("yes");
            }
        }


        [DllImport("user32", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        #endregion

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;

            //Pen mypen = new Pen(Brushes.Black);
            //Brush mybrush = new SolidBrush(Color.Red);
            //g.TranslateTransform(100.0f, 100.0f);
            //Console.WriteLine(g.RenderingOrigin);
            //g.RotateTransform(90);

            //g.DrawRectangle(mypen, 0, 0, 100, 50);
            //Font drawFont = new Font("Arial", 16);

            //PointF drawPoint = new PointF(0.0f, 0.0f);
            
            //g.DrawString("helloworld", drawFont, mybrush, drawPoint);
            
        }

        private void btnKeyDown_Click(object sender, EventArgs e)
        {
            KeyDownForm form = new KeyDownForm();
            form.Show();
        }

        private void btnTopmostForm_Click(object sender, EventArgs e)
        {
            TopmostForm form = new TopmostForm();
            form.Show();
        }

        private void GraphicsButton_Click(object sender, EventArgs e)
        {
            GraphicsTestWInfom form = new GraphicsTestWInfom();
            form.Show();
        }
    }

    [Flags]
    public enum KeyModifiers
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Windows = 8,
        NoRepeat = 0x4000
    }
}
