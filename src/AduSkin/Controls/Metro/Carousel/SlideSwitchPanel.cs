using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AduSkin.Controls.Metro
{
    public class SlideSwitchPanel : Canvas
    {
        TranslateTransform translate = new TranslateTransform();
        private int ChildCount = 0;
         public double initWidth = 700;
         public double initHeight = 350;

        public SlideSwitchPanel()
        {
            this.RenderTransform = translate;
            this.Loaded += SlideSwitchPanel_Loaded;
        }

        private void SlideSwitchPanel_Loaded(object sender, RoutedEventArgs e)
        {
            this.ChildCount = this.InternalChildren.Count;
        }

        #region 依赖属性
        public static readonly DependencyProperty IndexProperty = DependencyProperty.Register("Index", 
            typeof(int), 
            typeof(SlideSwitchPanel), 
            new FrameworkPropertyMetadata(1, new PropertyChangedCallback(OnIndexChanged)));

        /// <summary>
        /// 索引，值从1开始，不是从0开始的
        /// </summary>
        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }
        #endregion

        public static RoutedEvent IndexChangedEvent = EventManager.RegisterRoutedEvent("IndexChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<int>), typeof(SlideSwitchPanel));
        public event RoutedPropertyChangedEventHandler<int> IndexChanged
        {
            add { AddHandler(IndexChangedEvent, value); }
            remove { RemoveHandler(IndexChangedEvent, value); }
        }

        #region Override
        protected override Size MeasureOverride(Size constraint)
        {
            Size size = new Size(this.initWidth, this.initHeight);

            foreach (UIElement e in InternalChildren)
            {
                e.Measure(new Size(this.initWidth, this.initHeight));
            }

            return size;
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            for (int i = 0; i < this.InternalChildren.Count; i++)
            {
                this.InternalChildren[i].Arrange(new Rect(i * this.initWidth, 0, this.initWidth, this.initHeight));
            }
            return arrangeSize;
        }

        #endregion

        private static void OnIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SlideSwitchPanel panel = d as SlideSwitchPanel;
            if(e.Property == SlideSwitchPanel.IndexProperty)
            {
                int newValue = (int)e.NewValue;
                int oldValue = (int)e.OldValue;
                panel.OnIndexChanged(oldValue, newValue);
            }
        }

        private void OnIndexChanged(int oldValue, int newValue)
        {
            RoutedPropertyChangedEventArgs<int> args = new RoutedPropertyChangedEventArgs<int>(oldValue, newValue);
            args.RoutedEvent = IndexChangedEvent;
            RaiseEvent(args);

            this.Switch(newValue);
        }

        private void Switch(int index)
        {
            DoubleAnimation animation = new DoubleAnimation(-(index - 1) * this.initWidth, TimeSpan.FromMilliseconds(300));
            animation.DecelerationRatio = 0.2;
            animation.AccelerationRatio = 0.2;
            this.translate.BeginAnimation(TranslateTransform.XProperty, animation);
        }
    }
}
