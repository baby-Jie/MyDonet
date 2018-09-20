using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SharedResources.Controls
{
    public class ImageButton:Button
    {

        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        #region DependencyProperty ImageContent

        public string ImageContent
        {
            get { return (string)GetValue(ImageContentProperty); }
            set { SetValue(ImageContentProperty, value); }
        }

        public static readonly System.Windows.DependencyProperty ImageContentProperty =
            System.Windows.DependencyProperty.Register("ImageContent", typeof(string), typeof(ImageButton), new System.Windows.PropertyMetadata(default(string)));


        #endregion
    }
}
