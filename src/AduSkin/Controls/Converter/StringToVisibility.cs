using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AduSkin.Controls.Converter
{
    public class StringToVisibility : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            return value == null || string.IsNullOrEmpty(value as string) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}