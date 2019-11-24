using AduSkin.Utility.Element;
using AduSkin.Utility.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
    public class MetroImage : ContentControl
    {
        public static readonly DependencyProperty SourceProperty = ElementBase.Property<MetroImage, ImageSource>("SourceProperty");
        public static readonly DependencyProperty StretchProperty = ElementBase.Property<MetroImage, Stretch>("StretchProperty");
        public static readonly DependencyProperty StretchDirectionProperty = ElementBase.Property<MetroImage, StretchDirection>("StretchDirectionProperty");
        public static readonly DependencyProperty ImageWidthProperty = ElementBase.Property<MetroImage, double>("ImageWidthProperty");
        public static readonly DependencyProperty ImageHeightProperty = ElementBase.Property<MetroImage, double>("ImageHeightProperty");
        public static readonly DependencyProperty ImageVerticalAlignmentProperty = ElementBase.Property<MetroImage, VerticalAlignment>("ImageVerticalAlignmentProperty");
        public static readonly DependencyProperty ImageHorizontalAlignmentProperty = ElementBase.Property<MetroImage, HorizontalAlignment>("ImageHorizontalAlignmentProperty");

        public ImageSource Source { get { return (ImageSource)GetValue(SourceProperty); } set { SetValue(SourceProperty, value); } }
        public Stretch Stretch { get { return (Stretch)GetValue(StretchProperty); } set { SetValue(StretchProperty, value); } }
        public StretchDirection StretchDirection { get { return (StretchDirection)GetValue(StretchDirectionProperty); } set { SetValue(StretchDirectionProperty, value); } }
        public double ImageWidth { get { return (double)GetValue(ImageWidthProperty); } set { SetValue(ImageWidthProperty, value); } }
        public double ImageHeight { get { return (double)GetValue(ImageHeightProperty); } set { SetValue(ImageHeightProperty, value); } }
        public VerticalAlignment ImageVerticalAlignment { get { return (VerticalAlignment)GetValue(ImageVerticalAlignmentProperty); } set { SetValue(ImageVerticalAlignmentProperty, value); } }
        public HorizontalAlignment ImageHorizontalAlignment { get { return (HorizontalAlignment)GetValue(ImageHorizontalAlignmentProperty); } set { SetValue(ImageHorizontalAlignmentProperty, value); } }

        static MetroImage()
        {
            ElementBase.DefaultStyle<MetroImage>(DefaultStyleKeyProperty);
        }

        public MetroImage()
        {

        }

        public MetroImage(ImageSource image)
        {
            Source = image;
        }

 
    }
}