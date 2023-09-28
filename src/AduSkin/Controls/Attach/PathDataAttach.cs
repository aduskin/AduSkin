using System.Windows;
using System.Windows.Media;

namespace AduSkin.Controls.Attach
{
    public class PathDataAttach
    {
      /// <summary>
      /// 默认图标
      /// </summary>
        public static readonly DependencyProperty PathDataProperty = DependencyProperty.RegisterAttached(
            "PathData", typeof(Geometry), typeof(PathDataAttach), new PropertyMetadata(default(Geometry)));

        public static void SetPathData(DependencyObject element, Geometry value)
            => element.SetValue(PathDataProperty, value);

        public static Geometry GetPathData(DependencyObject element) 
            => (Geometry) element.GetValue(PathDataProperty);

      /// <summary>
      /// 选中图标
      /// </summary>
        public static readonly DependencyProperty SelectedPathDataProperty = DependencyProperty.RegisterAttached(
            "SelectedPathData", typeof(Geometry), typeof(PathDataAttach), new PropertyMetadata(default(Geometry)));

        public static void SetSelectedPathData(DependencyObject element, Geometry value)
            => element.SetValue(SelectedPathDataProperty, value);

        public static Geometry GetSelectedPathData(DependencyObject element) 
            => (Geometry) element.GetValue(SelectedPathDataProperty);

      /// <summary>
      /// 图标宽度
      /// </summary>
        public static readonly DependencyProperty WidthProperty = DependencyProperty.RegisterAttached(
            "Width", typeof(double), typeof(PathDataAttach), new PropertyMetadata(double.NaN));

        public static void SetWidth(DependencyObject element, double value)
            => element.SetValue(WidthProperty, value);

        public static double GetWidth(DependencyObject element)
            => (double) element.GetValue(WidthProperty);

      /// <summary>
      /// 图标边距
      /// </summary>
        public static readonly DependencyProperty MarginProperty = DependencyProperty.RegisterAttached(
            "Margin", typeof(Thickness), typeof(PathDataAttach));

        public static void SetMargin(DependencyObject element, Thickness value)
            => element.SetValue(MarginProperty, value);

        public static Thickness GetMargin(DependencyObject element)
            => (Thickness) element.GetValue(MarginProperty);

      /// <summary>
      /// 图标可见性
      /// </summary>
      public static readonly DependencyProperty VisibilityProperty = DependencyProperty.RegisterAttached(
          "Visibility", typeof(Visibility), typeof(PathDataAttach), new PropertyMetadata(default(Visibility)));

      public static void SetVisibility(DependencyObject element, Visibility value)
          => element.SetValue(VisibilityProperty, value);

      public static Visibility GetVisibility(DependencyObject element)
          => (Visibility)element.GetValue(VisibilityProperty);
   }
}