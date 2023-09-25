using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace AduSkin.Controls.Attach
{
   public class PathBrushAttach
   {
      /// <summary>
      /// 默认颜色
      /// </summary>
      public static readonly DependencyProperty NormalPathColorProperty = DependencyProperty.RegisterAttached(
            "NormalPathColor", typeof(SolidColorBrush), typeof(PathBrushAttach), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetNormalPathColor(DependencyObject element, SolidColorBrush value)
          => element.SetValue(NormalPathColorProperty, value);

      public static SolidColorBrush GetNormalPathColor(DependencyObject element)
          => (SolidColorBrush)element.GetValue(NormalPathColorProperty);

      /// <summary>
      /// 选中颜色
      /// </summary>
      public static readonly DependencyProperty SelectedPathColorProperty = DependencyProperty.RegisterAttached(
            "SelectedPathColor", typeof(SolidColorBrush), typeof(PathBrushAttach), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetSelectedPathColor(DependencyObject element, SolidColorBrush value)
          => element.SetValue(SelectedPathColorProperty, value);

      public static SolidColorBrush GetSelectedPathColor(DependencyObject element)
          => (SolidColorBrush)element.GetValue(SelectedPathColorProperty);

      /// <summary>
      /// 高亮颜色
      /// </summary>
      public static readonly DependencyProperty HighlightPathColorProperty = DependencyProperty.RegisterAttached(
            "HighlightPathColor", typeof(SolidColorBrush), typeof(PathBrushAttach), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetHighlightPathColor(DependencyObject element, SolidColorBrush value)
          => element.SetValue(HighlightPathColorProperty, value);

      public static SolidColorBrush GetHighlightPathColor(DependencyObject element)
          => (SolidColorBrush)element.GetValue(HighlightPathColorProperty);

      /// <summary>
      /// 鼠标悬浮颜色
      /// </summary>
      public static readonly DependencyProperty MouseOverPathColorProperty = DependencyProperty.RegisterAttached(
            "MouseOverPathColor", typeof(SolidColorBrush), typeof(PathBrushAttach), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetMouseOverPathColor(DependencyObject element, SolidColorBrush value)
          => element.SetValue(MouseOverPathColorProperty, value);

      public static SolidColorBrush GetMouseOverPathColor(DependencyObject element)
          => (SolidColorBrush)element.GetValue(MouseOverPathColorProperty);

      /// <summary>
      /// 鼠标按下颜色
      /// </summary>
      public static readonly DependencyProperty PressedPathColorProperty = DependencyProperty.RegisterAttached(
            "PressedPathColor", typeof(SolidColorBrush), typeof(PathBrushAttach), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetPressedPathColor(DependencyObject element, SolidColorBrush value)
          => element.SetValue(PressedPathColorProperty, value);

      public static SolidColorBrush GetPressedPathColor(DependencyObject element)
          => (SolidColorBrush)element.GetValue(PressedPathColorProperty);

      /// <summary>
      /// 禁用颜色
      /// </summary>
      public static readonly DependencyProperty DisabledPathColorProperty = DependencyProperty.RegisterAttached(
            "DisabledPathColor", typeof(SolidColorBrush), typeof(PathBrushAttach), new PropertyMetadata(default(SolidColorBrush)));

      public static void SetDisabledPathColor(DependencyObject element, SolidColorBrush value)
          => element.SetValue(DisabledPathColorProperty, value);

      public static SolidColorBrush GetDisabledPathColor(DependencyObject element)
          => (SolidColorBrush)element.GetValue(DisabledPathColorProperty);
   }
}
