using System;
using System.ComponentModel;
using System.Globalization;

namespace AduSkin.Controls.Metro
{
   public class TextBlockHighlightSourceConverter : TypeConverter
   {
      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
      {
         if (sourceType == typeof(string))
         {
            return true;
         }

         return base.CanConvertFrom(context, sourceType);
      }


      public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
      {
         if (destinationType == typeof(TextBlockHighlightSource))
         {
            return true;
         }

         return base.CanConvertTo(context, destinationType);
      }

      public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
      {
         switch (value)
         {
            case null:
               throw GetConvertFromException(null);
            case string source:
               return new TextBlockHighlightSource { Text = value.ToString() };
         }

         return base.ConvertFrom(context, culture, value);
      }

      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
      {
         switch (value)
         {
            case TextBlockHighlightSource instance:
               if (destinationType == typeof(string))
               {
                  return instance.Text;
               }
               break;
         }

         return base.ConvertTo(context, culture, value, destinationType);
      }
   }
}
