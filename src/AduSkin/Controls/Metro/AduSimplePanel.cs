using System;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
   /// <summary>
   ///     用以代替Grid
   /// </summary>
   /// <remarks>
   ///     当不需要Grid的行、列分隔等功能时建议用此轻量级类代替
   /// </remarks>
   public class AduSimplePanel : Panel
   {
      protected override Size MeasureOverride(Size availableSize)
      {
         var maxSize = new Size();

         foreach (UIElement child in InternalChildren)
         {
            if (child != null)
            {
               child.Measure(availableSize);
               maxSize.Width = Math.Max(maxSize.Width, child.DesiredSize.Width);
               maxSize.Height = Math.Max(maxSize.Height, child.DesiredSize.Height);
            }
         }

         return maxSize;
      }

      protected override Size ArrangeOverride(Size arrangeSize)
      {
         foreach (UIElement child in InternalChildren)
         {
            child?.Arrange(new Rect(arrangeSize));
         }

         return arrangeSize;
      }
   }
}
