using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace CoreTools.WPF.Controls
{
    public class DropDownButton : ToggleButton
    {
        public DropDownButton()
        {
            // Bind the ToggleButton.IsChecked property to the drop-down's IsOpen property
            var binding = new Binding("Menu.IsOpen")
            {
                Source = this
            };

            SetBinding(IsCheckedProperty, binding);

            DataContextChanged += (_, _) =>
            {
                if (Menu is not null)
                    Menu.DataContext = DataContext;
            };
        }

        // *** Properties ***
        public ContextMenu? Menu
        {
            get => (ContextMenu)GetValue(MenuProperty);
            set => SetValue(MenuProperty, value);
        }

        public static readonly DependencyProperty MenuProperty = DependencyProperty.Register("Menu",
            typeof(ContextMenu), typeof(DropDownButton), new UIPropertyMetadata(null, OnMenuChanged));

        private static void OnMenuChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dropDownButton = (DropDownButton)d;
            var contextMenu = (ContextMenu)e.NewValue;
            contextMenu.DataContext = dropDownButton.DataContext;
        }

        protected override void OnClick()
        {
            if (Menu is null) return;
            Menu.PlacementTarget = this;
            Menu.Placement = PlacementMode.Bottom;
            Menu.IsOpen = true;
        }
    }
}