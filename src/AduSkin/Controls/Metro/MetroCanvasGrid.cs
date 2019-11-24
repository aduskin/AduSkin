using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class MetroCanvasGrid : ContentControl
    {
        public static readonly DependencyProperty ViewportProperty = ElementBase.Property<MetroCanvasGrid, Rect>("ViewportProperty");
        public Rect Viewport { get { return (Rect)GetValue(ViewportProperty); } set { SetValue(ViewportProperty, value); } }

        public static readonly DependencyProperty GridOpacityProperty = ElementBase.Property<MetroCanvasGrid, double>("GridOpacityProperty");
        public static readonly DependencyProperty GridSizeProperty = ElementBase.Property<MetroCanvasGrid, double>("GridSizeProperty");
        public static readonly DependencyProperty CornerRadiusProperty = ElementBase.Property<MetroCanvasGrid, CornerRadius>("CornerRadiusProperty");

        public double GridOpacity { get { return (double)GetValue(GridOpacityProperty); } set { SetValue(GridOpacityProperty, value); } }
        public CornerRadius CornerRadius { get { return (CornerRadius)GetValue(CornerRadiusProperty); } set { SetValue(CornerRadiusProperty, value); } }

        public bool IsApplyTheme { get; set; } //= true;

        public MetroCanvasGrid()
        {
            Utility.Refresh(this);
        }

        static MetroCanvasGrid()
        {
            ElementBase.DefaultStyle<MetroCanvasGrid>(DefaultStyleKeyProperty);
        }
    }
}