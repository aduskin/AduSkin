using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace AduSkin.Controls.Metro
{
   public class AduFlatSilder : Slider
   {
      #region Private属性
      private Thumb PART_Thumb;
      private Track PART_Track;
      private bool _thumbIsPressed;
      #endregion

      #region 依赖属性

      #region DecreaseColor

      public Brush DecreaseColor
      {
         get { return (Brush)GetValue(DecreaseColorProperty); }
         set { SetValue(DecreaseColorProperty, value); }
      }

      public static readonly DependencyProperty DecreaseColorProperty =
          DependencyProperty.Register("DecreaseColor", typeof(Brush), typeof(AduFlatSilder));

      #endregion

      #region IncreaseColor

      public Brush IncreaseColor
      {
         get { return (Brush)GetValue(IncreaseColorProperty); }
         set { SetValue(IncreaseColorProperty, value); }
      }

      public static readonly DependencyProperty IncreaseColorProperty =
          DependencyProperty.Register("IncreaseColor", typeof(Brush), typeof(AduFlatSilder));

      #endregion


      public bool IsVideoVisibleWhenPressThumb
      {
         get { return (bool)GetValue(IsVideoVisibleWhenPressThumbProperty); }
         set { SetValue(IsVideoVisibleWhenPressThumbProperty, value); }
      }

      // Using a DependencyProperty as the backing store for IsVideoVisibleWhenPressThumb.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty IsVideoVisibleWhenPressThumbProperty =
          DependencyProperty.Register("IsVideoVisibleWhenPressThumb", typeof(bool), typeof(AduFlatSilder), new PropertyMetadata(false));


      #endregion

      #region 路由事件

      #region DropValueChangedEvent

      public static readonly RoutedEvent DropValueChangedEvent = EventManager.RegisterRoutedEvent("DropValueChanged",
          RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<double>), typeof(AduFlatSilder));

      /// <summary>
      /// 在范围值被鼠标拖拽改变时触发
      /// <para>一般有以下两种情况：</para>
      /// 1、鼠标拖拽滑块至一个新的地方
      /// 2、鼠标点击Slider进度条
      /// <para>使用场景：</para>
      /// 在MusicPlayer音乐播放器中，由于在ValueChanged事件设置CurrentPosition会出现音频播放有间隔重复的情况，
      /// 因此不使用ValueChanged来处理鼠标拖拽更新进度，
      /// 使用DropValueChanged则不存在这种情况
      /// </summary>
      public event RoutedPropertyChangedEventHandler<double> DropValueChanged
      {
         add
         {
            this.AddHandler(DropValueChangedEvent, value);
         }
         remove
         {
            this.RemoveHandler(DropValueChangedEvent, value);
         }
      }

      public virtual void OnDropValueChanged(double oldValue, double newValue)
      {
         RoutedPropertyChangedEventArgs<double> arg = new RoutedPropertyChangedEventArgs<double>(oldValue, newValue, DropValueChangedEvent);
         this.RaiseEvent(arg);
      }

      #endregion

      #endregion

      #region Constructors
      static AduFlatSilder()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(AduFlatSilder), new FrameworkPropertyMetadata(typeof(AduFlatSilder)));
      }

      public AduFlatSilder()
      {
         Utility.Refresh(this);
      }
      #endregion

      #region Override方法
      public override void OnApplyTemplate()
      {
         base.OnApplyTemplate();

         this.PART_Thumb = this.GetTemplateChild("PART_Thumb") as Thumb;
         this.PART_Track = this.GetTemplateChild("PART_Track") as Track;
         if (this.PART_Thumb != null)
         {
            this.PART_Thumb.PreviewMouseLeftButtonDown += PART_Thumb_PreviewMouseLeftButtonDown;
            this.PART_Thumb.PreviewMouseLeftButtonUp += PART_Thumb_PreviewMouseLeftButtonUp;
         }
         if (this.PART_Track != null)
         {
            this.PART_Track.MouseLeftButtonDown += PART_Track_MouseLeftButtonDown;
            this.PART_Track.MouseLeftButtonUp += PART_Track_MouseLeftButtonUp;
         }
         this.ValueChanged += AduFlatSilder_ValueChanged;
      }

      private void PART_Track_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {
         this._thumbIsPressed = this.IsVideoVisibleWhenPressThumb && true;
      }

      private void PART_Thumb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {
         this._thumbIsPressed = this.IsVideoVisibleWhenPressThumb && true;
      }

      private void AduFlatSilder_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         if (this.IsVideoVisibleWhenPressThumb && this._thumbIsPressed)
         {
            this.OnDropValueChanged(this.Value, this.Value);
         }
      }

      private void PART_Thumb_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
      {
         if (this.IsVideoVisibleWhenPressThumb) return;
         this.OnDropValueChanged(this.Value, this.Value);
      }

      private void PART_Track_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
      {
         if (this.IsVideoVisibleWhenPressThumb) return;
         this.OnDropValueChanged(this.Value, this.Value);
      }
      #endregion

      #region Private方法

      #endregion
   }
}
