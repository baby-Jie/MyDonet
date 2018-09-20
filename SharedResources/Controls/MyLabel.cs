using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SharedResources.Controls
{
    public class MyLabel:Label
    {

        static MyLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyLabel), new FrameworkPropertyMetadata(typeof(MyLabel)));
        }

        public override void OnApplyTemplate()
        {
            Button testButton = base.GetTemplateChild("PART_TestButton") as Button;
            testButton.Click += (sender, args) =>
            {
                if (testButton != null)
                {
                    RoutedEventArgs routedEventArgs = new RoutedEventArgs(ButtonClickEvent);
                    this.RaiseEvent(routedEventArgs);
                }
            };

            base.OnApplyTemplate();
        }


        public event EventHandler ButtonClick
        {
            add { AddHandler(ButtonClickEvent, value); }
            remove { RemoveHandler(ButtonClickEvent, value); }
        }

        public static readonly RoutedEvent ButtonClickEvent = EventManager.RegisterRoutedEvent(
        "ButtonClick", RoutingStrategy.Bubble, typeof(EventHandler), typeof(MyLabel));

    }
}
