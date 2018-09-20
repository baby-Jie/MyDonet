﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SharedResources.Controls
{
    public class MyListBox : System.Windows.Controls.ListBox
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MyListBoxItem();
        }
    }

    public class MyListBoxItem : System.Windows.Controls.ListBoxItem
    {
        protected override void OnSelected(System.Windows.RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is ListBoxItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;

            ListBoxItem item = (ListBoxItem)dep;

            if (item.IsSelected)
            {
                item.IsSelected = !item.IsSelected;
                //e.Handled = true;
            }
            base.OnSelected(e);
        }
    }
}
