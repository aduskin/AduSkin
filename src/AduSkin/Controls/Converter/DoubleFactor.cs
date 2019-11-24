using System;
using System.Globalization;
using System.Windows.Data;

namespace AduSkin.Controls.Converter
{
    public class DoubleFactor : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return 0.0;
            }
            else if (parameter == null)
            {
                return System.Convert.ToDouble(value);
            }
            else
            {
                return System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter);
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return 0.0;
            }
            else if (parameter == null)
            {
                return System.Convert.ToDouble(value);
            }
            else
            {
                return System.Convert.ToDouble(value) / System.Convert.ToDouble(parameter);
            }
        }
    }
}