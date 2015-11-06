using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MvvmVisualStatesBehaviorUWPApp1.Behavior
{
    public class EnumStateBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }

        public object Value
        {
            get { return (Enum)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(EnumStateBehavior),
            new PropertyMetadata(null, ValuePropertyChanged));

        private static void ValuePropertyChanged(object sender,
            DependencyPropertyChangedEventArgs e)
        {
            var behavior = sender as EnumStateBehavior;
            if (behavior.AssociatedObject == null || e.NewValue == null) return;

            VisualStateManager.GoToState(behavior.AssociatedObject as Control,
                e.NewValue.ToString(), true);
        }

        public void Attach(DependencyObject associatedObject)
        {
            var control = associatedObject as Control;
            if (control == null)
                throw new ArgumentException(
                    "EnumStateBehavior can be attached only to Control");

            AssociatedObject = associatedObject;
        }

        public void Detach()
        {
            AssociatedObject = null;
        }
    }
}
