using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{

    public class AduSlider : Slider
    {
        public AduSlider()
        {
            Utility.Refresh(this);
        }

        static AduSlider()
        {
            ElementBase.DefaultStyle<AduSlider>(DefaultStyleKeyProperty);
        }

        #region AduSkin
        public Geometry Icon
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Geometry), typeof(AduSlider));

        public double IconWidth
        {
            get { return (double)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register("IconWidth", typeof(double), typeof(AduSlider), new PropertyMetadata(20.0));

        public double IconHeight
        {
            get { return (double)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }

        public static readonly DependencyProperty IconHeightProperty =
            DependencyProperty.Register("IconHeight", typeof(double), typeof(AduSlider), new PropertyMetadata(20.0));

        #endregion
    }
}