using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AduSkin.Controls.Converter
{
   public class EnumConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         return value?.Equals(parameter);
      }

      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         return value?.Equals(true) == true ? parameter : Binding.DoNothing;
      }
   }
}
