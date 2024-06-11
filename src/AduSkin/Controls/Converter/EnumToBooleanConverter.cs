using System;
using System.Globalization;
using System.Windows.Data;

namespace AduSkin.Controls.Converter
{
   public class EnumToBooleanConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return value == null ? false : value.Equals(parameter);
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return value != null && value.Equals(true) ? parameter : Binding.DoNothing;
      }
   }
}
