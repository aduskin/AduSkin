using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AduSkin.Controls.Metro
{
    public class AduFlatDatePicker : DatePicker
    {
        private Popup PART_Popup;
        private UIElement child;

        static AduFlatDatePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AduFlatDatePicker), new FrameworkPropertyMetadata(typeof(AduFlatDatePicker)));
        }

        #region 依赖属性
        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly"
            , typeof(bool), typeof(AduFlatDatePicker));
        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.PART_Popup = GetTemplateChild("PART_Popup") as Popup;

            child = this.PART_Popup.Child;

            if (child == null)
            {
                return;
            }

            child.RenderTransformOrigin = new Point(0.5, 0);
            ScaleTransform scaleTransform = new ScaleTransform();
            //scaleTransform.ScaleY = 0.9;
            TransformGroup transformGroup = new TransformGroup();
            transformGroup.Children.Add(scaleTransform);
            child.RenderTransform = transformGroup;

            this.PART_Popup.Opened += PART_Popup_Opened;
            this.PART_Popup.Closed += PART_Popup_Closed;
        }

        private void PART_Popup_Closed(object sender, EventArgs e)
        {
            this.StopAnimation(child);
        }

        private void PART_Popup_Opened(object sender, EventArgs e)
        {
            this.BeginAnimation(child);
        }

        private void BeginAnimation(UIElement element)
        {
            Storyboard storyBoard_Open = new Storyboard();
            DoubleAnimationUsingKeyFrames kfs = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame k1 = new EasingDoubleKeyFrame();
            k1.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0));
            k1.Value = 0.9;

            EasingDoubleKeyFrame k2 = new EasingDoubleKeyFrame();
            k2.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200));
            k2.Value = 1;

            kfs.KeyFrames.Add(k1);
            kfs.KeyFrames.Add(k2);
            storyBoard_Open.Children.Add(kfs);
            Storyboard.SetTarget(kfs, element);
            Storyboard.SetTargetProperty(kfs, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)"));
            storyBoard_Open.Begin();

            Storyboard storyBoard_Open1 = new Storyboard();
            DoubleAnimationUsingKeyFrames kfs2 = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame k3 = new EasingDoubleKeyFrame();
            k3.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0));
            k3.Value = 0;

            EasingDoubleKeyFrame k4 = new EasingDoubleKeyFrame();
            k4.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200));
            k4.Value = 1;

            kfs2.KeyFrames.Add(k3);
            kfs2.KeyFrames.Add(k4);
            storyBoard_Open.Children.Add(kfs2);
            Storyboard.SetTarget(kfs2, element);
            Storyboard.SetTargetProperty(kfs, new PropertyPath("(UIElement.Opacity)"));

            storyBoard_Open1.Begin();
        }

        private void StopAnimation(UIElement element)
        {
            Storyboard storyBoard_Open = new Storyboard();
            DoubleAnimationUsingKeyFrames kfs = new DoubleAnimationUsingKeyFrames();

            EasingDoubleKeyFrame k1 = new EasingDoubleKeyFrame();
            k1.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0));
            k1.Value = 1;

            EasingDoubleKeyFrame k2 = new EasingDoubleKeyFrame();
            k2.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200));
            k2.Value = 0;

            kfs.KeyFrames.Add(k1);
            kfs.KeyFrames.Add(k2);
            storyBoard_Open.Children.Add(kfs);
            Storyboard.SetTarget(kfs, element);
            Storyboard.SetTargetProperty(kfs, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)"));

            storyBoard_Open.Begin();
        }
    }
}
