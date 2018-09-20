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
using DSkin.Forms;
using WpfTest.Views;

namespace WinformTest.Views
{
    public partial class TopmostForm : Form
    {
        public TopmostForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void TopmostForm_Shown(object sender, EventArgs e)
        {
            PopUpWin win = new PopUpWin();
            WindowInteropHelper interopHelper = new WindowInteropHelper(win);
            interopHelper.Owner = this.Handle;
            win.Show();
        }
    }
}
