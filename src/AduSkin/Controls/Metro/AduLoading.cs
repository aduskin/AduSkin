using AduSkin.Utility.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   public class AduLoading : Control
   {
      public AduLoading()
      {
         Utility.Refresh(this);
      }

      #region Private属性
      private FrameworkElement PART_Root;
      #endregion

      #region 依赖属性定义
      public Geometry Icon
      {
         get { return (Geometry)GetValue(IconProperty); }
         set { SetValue(IconProperty, value); }
      }

      public static readonly DependencyProperty IconProperty =
          DependencyProperty.Register("Icon", typeof(Geometry), typeof(AduLoading));

      public bool IsActived
      {
         get { return (bool)GetValue(IsActivedProperty); }
         set { SetValue(IsActivedProperty, value); }
      }

      public static readonly DependencyProperty IsActivedProperty =
          DependencyProperty.Register("IsActived", typeof(bool), typeof(AduLoading), new PropertyMetadata(true, OnIsActivedChangedCallback));

      private static void OnIsActivedChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         AduLoading AduLoading = d as AduLoading;
         if (AduLoading.PART_Root == null)
         {
            return;
         }
         VisualStateManager.GoToElementState(AduLoading.PART_Root, (bool)e.NewValue ? "Active" : "Inactive", true);
      }

      public double SpeedRatio
      {
         get { return (double)GetValue(SpeedRatioProperty); }
         set { SetValue(SpeedRatioProperty, value); }
      }

      // Using a DependencyProperty as the backing store for SpeedRatio.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty SpeedRatioProperty =
          DependencyProperty.Register("SpeedRatio", typeof(double), typeof(AduLoading), new PropertyMetadata(.5d, OnSpeedRatioChangedCallback));

      private static void OnSpeedRatioChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         AduLoading AduLoading = d as AduLoading;
         if (AduLoading.PART_Root == null || !AduLoading.IsActived)
         {
            return;
         }
         AduLoading.SetSpeedRatio(AduLoading.PART_Root, AduLoading.SpeedRatio);
      }

      public EnumLoadingType Type
      {
         get { return (EnumLoadingType)GetValue(TypeProperty); }
         set { SetValue(TypeProperty, value); }
      }

      // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty TypeProperty =
          DependencyProperty.Register("Type", typeof(EnumLoadingType), typeof(AduLoading), new PropertyMetadata(EnumLoadingType.SingleRound));


      #endregion

      #region Constructors
      static AduLoading()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(AduLoading), new FrameworkPropertyMetadata(typeof(AduLoading)));
      }
      #endregion

      #region Override方法
      public override void OnApplyTemplate()
      {
         base.OnApplyTemplate();
         this.PART_Root = this.GetTemplateChild("PART_Root") as FrameworkElement;
         if (this.PART_Root != null)
         {
            VisualStateManager.GoToElementState(this.PART_Root, this.IsActived ? "Active" : "Inactive", true);
            this.SetSpeedRatio(this.PART_Root, this.SpeedRatio);
         }
      }
      #endregion

      #region Private方法
      private void SetSpeedRatio(FrameworkElement element, double speedRatio)
      {
         foreach (VisualStateGroup group in VisualStateManager.GetVisualStateGroups(element))
         {
            if (group.Name == "ActiveStates")
            {
               foreach (VisualState state in group.States)
               {
                  if (state.Name == "Active")
                  {
                     state.Storyboard.SetSpeedRatio(element, speedRatio);
                  }
               }
            }
         }
      }
      #endregion
   }
}
