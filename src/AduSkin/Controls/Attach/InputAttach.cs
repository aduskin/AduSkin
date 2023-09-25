using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace AduSkin.Controls.Attach
{
   public class InputAttach
   {
      /// <summary>
      /// 输入提示
      /// </summary>
      public static readonly DependencyProperty InputHintProperty = DependencyProperty.RegisterAttached(
            "InputHint", typeof(string), typeof(InputAttach), new PropertyMetadata(default(string)));

      public static void SetInputHint(DependencyObject element, string value)
          => element.SetValue(InputHintProperty, value);

      public static string GetInputHint(DependencyObject element)
          => (string)element.GetValue(InputHintProperty);
   }
}
