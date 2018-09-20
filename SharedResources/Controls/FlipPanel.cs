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
    //[TemplatePart(Name = "FlipButton", Type = typeof(ToggleButton)),
    //     TemplatePart(Name = "FlipButtonAlternate", Type = typeof(ToggleButton)),
    //     TemplateVisualState(Name = "Normal", GroupName = "VisualStates"),
    //     TemplateVisualState(Name = "Flipped", GroupName = "VisualStates")]
    public class FlipPanel:Control
    {

        #region Private Members

        private void ChangeVisualState(bool useTransitions)
        {
            if (this.IsFlipped)
            {
                VisualStateManager.GoToState(this, "BackState", useTransitions);
            }
            else
            {
                VisualStateManager.GoToState(this, "FrontState", useTransitions);
            }
        }

        #endregion

        #region Event Handlers

        private void FlipButtonClick(object sender, RoutedEventArgs e)
        {
            this.IsFlipped = !this.IsFlipped;
        }

        #endregion

        #region Public Properties

        #region DependencyProperty FrontContent

        public object FrontContent
        {
            get { return (object)GetValue(FrontContentProperty); }
            set { SetValue(FrontContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FrontContent.  This enables animation, styling, binding, etc...
        public static readonly System.Windows.DependencyProperty FrontContentProperty =
            System.Windows.DependencyProperty.Register("FrontContent", typeof(object), typeof(FlipPanel), new System.Windows.PropertyMetadata(default(object)));


        #endregion

        #region DependencyProperty BackContent

        public object BackContent
        {
            get { return (object)GetValue(BackContentProperty); }
            set { SetValue(BackContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackContent.  This enables animation, styling, binding, etc...
        public static readonly System.Windows.DependencyProperty BackContentProperty =
            System.Windows.DependencyProperty.Register("BackContent", typeof(object), typeof(FlipPanel), new System.Windows.PropertyMetadata(default(object)));


        #endregion

        #region DependencyProperty IsFlipped

        public bool IsFlipped
        {
            get
            {
                return (bool)GetValue(IsFlippedProperty);
            }
            set
            {
                SetValue(IsFlippedProperty, value);
                ChangeVisualState(true);
            }
        }

        // Using a DependencyProperty as the backing store for IsFlipped.  This enables animation, styling, binding, etc...
        public static readonly System.Windows.DependencyProperty IsFlippedProperty =
            System.Windows.DependencyProperty.Register("IsFlipped", typeof(bool), typeof(FlipPanel), new System.Windows.PropertyMetadata(false));


        #endregion

        #region DependencyProperty CornerRadius

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly System.Windows.DependencyProperty CornerRadiusProperty =
            System.Windows.DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(FlipPanel), new System.Windows.PropertyMetadata(default(CornerRadius)));


        #endregion

        #endregion

        #region Public Constructors

        static FlipPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlipPanel), new FrameworkPropertyMetadata(typeof
                (FlipPanel)));
        }

        #endregion

        #region Overridden Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ToggleButton button1 = base.GetTemplateChild("FlipButton") as ToggleButton;
            if (null != button1)
            {
                button1.Click += FlipButtonClick;
            }

            ToggleButton button2 = base.GetTemplateChild("FlipButtonAlternate") as ToggleButton;
            if (null != button2)
            {
                button2.Click += FlipButtonClick;
            }

            ChangeVisualState(false);

        }

        #endregion
    }
}
