using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace CoreTools.WPF.Behaviors
{
    public static class Interactions
    {
        public static BehaviorsCollection GetBehaviors(DependencyObject obj)
        {
            return (BehaviorsCollection) obj.GetValue(BehaviorsProperty);
        }

        public static void SetBehaviors(DependencyObject obj, BehaviorsCollection value)
        {
            obj.SetValue(BehaviorsProperty, value);
        }

        public static readonly DependencyProperty BehaviorsProperty =
            DependencyProperty.RegisterAttached("Behaviors", typeof(BehaviorsCollection), typeof(Interactions),
                new UIPropertyMetadata(null, OnPropertyBehaviorsChanged));

        private static void OnPropertyBehaviorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is not BehaviorsCollection behaviorsCollection) return;
            
            var behaviors = Interaction.GetBehaviors(d);
            
            foreach (var behavior in behaviorsCollection)
                behaviors.Add(behavior);
        }

        public static TriggersCollection GetTriggers(DependencyObject obj)
        {
            return (TriggersCollection) obj.GetValue(TriggersProperty);
        }

        public static void SetTriggers(DependencyObject obj, TriggersCollection value)
        {
            obj.SetValue(TriggersProperty, value);
        }

        public static readonly DependencyProperty TriggersProperty =
            DependencyProperty.RegisterAttached("Triggers", typeof(TriggersCollection), typeof(Interactions),
                new UIPropertyMetadata(null, OnPropertyTriggersChanged));

        private static void OnPropertyTriggersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is not TriggersCollection triggersCollection) return;
            
            var triggers = Interaction.GetTriggers(d);
            
            foreach (var trigger in triggersCollection)
                triggers.Add(trigger);
        }
    }
}