using System;
using System.Globalization;
using System.Windows.Media;

namespace CoreTools.WPF.Converters
{
    public class BrushToColorConverter : ValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is SolidColorBrush brush ? brush.Color : new SolidColorBrush(Colors.Black);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color color ? new SolidColorBrush(color) : new SolidColorBrush(Colors.Black);
        }
    }
}