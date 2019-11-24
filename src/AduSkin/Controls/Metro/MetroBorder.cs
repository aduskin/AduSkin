using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class MetroBorder : Border
    {
        public static readonly DependencyProperty AutoCornerRadiusProperty = ElementBase.Property<MetroBorder, bool>("AutoCornerRadiusProperty");
        public bool AutoCornerRadius { get { return (bool)GetValue(AutoCornerRadiusProperty); } set { SetValue(AutoCornerRadiusProperty, value); } }
        public MetroBorder()
        {
            Loaded += delegate { SizeChang(); };
            SizeChanged += delegate { SizeChang(); };
        }

        void SizeChang()
        {
            if (AutoCornerRadius)
            {
                if (IsLoaded)
                {
                    CornerRadius = new CornerRadius(ActualWidth >= ActualHeight ? ActualHeight / 2 : ActualWidth / 2);
                }
            }
        }
    }
}