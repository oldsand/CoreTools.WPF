﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CoreTools.WPF.Converters
{
    public class EnumResourceConverter : MarkupExtension, IValueConverter
    {
        public EnumResourceMapping ResourceMapping { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (ResourceMapping == null || value == null) return null;

            var resourceName = ResourceMapping[(Enum)value];
            return Application.Current.TryFindResource(resourceName);
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}