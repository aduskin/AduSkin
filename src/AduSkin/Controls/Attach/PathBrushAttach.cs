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
            "NormalPathColor", typeof(Brush), typeof(PathBrushAttach), new PropertyMetadata(default(Brush)));

      public static void SetNormalPathColor(DependencyObject element, Brush value)
          => element.SetValue(NormalPathColorProperty, value);

      public static Brush GetNormalPathColor(DependencyObject element)
          => (Brush)element.GetValue(NormalPathColorProperty);

      /// <summary>
      /// 选中颜色
      /// </summary>
      public static readonly DependencyProperty SelectedPathColorProperty = DependencyProperty.RegisterAttached(
            "SelectedPathColor", typeof(Brush), typeof(PathBrushAttach), new PropertyMetadata(default(Brush)));

      public static void SetSelectedPathColor(DependencyObject element, Brush value)
          => element.SetValue(SelectedPathColorProperty, value);

      public static Brush GetSelectedPathColor(DependencyObject element)
          => (Brush)element.GetValue(SelectedPathColorProperty);

      /// <summary>
      /// 高亮颜色
      /// </summary>
      public static readonly DependencyProperty HighlightPathColorProperty = DependencyProperty.RegisterAttached(
            "HighlightPathColor", typeof(Brush), typeof(PathBrushAttach), new PropertyMetadata(default(Brush)));

      public static void SetHighlightPathColor(DependencyObject element, Brush value)
          => element.SetValue(HighlightPathColorProperty, value);

      public static Brush GetHighlightPathColor(DependencyObject element)
          => (Brush)element.GetValue(HighlightPathColorProperty);

      /// <summary>
      /// 鼠标悬浮颜色
      /// </summary>
      public static readonly DependencyProperty MouseOverPathColorProperty = DependencyProperty.RegisterAttached(
            "MouseOverPathColor", typeof(Brush), typeof(PathBrushAttach), new PropertyMetadata(default(Brush)));

      public static void SetMouseOverPathColor(DependencyObject element, Brush value)
          => element.SetValue(MouseOverPathColorProperty, value);

      public static Brush GetMouseOverPathColor(DependencyObject element)
          => (Brush)element.GetValue(MouseOverPathColorProperty);

      /// <summary>
      /// 鼠标按下颜色
      /// </summary>
      public static readonly DependencyProperty PressedPathColorProperty = DependencyProperty.RegisterAttached(
            "PressedPathColor", typeof(Brush), typeof(PathBrushAttach), new PropertyMetadata(default(Brush)));

      public static void SetPressedPathColor(DependencyObject element, Brush value)
          => element.SetValue(PressedPathColorProperty, value);

      public static Brush GetPressedPathColor(DependencyObject element)
          => (Brush)element.GetValue(PressedPathColorProperty);

      /// <summary>
      /// 禁用颜色
      /// </summary>
      public static readonly DependencyProperty DisabledPathColorProperty = DependencyProperty.RegisterAttached(
            "DisabledPathColor", typeof(Brush), typeof(PathBrushAttach), new PropertyMetadata(default(Brush)));

      public static void SetDisabledPathColor(DependencyObject element, Brush value)
          => element.SetValue(DisabledPathColorProperty, value);

      public static Brush GetDisabledPathColor(DependencyObject element)
          => (Brush)element.GetValue(DisabledPathColorProperty);
   }
}
