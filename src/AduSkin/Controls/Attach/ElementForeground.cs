using System.Windows;
using System.Windows.Media;

namespace AduSkin.Controls.Attach
{
   public class ElementForeground
   {
      /// <summary>
      /// 默认颜色
      /// </summary>
      public static readonly DependencyProperty NormalForegroundProperty = DependencyProperty.RegisterAttached(
            "NormalForeground", typeof(SolidColorBrush), typeof(ElementForeground), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetNormalForeground(DependencyObject element, SolidColorBrush value)
          => element.SetValue(NormalForegroundProperty, value);

      public static SolidColorBrush GetNormalForeground(DependencyObject element)
          => (SolidColorBrush)element.GetValue(NormalForegroundProperty);

      /// <summary>
      /// 选中颜色
      /// </summary>
      public static readonly DependencyProperty SelectedForegroundProperty = DependencyProperty.RegisterAttached(
            "SelectedForeground", typeof(SolidColorBrush), typeof(ElementForeground), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetSelectedForeground(DependencyObject element, SolidColorBrush value)
          => element.SetValue(SelectedForegroundProperty, value);

      public static SolidColorBrush GetSelectedForeground(DependencyObject element)
          => (SolidColorBrush)element.GetValue(SelectedForegroundProperty);

      /// <summary>
      /// 高亮颜色
      /// </summary>
      public static readonly DependencyProperty HighlightForegroundProperty = DependencyProperty.RegisterAttached(
            "HighlightForeground", typeof(SolidColorBrush), typeof(ElementForeground), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetHighlightForeground(DependencyObject element, SolidColorBrush value)
          => element.SetValue(HighlightForegroundProperty, value);

      public static SolidColorBrush GetHighlightForeground(DependencyObject element)
          => (SolidColorBrush)element.GetValue(HighlightForegroundProperty);

      /// <summary>
      /// 鼠标悬浮颜色
      /// </summary>
      public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.RegisterAttached(
            "MouseOverForeground", typeof(SolidColorBrush), typeof(ElementForeground), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetMouseOverForeground(DependencyObject element, SolidColorBrush value)
          => element.SetValue(MouseOverForegroundProperty, value);

      public static SolidColorBrush GetMouseOverForeground(DependencyObject element)
          => (SolidColorBrush)element.GetValue(MouseOverForegroundProperty);

      /// <summary>
      /// 鼠标悬浮颜色
      /// </summary>
      public static readonly DependencyProperty PressedForegroundProperty = DependencyProperty.RegisterAttached(
            "PressedForeground", typeof(SolidColorBrush), typeof(ElementForeground), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetPressedForeground(DependencyObject element, SolidColorBrush value)
          => element.SetValue(PressedForegroundProperty, value);

      public static SolidColorBrush GetPressedForeground(DependencyObject element)
          => (SolidColorBrush)element.GetValue(PressedForegroundProperty);

      /// <summary>
      /// 禁用颜色
      /// </summary>
      public static readonly DependencyProperty DisabledForegroundProperty = DependencyProperty.RegisterAttached(
            "DisabledForeground", typeof(SolidColorBrush), typeof(ElementForeground), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetDisabledForeground(DependencyObject element, SolidColorBrush value)
          => element.SetValue(DisabledForegroundProperty, value);

      public static SolidColorBrush GetDisabledForeground(DependencyObject element)
          => (SolidColorBrush)element.GetValue(DisabledForegroundProperty);
   }
}
