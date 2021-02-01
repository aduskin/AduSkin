using System.Windows;
using System.Windows.Media;

namespace AduSkin.Controls.Attach
{
    public class IconElement
    {
        public static readonly DependencyProperty PathDataProperty = DependencyProperty.RegisterAttached(
            "PathData", typeof(Geometry), typeof(IconElement), new PropertyMetadata(default(Geometry)));

        public static void SetPathData(DependencyObject element, Geometry value)
            => element.SetValue(PathDataProperty, value);

        public static Geometry GetPathData(DependencyObject element) 
            => (Geometry) element.GetValue(PathDataProperty);

        public static readonly DependencyProperty SelectedPathDataProperty = DependencyProperty.RegisterAttached(
            "SelectedPathData", typeof(Geometry), typeof(IconElement), new PropertyMetadata(default(Geometry)));

        public static void SetSelectedPathData(DependencyObject element, Geometry value)
            => element.SetValue(SelectedPathDataProperty, value);

        public static Geometry GetSelectedPathData(DependencyObject element) 
            => (Geometry) element.GetValue(SelectedPathDataProperty);

        public static readonly DependencyProperty WidthProperty = DependencyProperty.RegisterAttached(
            "Width", typeof(double), typeof(IconElement), new PropertyMetadata(double.NaN));

        public static void SetWidth(DependencyObject element, double value)
            => element.SetValue(WidthProperty, value);

        public static double GetWidth(DependencyObject element)
            => (double) element.GetValue(WidthProperty);

        public static readonly DependencyProperty MarginProperty = DependencyProperty.RegisterAttached(
            "Margin", typeof(Thickness), typeof(IconElement));

        public static void SetMargin(DependencyObject element, Thickness value)
            => element.SetValue(MarginProperty, value);

        public static Thickness GetMargin(DependencyObject element)
            => (Thickness) element.GetValue(MarginProperty);
    }
}