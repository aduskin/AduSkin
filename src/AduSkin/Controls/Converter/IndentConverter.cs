using AduSkin.Controls.Metro;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace AduSkin.Controls.Converter
{
   public class IndentConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         double colunwidth = 10;
         double left = 0.0;

         UIElement element = value as TreeViewItem;
         while (element.GetType() != typeof(AduTreeView))
         {
            element = (UIElement)VisualTreeHelper.GetParent(element);
            if (element.GetType() == typeof(TreeViewItem))
               left += colunwidth;
         }
         return new Thickness(left, 0, 0, 0);
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         throw new NotImplementedException();
      }

   }
}
