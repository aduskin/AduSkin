using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace AduSkin.Controls.Converter
{
   public class DoubleToPercentageConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value is double dvalue)
         {
            return $"{dvalue * 100.0}%";
         }
         return $"0%";
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return parameter;
      }
   }
}
