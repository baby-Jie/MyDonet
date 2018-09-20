using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfTest.Views
{
    /// <summary>
    /// ThumbTestWin.xaml 的交互逻辑
    /// </summary>
    public partial class ThumbTestWin : Window
    {
        public ThumbTestWin()
        {
            InitializeComponent();
        }

        private void Thumb_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            Thumb thumb = (Thumb)sender;

            double nTop = Canvas.GetTop(thumb) + e.VerticalChange;
            double nLeft = Canvas.GetLeft(thumb) + e.HorizontalChange;


            //    防止Thumb控件被拖出容器。  
            if (nTop <= 0)
                nTop = 0;
            if (nTop >= (g.Height - thumb.Height))
                nTop = g.Height - thumb.Height;
            if (nLeft <= 0)
                nLeft = 0;
            if (nLeft >= (g.Width - thumb.Width))
                nLeft = g.Width - thumb.Width;
            Canvas.SetTop(thumb, nTop);
            Canvas.SetLeft(thumb, nLeft);

        }
    }
}
