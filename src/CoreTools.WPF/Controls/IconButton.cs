using System.Windows;
using System.Windows.Controls;

namespace CoreTools.WPF.Controls
{
    public class IconButton : Button
    {
        public ControlTemplate Icon
        {
            get => (ControlTemplate) GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ControlTemplate), typeof(IconButton),
                new PropertyMetadata(default(ControlTemplate)));
    }
}