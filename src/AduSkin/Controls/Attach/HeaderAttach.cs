using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AduSkin.Controls.Attach
{
   public class HeaderAttach
   {
      /// <summary>
      /// 隐藏/显示
      /// </summary>
      public static readonly DependencyProperty VisibleProperty = DependencyProperty.RegisterAttached(
            "Visible", typeof(Visibility), typeof(HeaderAttach), new PropertyMetadata(default(Visibility)));

      public static void SetVisible(DependencyObject element, Visibility value)
          => element.SetValue(VisibleProperty, value);

      public static Visibility GetVisible(DependencyObject element)
          => (Visibility)element.GetValue(VisibleProperty);
   }
}
