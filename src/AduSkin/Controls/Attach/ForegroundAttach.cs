using System.Windows;
using System.Windows.Media;

namespace AduSkin.Controls.Attach
{
   public class ForegroundAttach
   {
      /// <summary>
      /// 默认颜色
      /// </summary>
      public static readonly DependencyProperty NormalForegroundProperty = DependencyProperty.RegisterAttached(
            "NormalForeground", typeof(Brush), typeof(ForegroundAttach), new PropertyMetadata(default(Brush)));

      public static void SetNormalForeground(DependencyObject element, Brush value)
          => element.SetValue(NormalForegroundProperty, value);

      public static Brush GetNormalForeground(DependencyObject element)
          => (Brush)element.GetValue(NormalForegroundProperty);

      /// <summary>
      /// 选中颜色
      /// </summary>
      public static readonly DependencyProperty SelectedForegroundProperty = DependencyProperty.RegisterAttached(
            "SelectedForeground", typeof(Brush), typeof(ForegroundAttach), new PropertyMetadata(default(Brush)));

      public static void SetSelectedForeground(DependencyObject element, Brush value)
          => element.SetValue(SelectedForegroundProperty, value);

      public static Brush GetSelectedForeground(DependencyObject element)
          => (Brush)element.GetValue(SelectedForegroundProperty);

      /// <summary>
      /// 高亮颜色
      /// </summary>
      public static readonly DependencyProperty HighlightForegroundProperty = DependencyProperty.RegisterAttached(
            "HighlightForeground", typeof(Brush), typeof(ForegroundAttach), new PropertyMetadata(default(Brush)));

      public static void SetHighlightForeground(DependencyObject element, Brush value)
          => element.SetValue(HighlightForegroundProperty, value);

      public static Brush GetHighlightForeground(DependencyObject element)
          => (Brush)element.GetValue(HighlightForegroundProperty);

      /// <summary>
      /// 鼠标悬浮颜色
      /// </summary>
      public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.RegisterAttached(
            "MouseOverForeground", typeof(Brush), typeof(ForegroundAttach), new PropertyMetadata(default(Brush)));

      public static void SetMouseOverForeground(DependencyObject element, Brush value)
          => element.SetValue(MouseOverForegroundProperty, value);

      public static Brush GetMouseOverForeground(DependencyObject element)
          => (Brush)element.GetValue(MouseOverForegroundProperty);

      /// <summary>
      /// 鼠标按下颜色
      /// </summary>
      public static readonly DependencyProperty PressedForegroundProperty = DependencyProperty.RegisterAttached(
            "PressedForeground", typeof(Brush), typeof(ForegroundAttach), new PropertyMetadata(default(Brush)));

      public static void SetPressedForeground(DependencyObject element, Brush value)
          => element.SetValue(PressedForegroundProperty, value);

      public static Brush GetPressedForeground(DependencyObject element)
          => (Brush)element.GetValue(PressedForegroundProperty);

      /// <summary>
      /// 禁用颜色
      /// </summary>
      public static readonly DependencyProperty DisabledForegroundProperty = DependencyProperty.RegisterAttached(
            "DisabledForeground", typeof(Brush), typeof(ForegroundAttach), new PropertyMetadata(default(Brush)));

      public static void SetDisabledForeground(DependencyObject element, Brush value)
          => element.SetValue(DisabledForegroundProperty, value);

      public static Brush GetDisabledForeground(DependencyObject element)
          => (Brush)element.GetValue(DisabledForegroundProperty);
   }
}
