using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;

namespace WinformTest.Views
{
    public partial class KeyDownForm : Form
    {
        public KeyDownForm()
        {
            InitializeComponent();
        }

        private void KeyDownForm_KeyDown(object sender, KeyEventArgs e)
        {
           
            MessageBox.Show(e.KeyCode.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeyDownWpf win = new KeyDownWpf();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(win);
            WindowInteropHelper interopHelper = new WindowInteropHelper(win);
            interopHelper.Owner = this.Handle;
            win.Show();
        }

        // 不重写这个方法也是可以的
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
