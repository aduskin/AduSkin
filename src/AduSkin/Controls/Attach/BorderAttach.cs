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
            "BorderBrush", typeof(SolidColorBrush), typeof(BorderAttach));

      public static void SetBorderBrush(DependencyObject element, SolidColorBrush value)
          => element.SetValue(BorderBrushProperty, value);

      public static SolidColorBrush GetBorderBrush(DependencyObject element)
          => (SolidColorBrush)element.GetValue(BorderBrushProperty);

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
      /// 边框圆角
      /// </summary>
      public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached(
         "CornerRadius", typeof(CornerRadius), typeof(BorderAttach));

      public static void SetCornerRadius(DependencyObject element, CornerRadius value)
          => element.SetValue(CornerRadiusProperty, value);

      public static CornerRadius GetSetCornerRadius(DependencyObject element)
          => (CornerRadius)element.GetValue(BorderThicknessProperty);
   }
}
