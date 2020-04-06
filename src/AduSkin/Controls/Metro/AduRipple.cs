using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AduSkin.Controls.Metro
{
    [TemplateVisualState(GroupName = "CommonStates", Name = TemplateStateNormal)]
    [TemplateVisualState(GroupName = "CommonStates", Name = TemplateStateMousePressed)]
    [TemplateVisualState(GroupName = "CommonStates", Name = TemplateStateMouseOut)]
    public class AduRipple : ContentControl
    {
        public const string TemplateStateNormal = "Normal";
        public const string TemplateStateMousePressed = "MousePressed";
        public const string TemplateStateMouseOut = "MouseOut";

        private static readonly HashSet<AduRipple> PressedInstances = new HashSet<AduRipple>();

        static AduRipple()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AduRipple), new FrameworkPropertyMetadata(typeof(AduRipple)));

            EventManager.RegisterClassHandler(typeof(ContentControl), Mouse.PreviewMouseUpEvent, new MouseButtonEventHandler(MouseButtonEventHandler), true);
            EventManager.RegisterClassHandler(typeof(ContentControl), Mouse.MouseMoveEvent, new MouseEventHandler(MouseMoveEventHandler), true);
            EventManager.RegisterClassHandler(typeof(Popup), Mouse.PreviewMouseUpEvent, new MouseButtonEventHandler(MouseButtonEventHandler), true);
            EventManager.RegisterClassHandler(typeof(Popup), Mouse.MouseMoveEvent, new MouseEventHandler(MouseMoveEventHandler), true);
        }

        public AduRipple()
        {
            SizeChanged += OnSizeChanged;
        }

        private static void MouseButtonEventHandler(object sender, MouseButtonEventArgs e)
        {
            foreach (var AduRipple in PressedInstances)
            {
                // adjust the transition scale time according to the current animated scale
                var scaleTrans = AduRipple.Template.FindName("ScaleTransform", AduRipple) as ScaleTransform;
                if (scaleTrans != null)
                {
                    double currentScale = scaleTrans.ScaleX;
                    var newTime = TimeSpan.FromMilliseconds(300 * (1.0 - currentScale));

                    // change the scale animation according to the current scale
                    var scaleXKeyFrame = AduRipple.Template.FindName("MousePressedToNormalScaleXKeyFrame", AduRipple) as EasingDoubleKeyFrame;
                    if (scaleXKeyFrame != null)
                    {
                        scaleXKeyFrame.KeyTime = KeyTime.FromTimeSpan(newTime);
                    }
                    var scaleYKeyFrame = AduRipple.Template.FindName("MousePressedToNormalScaleYKeyFrame", AduRipple) as EasingDoubleKeyFrame;
                    if (scaleYKeyFrame != null)
                    {
                        scaleYKeyFrame.KeyTime = KeyTime.FromTimeSpan(newTime);
                    }
                }

                VisualStateManager.GoToState(AduRipple, TemplateStateNormal, true);
            }
            PressedInstances.Clear();
        }

        private static void MouseMoveEventHandler(object sender, MouseEventArgs e)
        {
            foreach (var AduRipple in PressedInstances.ToList())
            {
                var relativePosition = Mouse.GetPosition(AduRipple);
                if (relativePosition.X < 0
                    || relativePosition.Y < 0
                    || relativePosition.X >= AduRipple.ActualWidth
                    || relativePosition.Y >= AduRipple.ActualHeight)

                {
                    VisualStateManager.GoToState(AduRipple, TemplateStateMouseOut, true);
                    PressedInstances.Remove(AduRipple);
                }
            }
        }

        public static readonly DependencyProperty FeedbackProperty = DependencyProperty.Register(
            nameof(Feedback), typeof(Brush), typeof(AduRipple), new PropertyMetadata(default(Brush)));

        public Brush Feedback
        {
            get { return (Brush)GetValue(FeedbackProperty); }
            set { SetValue(FeedbackProperty, value); }
        }

        private static readonly DependencyPropertyKey RippleSizePropertyKey =
            DependencyProperty.RegisterReadOnly(
                "RippleSize", typeof(double), typeof(AduRipple),
                new PropertyMetadata(default(double)));

        public static readonly DependencyProperty RippleSizeProperty =
            RippleSizePropertyKey.DependencyProperty;

        public double RippleSize
        {
            get { return (double)GetValue(RippleSizeProperty); }
            private set { SetValue(RippleSizePropertyKey, value); }
        }

        private static readonly DependencyPropertyKey RippleXPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "RippleX", typeof(double), typeof(AduRipple),
                new PropertyMetadata(default(double)));

        public static readonly DependencyProperty RippleXProperty =
            RippleXPropertyKey.DependencyProperty;

        public double RippleX
        {
            get { return (double)GetValue(RippleXProperty); }
            private set { SetValue(RippleXPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey RippleYPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "RippleY", typeof(double), typeof(AduRipple),
                new PropertyMetadata(default(double)));

        public static readonly DependencyProperty RippleYProperty =
            RippleYPropertyKey.DependencyProperty;

        public double RippleY
        {
            get { return (double)GetValue(RippleYProperty); }
            private set { SetValue(RippleYPropertyKey, value); }
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
         if (AduRippleAssist.GetIsCentered(this))
         {
            var innerContent = (Content as FrameworkElement);

            if (innerContent != null)
            {
               var position = innerContent.TransformToAncestor(this)
                   .Transform(new Point(0, 0));

               if (FlowDirection == FlowDirection.RightToLeft)
                  RippleX = position.X - innerContent.ActualWidth / 2 - RippleSize / 2;
               else
                  RippleX = position.X + innerContent.ActualWidth / 2 - RippleSize / 2;
               RippleY = position.Y + innerContent.ActualHeight / 2 - RippleSize / 2;
            }
            else
            {
               RippleX = ActualWidth / 2 - RippleSize / 2;
               RippleY = ActualHeight / 2 - RippleSize / 2;
            }
         }
         else
         {
            var point = e.GetPosition(this);
            RippleX = point.X - RippleSize / 2;
            RippleY = point.Y - RippleSize / 2;
         }

         if (!AduRippleAssist.GetIsDisabled(this))
         {
            VisualStateManager.GoToState(this, TemplateStateNormal, false);
            VisualStateManager.GoToState(this, TemplateStateMousePressed, true);
            PressedInstances.Add(this);
         }

         base.OnPreviewMouseLeftButtonDown(e);
      }

        private static readonly DependencyPropertyKey AduRippleSizePropertyKey =
            DependencyProperty.RegisterReadOnly(
                "AduRippleSize", typeof(double), typeof(AduRipple),
                new PropertyMetadata(default(double)));

        public static readonly DependencyProperty AduRippleSizeProperty =
            AduRippleSizePropertyKey.DependencyProperty;

        public double AduRippleSize
        {
            get { return (double)GetValue(AduRippleSizeProperty); }
            private set { SetValue(AduRippleSizePropertyKey, value); }
        }

        private static readonly DependencyPropertyKey AduRippleXPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "AduRippleX", typeof(double), typeof(AduRipple),
                new PropertyMetadata(default(double)));

        public static readonly DependencyProperty AduRippleXProperty =
            AduRippleXPropertyKey.DependencyProperty;

        public double AduRippleX
        {
            get { return (double)GetValue(AduRippleXProperty); }
            private set { SetValue(AduRippleXPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey AduRippleYPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "AduRippleY", typeof(double), typeof(AduRipple),
                new PropertyMetadata(default(double)));

        public static readonly DependencyProperty AduRippleYProperty =
            AduRippleYPropertyKey.DependencyProperty;

        public double AduRippleY
        {
            get { return (double)GetValue(AduRippleYProperty); }
            private set { SetValue(AduRippleYPropertyKey, value); }
        }

        /// <summary>
        ///   The DependencyProperty for the RecognizesAccessKey property. 
        ///   Default Value: false 
        /// </summary> 
        public static readonly DependencyProperty RecognizesAccessKeyProperty =
            DependencyProperty.Register(
                nameof(RecognizesAccessKey), typeof(bool), typeof(AduRipple),
                new PropertyMetadata(default(bool)));

        /// <summary> 
        ///   Determine if AduRipple should use AccessText in its style
        /// </summary> 
        public bool RecognizesAccessKey
        {
            get { return (bool)GetValue(RecognizesAccessKeyProperty); }
            set { SetValue(RecognizesAccessKeyProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            VisualStateManager.GoToState(this, TemplateStateNormal, false);
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            var innerContent = (Content as FrameworkElement);

            double width, height;

            if (AduRippleAssist.GetIsCentered(this) && innerContent != null)
            {
                width = innerContent.ActualWidth;
                height = innerContent.ActualHeight;
            }
            else
            {
                width = sizeChangedEventArgs.NewSize.Width;
                height = sizeChangedEventArgs.NewSize.Height;
            }

            var radius = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2));

            AduRippleSize = 2 * radius * AduRippleAssist.GetRippleSizeMultiplier(this);
        }
    }
}
