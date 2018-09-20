using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SharedResources.Controls
{
    public class SubjectPanel:Control
    {
        #region Properties

        #region DependencyProperty ChineseContent

        public object ChineseContent
        {
            get { return (object)GetValue(ChineseContentProperty); }
            set { SetValue(ChineseContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChineseContent.  This enables animation, styling, binding, etc...
        public static readonly System.Windows.DependencyProperty ChineseContentProperty =
            System.Windows.DependencyProperty.Register("ChineseContent", typeof(object), typeof(SubjectPanel), new System.Windows.PropertyMetadata(default(object)));

        #endregion

        #region DependencyProperty MathContent

        public object MathContent
        {
            get { return (object)GetValue(MathContentProperty); }
            set { SetValue(MathContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MathContent.  This enables animation, styling, binding, etc...
        public static readonly System.Windows.DependencyProperty MathContentProperty =
            System.Windows.DependencyProperty.Register("MathContent", typeof(object), typeof(SubjectPanel), new System.Windows.PropertyMetadata(default(object)));

        #endregion

        #region DependencyProperty EnglishContent

        public object EnglishContent
        {
            get { return (object)GetValue(EnglishContentProperty); }
            set { SetValue(EnglishContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnglishContent.  This enables animation, styling, binding, etc...
        public static readonly System.Windows.DependencyProperty EnglishContentProperty =
            System.Windows.DependencyProperty.Register("EnglishContent", typeof(object), typeof(SubjectPanel), new System.Windows.PropertyMetadata(default(object)));

        #endregion

        #region DependencyProperty ContentType

        public ContentType ContentType
        {
            get { return (ContentType)GetValue(ContentTypeProperty); }
            set { SetValue(ContentTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentType.  This enables animation, styling, binding, etc...
        public static readonly System.Windows.DependencyProperty ContentTypeProperty =
            System.Windows.DependencyProperty.Register("ContentType", typeof(ContentType), typeof(SubjectPanel), new System.Windows.PropertyMetadata(default(ContentType)));


        #endregion

        #endregion

        #region Constructors

        static SubjectPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SubjectPanel), new FrameworkPropertyMetadata(typeof(SubjectPanel)));
        }

        #endregion Constructors

        #region public functions

        public void ChangeVisualState(ContentType contentType)
        {
            switch (contentType)
            {
                case ContentType.Chinese:
                    VisualStateManager.GoToState(this, "ChineseState", false);
                    break;
                case ContentType.Math:
                    VisualStateManager.GoToState(this, "MathState", false);
                    break;
                //case ContentType.English:
                //    VisualStateManager.GoToState(this, "EnglishState", false);
                //    break;
            }
        }

        #endregion

        #region Override Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ChangeVisualState(ContentType.Chinese);
            Button btn = this.Template.FindName("PART_TestButton", this) as Button;

            if (btn != null)
            {
                btn.Click += (sender, e) => { ChangeVisualState(ContentType.Chinese); };
            }

            ToggleButton toggleButton = base.GetTemplateChild("FlipButton") as ToggleButton;
            if (null != toggleButton)
                toggleButton.Click += (sender, e) => { ChangeVisualState(ContentType.Chinese); };
        }

        #endregion
    }

    public enum ContentType
    {
        Chinese = 0,
        Math = 1,
        English = 2
    }
}
