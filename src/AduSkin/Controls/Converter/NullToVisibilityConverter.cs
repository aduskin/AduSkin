using System;
using System.Windows;
using System.Windows.Data;

namespace AduSkin.Controls.Converter
{
   /// <summary>
   /// 判断值是否为空
   /// </summary>
   public class NullToVisibilityConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         if (value != null)
            return Visibility.Visible;
         else
            return Visibility.Collapsed;
      }

      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
         return null;
      }
   }
}
