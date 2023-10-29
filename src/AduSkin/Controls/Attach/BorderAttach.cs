using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace AduSkin.Controls.Attach
{
   public class BorderAttach
   {
      /// <summary>
      /// 边框色
      /// </summary>
      public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.RegisterAttached(
            "BorderBrush", typeof(Brush), typeof(BorderAttach));

      public static void SetBorderBrush(DependencyObject element, Brush value)
          => element.SetValue(BorderBrushProperty, value);

      public static Brush GetBorderBrush(DependencyObject element)
          => (Brush)element.GetValue(BorderBrushProperty);

      /// <summary>
      /// 选中边框色
      /// </summary>
      public static readonly DependencyProperty SelectedBorderBrushProperty = DependencyProperty.RegisterAttached(
            "SelectedBorderBrush", typeof(Brush), typeof(BorderAttach));

      public static void SetSelectedBorderBrush(DependencyObject element, Brush value)
          => element.SetValue(SelectedBorderBrushProperty, value);

      public static Brush GetSelectedBorderBrush(DependencyObject element)
          => (Brush)element.GetValue(SelectedBorderBrushProperty);

      /// <summary>
      /// 边框厚度
      /// </summary>
      public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.RegisterAttached(
            "BorderThickness", typeof(Thickness), typeof(BorderAttach));

      public static void SetBorderThickness(DependencyObject element, Thickness value)
          => element.SetValue(BorderThicknessProperty, value);

      public static Thickness GetBorderThickness(DependencyObject element)
          => (Thickness)element.GetValue(BorderThicknessProperty);

      /// <summary>
      /// 选中边框厚度
      /// </summary>
      public static readonly DependencyProperty SelectedBorderThicknessProperty = DependencyProperty.RegisterAttached(
            "SelectedBorderThickness", typeof(Thickness), typeof(BorderAttach));

      public static void SetSelectedBorderThickness(DependencyObject element, Thickness value)
          => element.SetValue(SelectedBorderThicknessProperty, value);

      public static Thickness GetSelectedBorderThickness(DependencyObject element)
          => (Thickness)element.GetValue(SelectedBorderThicknessProperty);

      /// <summary>
      /// 边框圆角
      /// </summary>
      public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached(
         "CornerRadius", typeof(CornerRadius), typeof(BorderAttach));

      public static void SetCornerRadius(DependencyObject element, CornerRadius value)
          => element.SetValue(CornerRadiusProperty, value);

      public static CornerRadius GetSetCornerRadius(DependencyObject element)
          => (CornerRadius)element.GetValue(BorderThicknessProperty);

      /// <summary>
      /// 选中边框圆角
      /// </summary>
      public static readonly DependencyProperty SelectedCornerRadiusProperty = DependencyProperty.RegisterAttached(
         "SelectedCornerRadius", typeof(CornerRadius), typeof(BorderAttach));

      public static void SetSelectedCornerRadius(DependencyObject element, CornerRadius value)
          => element.SetValue(SelectedCornerRadiusProperty, value);

      public static CornerRadius GetSetSelectedCornerRadius(DependencyObject element)
          => (CornerRadius)element.GetValue(BorderThicknessProperty);
   }
}
