using ICSharpCode.AvalonEdit.Document;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AduSkin.Demo.Converter
{
   public class TextDocumentValueConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value is string @string)
         {
            return new TextDocument(@string);
         }
         return null;
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return (value as TextDocument)?.Text;
      }
   }
}
