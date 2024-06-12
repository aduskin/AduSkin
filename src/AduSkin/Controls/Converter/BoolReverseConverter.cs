using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AduSkin.Controls.Converter
{
   public class BoolReverseConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value is bool boolValue)
         {
            return !boolValue;
         }
         else
         {
            return value;
         }
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value is bool boolValue)
         {
            return !boolValue;
         }
         else
         {
            return value;
         }
      }
   }
}
