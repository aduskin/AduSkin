using System.Windows;
using System.Windows.Media;

namespace AduSkin.Controls.Attach
{
   public class ElementBrushBase
   {
      /// <summary>
      /// 默认颜色
      /// </summary>
      public static readonly DependencyProperty NormalBrushProperty = DependencyProperty.RegisterAttached(
            "NormalBrush", typeof(SolidColorBrush), typeof(ElementBrushBase), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetNormalBrush(DependencyObject element, SolidColorBrush value)
          => element.SetValue(NormalBrushProperty, value);

      public static SolidColorBrush GetNormalBrush(DependencyObject element)
          => (SolidColorBrush)element.GetValue(NormalBrushProperty);

      /// <summary>
      /// 选中颜色
      /// </summary>
      public static readonly DependencyProperty SelectedBrushProperty = DependencyProperty.RegisterAttached(
            "SelectedBrush", typeof(SolidColorBrush), typeof(ElementBrushBase), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetSelectedBrush(DependencyObject element, SolidColorBrush value)
          => element.SetValue(SelectedBrushProperty, value);

      public static SolidColorBrush GetSelectedBrush(DependencyObject element)
          => (SolidColorBrush)element.GetValue(SelectedBrushProperty);

      /// <summary>
      /// 鼠标悬浮颜色
      /// </summary>
      public static readonly DependencyProperty MouseOverBrushProperty = DependencyProperty.RegisterAttached(
            "MouseOverBrush", typeof(SolidColorBrush), typeof(ElementBrushBase), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetMouseOverBrush(DependencyObject element, SolidColorBrush value)
          => element.SetValue(MouseOverBrushProperty, value);

      public static SolidColorBrush GetMouseOverBrush(DependencyObject element)
          => (SolidColorBrush)element.GetValue(MouseOverBrushProperty);

      /// <summary>
      /// 鼠标悬浮颜色
      /// </summary>
      public static readonly DependencyProperty PressedBrushProperty = DependencyProperty.RegisterAttached(
            "PressedBrush", typeof(SolidColorBrush), typeof(ElementBrushBase), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetPressedBrush(DependencyObject element, SolidColorBrush value)
          => element.SetValue(PressedBrushProperty, value);

      public static SolidColorBrush GetPressedBrush(DependencyObject element)
          => (SolidColorBrush)element.GetValue(PressedBrushProperty);

      /// <summary>
      /// 禁用颜色
      /// </summary>
      public static readonly DependencyProperty DisabledBrushProperty = DependencyProperty.RegisterAttached(
            "DisabledBrush", typeof(SolidColorBrush), typeof(ElementBrushBase), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetDisabledBrush(DependencyObject element, SolidColorBrush value)
          => element.SetValue(DisabledBrushProperty, value);

      public static SolidColorBrush GetDisabledBrush(DependencyObject element)
          => (SolidColorBrush)element.GetValue(DisabledBrushProperty);
   }
}
