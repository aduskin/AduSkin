using System.Windows;
using System.Windows.Media;

namespace AduSkin.Controls.Attach
{
   public class HeaderAttach
   {
      /// <summary>
      /// 隐藏/显示
      /// </summary>
      public static readonly DependencyProperty VisibleProperty = DependencyProperty.RegisterAttached(
            "Visible", typeof(Visibility), typeof(HeaderAttach), new PropertyMetadata(default(Visibility)));
      public static void SetVisible(DependencyObject element, Visibility value)
          => element.SetValue(VisibleProperty, value);
      public static Visibility GetVisible(DependencyObject element)
          => (Visibility)element.GetValue(VisibleProperty);

      /// <summary>
      /// 高度
      /// </summary>
      public static readonly DependencyProperty HeightProperty = DependencyProperty.RegisterAttached(
            "Height", typeof(double), typeof(HeaderAttach), new PropertyMetadata(default(double)));
      public static void SetHeight(DependencyObject element, double value)
          => element.SetValue(HeightProperty, value);
      public static double GetHeight(DependencyObject element)
          => (double)element.GetValue(HeightProperty);

      /// <summary>
      /// 宽度
      /// </summary>
      public static readonly DependencyProperty WidthProperty = DependencyProperty.RegisterAttached(
            "Width", typeof(double), typeof(HeaderAttach), new PropertyMetadata(default(double)));
      public static void SetWidth(DependencyObject element, double value)
          => element.SetValue(WidthProperty, value);
      public static double GetWidth(DependencyObject element)
          => (double)element.GetValue(WidthProperty);

      /// <summary>
      /// 头部背景颜色
      /// </summary>
      public static readonly DependencyProperty BackgroundProperty = DependencyProperty.RegisterAttached(
            "Background", typeof(Brush), typeof(HeaderAttach), new PropertyMetadata(default(Brush)));
      public static void SetBackground(DependencyObject element, Brush value)
          => element.SetValue(BackgroundProperty, value);
      public static Brush GetBackground(DependencyObject element)
          => (Brush)element.GetValue(BackgroundProperty);
   }
}
