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

      /// <summary>
      /// 操作提示
      /// </summary>
      public static readonly DependencyProperty OperationHintProperty = DependencyProperty.RegisterAttached(
            "OperationHint", typeof(string), typeof(InputAttach), new PropertyMetadata(default(string)));

      public static void SetOperationHint(DependencyObject element, string value)
          => element.SetValue(OperationHintProperty, value);

      public static string GetOperationHint(DependencyObject element)
          => (string)element.GetValue(OperationHintProperty);
   }
}
