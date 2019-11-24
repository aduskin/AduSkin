using AduSkin.Utility.Element;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public enum ProgressBarState
    {
        None,
        Error,
        Wait
    }

    public class MetroProgressBar : ProgressBar
    {
        public static readonly DependencyProperty ProgressBarStateProperty = ElementBase.Property<MetroProgressBar, ProgressBarState>("ProgressBarStateProperty");
        public static readonly DependencyProperty CornerRadiusProperty = ElementBase.Property<MetroProgressBar, CornerRadius>("CornerRadiusProperty");
        public static readonly DependencyProperty TitleProperty = ElementBase.Property<MetroProgressBar, string>("TitleProperty");
        public static readonly DependencyProperty HintProperty = ElementBase.Property<MetroProgressBar, string>("HintProperty");
        public static readonly DependencyProperty ProgressBarHeightProperty = ElementBase.Property<MetroProgressBar, double>("ProgressBarHeightProperty");
        public static readonly DependencyProperty TextHorizontalAlignmentProperty = ElementBase.Property<MetroProgressBar, HorizontalAlignment>("TextHorizontalAlignmentProperty");

        public ProgressBarState ProgressBarState { get { return (ProgressBarState)GetValue(ProgressBarStateProperty); } set { SetValue(ProgressBarStateProperty, value); } }
        public CornerRadius CornerRadius { get { return (CornerRadius)GetValue(CornerRadiusProperty); } set { SetValue(CornerRadiusProperty, value); } }
        public string Title { get { return (string)GetValue(TitleProperty); } set { SetValue(TitleProperty, value); } }
        public string Hint { get { return (string)GetValue(HintProperty); } set { SetValue(HintProperty, value); } }
        public double ProgressBarHeight { get { return (double)GetValue(ProgressBarHeightProperty); } set { SetValue(ProgressBarHeightProperty, value); } }
        public HorizontalAlignment TextHorizontalAlignment { get { return (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty); } set { SetValue(TextHorizontalAlignmentProperty, value); } }

        public MetroProgressBar()
        {
            Utility.Refresh(this);
            ValueChanged += delegate
            {
                if (Hint == null||Hint.EndsWith(" %"))
                {
                    Hint = ((int)(Value / Maximum * 100)).ToString() + " %";
                }
            };
        }

        static MetroProgressBar()
        {
            ElementBase.DefaultStyle<MetroProgressBar>(DefaultStyleKeyProperty);
        }
    }
}