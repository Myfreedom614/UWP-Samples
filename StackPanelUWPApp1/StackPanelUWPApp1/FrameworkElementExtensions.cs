using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace StackPanelUWPApp1
{
    public static class FrameworkElementExtensions
    {
        public static T TraverseCTFindShape<T>(DependencyObject root, String name) where T : Windows.UI.Xaml.Shapes.Shape
        {
            T control = null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);

                string childName = child.GetValue(FrameworkElement.NameProperty) as string;
                control = child as T;

                if (childName == name)
                {
                    return control;
                }
                else
                {
                    control = TraverseCTFindShape<T>(child, name);

                    if (control != null)
                    {
                        return control;
                    }
                }
            }

            return control;
        }
    }
}
