﻿using AduSkin.Controls.Data;
using AduSkin.Controls.Tools;
using AduSkin.Utility.Element;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace AduSkin.Controls.Metro
{
    public class MetroScrollViewer : ScrollViewer
    {
        public static readonly DependencyProperty FloatProperty = ElementBase.Property<MetroScrollViewer, bool>("FloatProperty");
        public static readonly DependencyProperty AutoLimitMouseProperty = ElementBase.Property<MetroScrollViewer, bool>("AutoLimitMouseProperty");
        public static readonly DependencyProperty VerticalMarginProperty = ElementBase.Property<MetroScrollViewer, Thickness>("VerticalMarginProperty");
        public static readonly DependencyProperty HorizontalMarginProperty = ElementBase.Property<MetroScrollViewer, Thickness>("HorizontalMarginProperty");

        public bool Float { get { return (bool)GetValue(FloatProperty); } set { SetValue(FloatProperty, value); } }
        public bool AutoLimitMouse { get { return (bool)GetValue(AutoLimitMouseProperty); } set { SetValue(AutoLimitMouseProperty, value); } }
        public Thickness VerticalMargin { get { return (Thickness)GetValue(VerticalMarginProperty); } set { SetValue(VerticalMarginProperty, value); } }
        public Thickness HorizontalMargin { get { return (Thickness)GetValue(HorizontalMarginProperty); } set { SetValue(HorizontalMarginProperty, value); } }

        public MetroScrollViewer()
        {
            
        }

        static MetroScrollViewer()
        {
            ElementBase.DefaultStyle<MetroScrollViewer>(DefaultStyleKeyProperty);
        }

      #region 滚动条附加方法和属性
      private double _totalVerticalOffset;

      private double _totalHorizontalOffset;

      private bool _isRunning;

      /// <summary>
      ///     滚动方向
      /// </summary>
      public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
          "Orientation", typeof(Orientation), typeof(MetroScrollViewer), new PropertyMetadata(Orientation.Vertical));

      /// <summary>
      ///     滚动方向
      /// </summary>
      public Orientation Orientation
      {
         get => (Orientation)GetValue(OrientationProperty);
         set => SetValue(OrientationProperty, value);
      }

      /// <summary>
      ///     是否响应鼠标滚轮操作
      /// </summary>
      public static readonly DependencyProperty CanMouseWheelProperty = DependencyProperty.Register(
          "CanMouseWheel", typeof(bool), typeof(MetroScrollViewer), new PropertyMetadata(ValueBoxes.TrueBox));

      /// <summary>
      ///     是否响应鼠标滚轮操作
      /// </summary>
      public bool CanMouseWheel
      {
         get => (bool)GetValue(CanMouseWheelProperty);
         set => SetValue(CanMouseWheelProperty, value);
      }

      protected override void OnMouseWheel(MouseWheelEventArgs e)
      {
         if (!CanMouseWheel) return;

         if (!IsEnableInertia)
         {
            if (Orientation == Orientation.Vertical)
            {
               base.OnMouseWheel(e);
            }
            else
            {
               _totalHorizontalOffset = HorizontalOffset;
               CurrentHorizontalOffset = HorizontalOffset;
               _totalHorizontalOffset = Math.Min(Math.Max(0, _totalHorizontalOffset - e.Delta), ScrollableWidth);
               CurrentHorizontalOffset = _totalHorizontalOffset;
            }
            return;
         }
         e.Handled = true;

         if (Orientation == Orientation.Vertical)
         {
            if (!_isRunning)
            {
               _totalVerticalOffset = VerticalOffset;
               CurrentVerticalOffset = VerticalOffset;
            }
            _totalVerticalOffset = Math.Min(Math.Max(0, _totalVerticalOffset - e.Delta), ScrollableHeight);
            ScrollToVerticalOffsetInternal(_totalVerticalOffset);
         }
         else
         {
            if (!_isRunning)
            {
               _totalHorizontalOffset = HorizontalOffset;
               CurrentHorizontalOffset = HorizontalOffset;
            }
            _totalHorizontalOffset = Math.Min(Math.Max(0, _totalHorizontalOffset - e.Delta), ScrollableWidth);
            ScrollToHorizontalOffsetInternal(_totalHorizontalOffset);
         }
      }

      internal void ScrollToTopInternal(double milliseconds = 500)
      {
         if (!_isRunning)
         {
            _totalVerticalOffset = VerticalOffset;
            CurrentVerticalOffset = VerticalOffset;
         }
         ScrollToVerticalOffsetInternal(0, milliseconds);
      }

      internal void ScrollToVerticalOffsetInternal(double offset, double milliseconds = 500)
      {
         var animation = AnimationHelper.CreateAnimation(offset, milliseconds);
         animation.EasingFunction = new CubicEase
         {
            EasingMode = EasingMode.EaseOut
         };
         animation.FillBehavior = FillBehavior.Stop;
         animation.Completed += (s, e1) =>
         {
            CurrentVerticalOffset = offset;
            _isRunning = false;
         };
         _isRunning = true;

         BeginAnimation(CurrentVerticalOffsetProperty, animation, HandoffBehavior.Compose);
      }

      internal void ScrollToHorizontalOffsetInternal(double offset, double milliseconds = 500)
      {
         var animation = AnimationHelper.CreateAnimation(offset, milliseconds);
         animation.EasingFunction = new CubicEase
         {
            EasingMode = EasingMode.EaseOut
         };
         animation.FillBehavior = FillBehavior.Stop;
         animation.Completed += (s, e1) =>
         {
            CurrentHorizontalOffset = offset;
            _isRunning = false;
         };
         _isRunning = true;

         BeginAnimation(CurrentHorizontalOffsetProperty, animation, HandoffBehavior.Compose);
      }

      //protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters) =>
      //    IsPenetrating ? null : base.HitTestCore(hitTestParameters);

      /// <summary>
      ///     是否支持惯性
      /// </summary>
      public static readonly DependencyProperty IsEnableInertiaProperty = DependencyProperty.RegisterAttached(
          "IsEnableInertia", typeof(bool), typeof(MetroScrollViewer), new PropertyMetadata(ValueBoxes.FalseBox));

      public static void SetIsEnableInertia(DependencyObject element, bool value)
      {
         element.SetValue(IsEnableInertiaProperty, value);
      }

      public static bool GetIsEnableInertia(DependencyObject element)
      {
         return (bool)element.GetValue(IsEnableInertiaProperty);
      }

      /// <summary>
      ///     是否支持惯性
      /// </summary>
      public bool IsEnableInertia
      {
         get => (bool)GetValue(IsEnableInertiaProperty);
         set => SetValue(IsEnableInertiaProperty, value);
      }

      /// <summary>
      ///     控件是否可以穿透点击
      /// </summary>
      public static readonly DependencyProperty IsPenetratingProperty = DependencyProperty.RegisterAttached(
          "IsPenetrating", typeof(bool), typeof(MetroScrollViewer), new PropertyMetadata(ValueBoxes.FalseBox));

      /// <summary>
      ///     控件是否可以穿透点击
      /// </summary>
      public bool IsPenetrating
      {
         get => (bool)GetValue(IsPenetratingProperty);
         set => SetValue(IsPenetratingProperty, value);
      }

      public static void SetIsPenetrating(DependencyObject element, bool value)
      {
         element.SetValue(IsPenetratingProperty, value);
      }

      public static bool GetIsPenetrating(DependencyObject element)
      {
         return (bool)element.GetValue(IsPenetratingProperty);
      }

      /// <summary>
      ///     当前垂直滚动偏移
      /// </summary>
      internal static readonly DependencyProperty CurrentVerticalOffsetProperty = DependencyProperty.Register(
          "CurrentVerticalOffset", typeof(double), typeof(MetroScrollViewer), new PropertyMetadata(ValueBoxes.Double0Box, OnCurrentVerticalOffsetChanged));

      private static void OnCurrentVerticalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         if (d is MetroScrollViewer ctl && e.NewValue is double v)
         {
            ctl.ScrollToVerticalOffset(v);
         }
      }

      /// <summary>
      ///     当前垂直滚动偏移
      /// </summary>
      internal double CurrentVerticalOffset
      {
         // ReSharper disable once UnusedMember.Local
         get => (double)GetValue(CurrentVerticalOffsetProperty);
         set => SetValue(CurrentVerticalOffsetProperty, value);
      }

      /// <summary>
      ///     当前水平滚动偏移
      /// </summary>
      internal static readonly DependencyProperty CurrentHorizontalOffsetProperty = DependencyProperty.Register(
          "CurrentHorizontalOffset", typeof(double), typeof(MetroScrollViewer), new PropertyMetadata(ValueBoxes.Double0Box, OnCurrentHorizontalOffsetChanged));

      private static void OnCurrentHorizontalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         if (d is MetroScrollViewer ctl && e.NewValue is double v)
         {
            ctl.ScrollToHorizontalOffset(v);
         }
      }

      /// <summary>
      ///     当前水平滚动偏移
      /// </summary>
      internal double CurrentHorizontalOffset
      {
         get => (double)GetValue(CurrentHorizontalOffsetProperty);
         set => SetValue(CurrentHorizontalOffsetProperty, value);
      }

      #endregion
   }
}