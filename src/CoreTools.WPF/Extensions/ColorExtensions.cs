using System.Windows.Media;

namespace CoreTools.WPF.Extensions
{
    public static class ColorExtensions
    {
        public static Color FromHex(this Color color, string hexColor)
        {
            return (Color)ColorConverter.ConvertFromString(hexColor);
        }
    }
}