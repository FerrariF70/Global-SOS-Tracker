using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace AppGST
{
    /// <summary>
    /// Helper class to BingMaps realization private DependencyProperty
    /// </summary>
    public class BehaviorBingMaps : Behavior<DependencyObject>
    {
        private readonly Binding binding = new Binding("") { Mode = BindingMode.OneWayToSource };
        public PropertyPath Property { get => binding.Path; set => binding.Path = value; }

        protected override void OnAttached()
        {
            binding.Source = AssociatedObject;
            BindingOperations.SetBinding(this, SourceProperty, binding);
        }
        private object Source
        {
            get { return (object)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        private static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(object), typeof(BehaviorBingMaps), new PropertyMetadata(null));

        private static void PropertyChangeCallback(DependencyObject d , DependencyPropertyChangedEventArgs e)
        {
            (d as BehaviorBingMaps).Source = e.NewValue;
        }

        public object Target
        {
            get { return (object)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(object), typeof(BehaviorBingMaps), new PropertyMetadata(null, PropertyChangeCallback));
    }
}
