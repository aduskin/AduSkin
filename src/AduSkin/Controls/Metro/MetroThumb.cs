using AduSkin.Utility.Element;
using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace AduSkin.Controls.Metro
{
    public class MetroThumb : Thumb
    {
        public double OldX { get; set; } //= 0.0;
        public double OldY { get; set; } //= 0.0;
        public double OffsetX { get; set; } //= 0.0;
        public double OffsetY { get; set; } //= 0.0;

        public static readonly DependencyProperty XProperty = ElementBase.Property<MetroThumb, double>("XProperty", -1);
        public static readonly DependencyProperty YProperty = ElementBase.Property<MetroThumb, double>("YProperty", -1);

        public double X { get { return (double)GetValue(XProperty) - OffsetX; } set { SetValue(XProperty, value + OffsetX); Change(); } }
        public double Y { get { return (double)GetValue(YProperty) - OffsetY; } set { SetValue(YProperty, value + OffsetY); Change(); } }

        public event EventHandler ValueChange;

        public MetroThumb()
        {
            Focusable = true;
            FocusVisualStyle = null;

            Loaded += delegate
            {
                X = (double)GetValue(XProperty) == -1 ? 0 : X;
                Y = (double)GetValue(YProperty) == -1 ? 0 : Y;
            };
            DragStarted += delegate (object sender, DragStartedEventArgs e)
            {
                Focus();

                OldX = e.HorizontalOffset;
                OldY = e.VerticalOffset;

                X = OldX;
                Y = OldY;
            };
            DragDelta += delegate (object sender, DragDeltaEventArgs e)
            {
                double x = OldX + e.HorizontalChange;
                double y = OldY + e.VerticalChange;

                if (x < 0) X = 0;
                else if (x > ActualWidth) X = ActualWidth;
                else X = x;

                if (y < 0) Y = 0;
                else if (y > ActualHeight) Y = ActualHeight;
                else Y = y;
            };
        }

        public double XPercent { get { return X / ActualWidth; } set { X = ActualWidth * value; } }
        public double YPercent { get { return Y / ActualHeight; } set { Y = ActualHeight * value; } }

        void Change()
        {
            if (ValueChange != null) { ValueChange(this, null); }
        }
    }
}