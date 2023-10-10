using System.Windows;
using System.Windows.Media;

namespace AduSkin.Controls.Attach
{
   public class BackgroundAttach
   {
      /// <summary>
      /// Panel背景色
      /// Combox下拉、日期选择面板
      /// </summary>
      public static readonly DependencyProperty PanelBackgroundProperty = DependencyProperty.RegisterAttached(
            "PanelBackground", typeof(Brush), typeof(BackgroundAttach), new PropertyMetadata(default(Brush)));

      public static void SetPanelBackground(DependencyObject element, Brush value)
          => element.SetValue(PanelBackgroundProperty, value);

      public static Brush GetPanelBackground(DependencyObject element)
          => (Brush)element.GetValue(PanelBackgroundProperty);

      /// <summary>
      /// 默认颜色
      /// </summary>
      public static readonly DependencyProperty NormalBackgroundProperty = DependencyProperty.RegisterAttached(
            "NormalBackground", typeof(Brush), typeof(BackgroundAttach), new PropertyMetadata(default(Brush)));

      public static void SetNormalBackground(DependencyObject element, Brush value)
          => element.SetValue(NormalBackgroundProperty, value);

      public static Brush GetNormalBackground(DependencyObject element)
          => (Brush)element.GetValue(NormalBackgroundProperty);

      /// <summary>
      /// 高亮颜色
      /// </summary>
      public static readonly DependencyProperty HighlightBackgroundProperty = DependencyProperty.RegisterAttached(
            "HighlightBackground", typeof(Brush), typeof(BackgroundAttach), new PropertyMetadata(default(Brush)));

      public static void SetHighlightBackground(DependencyObject element, Brush value)
          => element.SetValue(HighlightBackgroundProperty, value);

      public static Brush GetHighlightBackground(DependencyObject element)
          => (Brush)element.GetValue(HighlightBackgroundProperty);

      /// <summary>
      /// 选中颜色
      /// </summary>
      public static readonly DependencyProperty SelectedBackgroundProperty = DependencyProperty.RegisterAttached(
            "SelectedBackground", typeof(Brush), typeof(BackgroundAttach), new PropertyMetadata(default(Brush)));

      public static void SetSelectedBackground(DependencyObject element, Brush value)
          => element.SetValue(SelectedBackgroundProperty, value);

      public static Brush GetSelectedBackground(DependencyObject element)
          => (Brush)element.GetValue(SelectedBackgroundProperty);

      /// <summary>
      /// 鼠标悬浮颜色
      /// </summary>
      public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.RegisterAttached(
            "MouseOverBackground", typeof(Brush), typeof(BackgroundAttach), new PropertyMetadata(default(Brush)));

      public static void SetMouseOverBackground(DependencyObject element, Brush value)
          => element.SetValue(MouseOverBackgroundProperty, value);

      public static Brush GetMouseOverBackground(DependencyObject element)
          => (Brush)element.GetValue(MouseOverBackgroundProperty);

      /// <summary>
      /// 鼠标悬浮颜色
      /// </summary>
      public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.RegisterAttached(
            "PressedBackground", typeof(Brush), typeof(BackgroundAttach), new PropertyMetadata(default(Brush)));

      public static void SetPressedBackground(DependencyObject element, Brush value)
          => element.SetValue(PressedBackgroundProperty, value);

      public static Brush GetPressedBackground(DependencyObject element)
          => (Brush)element.GetValue(PressedBackgroundProperty);

      /// <summary>
      /// 禁用颜色
      /// </summary>
      public static readonly DependencyProperty DisabledBackgroundProperty = DependencyProperty.RegisterAttached(
            "DisabledBackground", typeof(Brush), typeof(BackgroundAttach), new PropertyMetadata(default(Brush)));

      public static void SetDisabledBackground(DependencyObject element, Brush value)
          => element.SetValue(DisabledBackgroundProperty, value);

      public static Brush GetDisabledBackground(DependencyObject element)
          => (Brush)element.GetValue(DisabledBackgroundProperty);
   }
}
