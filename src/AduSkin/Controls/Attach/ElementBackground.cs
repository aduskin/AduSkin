using System.Windows;
using System.Windows.Media;

namespace AduSkin.Controls.Attach
{
   public class ElementBackground
   {
      /// <summary>
      /// Panel背景色
      /// Combox下拉、日期选择面板
      /// </summary>
      public static readonly DependencyProperty PanelBackgroundProperty = DependencyProperty.RegisterAttached(
            "PanelBackground", typeof(SolidColorBrush), typeof(ElementBackground), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetPanelBackground(DependencyObject element, SolidColorBrush value)
          => element.SetValue(PanelBackgroundProperty, value);

      public static SolidColorBrush GetPanelBackground(DependencyObject element)
          => (SolidColorBrush)element.GetValue(PanelBackgroundProperty);

      /// <summary>
      /// 默认颜色
      /// </summary>
      public static readonly DependencyProperty NormalBackgroundProperty = DependencyProperty.RegisterAttached(
            "NormalBackground", typeof(SolidColorBrush), typeof(ElementBackground), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetNormalBackground(DependencyObject element, SolidColorBrush value)
          => element.SetValue(NormalBackgroundProperty, value);

      public static SolidColorBrush GetNormalBackground(DependencyObject element)
          => (SolidColorBrush)element.GetValue(NormalBackgroundProperty);

      /// <summary>
      /// 高亮颜色
      /// </summary>
      public static readonly DependencyProperty HighlightBackgroundProperty = DependencyProperty.RegisterAttached(
            "HighlightBackground", typeof(SolidColorBrush), typeof(ElementBackground), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetHighlightBackground(DependencyObject element, SolidColorBrush value)
          => element.SetValue(HighlightBackgroundProperty, value);

      public static SolidColorBrush GetHighlightBackground(DependencyObject element)
          => (SolidColorBrush)element.GetValue(HighlightBackgroundProperty);

      /// <summary>
      /// 选中颜色
      /// </summary>
      public static readonly DependencyProperty SelectedBackgroundProperty = DependencyProperty.RegisterAttached(
            "SelectedBackground", typeof(SolidColorBrush), typeof(ElementBackground), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetSelectedBackground(DependencyObject element, SolidColorBrush value)
          => element.SetValue(SelectedBackgroundProperty, value);

      public static SolidColorBrush GetSelectedBackground(DependencyObject element)
          => (SolidColorBrush)element.GetValue(SelectedBackgroundProperty);

      /// <summary>
      /// 鼠标悬浮颜色
      /// </summary>
      public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.RegisterAttached(
            "MouseOverBackground", typeof(SolidColorBrush), typeof(ElementBackground), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetMouseOverBackground(DependencyObject element, SolidColorBrush value)
          => element.SetValue(MouseOverBackgroundProperty, value);

      public static SolidColorBrush GetMouseOverBackground(DependencyObject element)
          => (SolidColorBrush)element.GetValue(MouseOverBackgroundProperty);

      /// <summary>
      /// 鼠标悬浮颜色
      /// </summary>
      public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.RegisterAttached(
            "PressedBackground", typeof(SolidColorBrush), typeof(ElementBackground), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetPressedBackground(DependencyObject element, SolidColorBrush value)
          => element.SetValue(PressedBackgroundProperty, value);

      public static SolidColorBrush GetPressedBackground(DependencyObject element)
          => (SolidColorBrush)element.GetValue(PressedBackgroundProperty);

      /// <summary>
      /// 禁用颜色
      /// </summary>
      public static readonly DependencyProperty DisabledBackgroundProperty = DependencyProperty.RegisterAttached(
            "DisabledBackground", typeof(SolidColorBrush), typeof(ElementBackground), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetDisabledBackground(DependencyObject element, SolidColorBrush value)
          => element.SetValue(DisabledBackgroundProperty, value);

      public static SolidColorBrush GetDisabledBackground(DependencyObject element)
          => (SolidColorBrush)element.GetValue(DisabledBackgroundProperty);
   }
}
