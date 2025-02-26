using System;
using System.Globalization;
using System.Windows.Data;

namespace AduSkin.Controls.Converter
{
   /// <summary>
   /// 在0~9前面加0
   /// </summary>
   public class NumberConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value == null)
         {
            return 0;
         }
         int number = 0;
         int flag = 0;
         if (int.TryParse(value.ToString(), out number))
         {
            if (number > 99)
            {
               flag = 3;
            }
            else if (number > 9 && number <= 99)
            {
               flag = 2;
            }
            else
            {
               flag = 1;
            }
         }
         return flag;
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return null;
      }
   }
}
