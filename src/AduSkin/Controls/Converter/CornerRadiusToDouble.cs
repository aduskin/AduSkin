using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AduSkin.Controls.Converter
{
    public class CornerRadiusToDouble : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                return ((CornerRadius)value).TopLeft * System.Convert.ToDouble(parameter);
            }
            return ((CornerRadius)value).TopLeft;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                return new CornerRadius((double)value/ System.Convert.ToDouble(parameter));
            }
            return new CornerRadius((double)value);
        }
    }
}