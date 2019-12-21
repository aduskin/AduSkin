using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
    /// <summary>
    /// 分段控件的子项
    /// </summary>
    /// <remarks>add by zhidf 2017.7.9</remarks>
    public class SegmentItem : ListBoxItem
    {
        #region Property
        private SegmentControl ParentItemsControl
        {
            get { return this.ParentSelector as SegmentControl; }
        }

        internal ItemsControl ParentSelector
        {
            get { return ItemsControl.ItemsControlFromItemContainer(this) as ItemsControl; }
        }
        #endregion

        #region DependencyProperty
         public static readonly DependencyProperty SelectForegroundProperty = DependencyProperty.Register("SelectForeground"
             , typeof(Brush), typeof(SegmentItem));
         /// <summary>
         /// 鼠标悬浮时按钮的背景色
         /// </summary>
         public Brush SelectForeground
         {
            get { return (Brush)GetValue(SelectForegroundProperty); }
            set { SetValue(SelectForegroundProperty, value); }
         }

         public static readonly DependencyProperty SelectBackgroundProperty = DependencyProperty.Register("SelectBackground"
                , typeof(Brush), typeof(SegmentItem));
         /// <summary>
         /// 鼠标悬浮时按钮的背景色
         /// </summary>
         public Brush SelectBackground
         {
            get { return (Brush)GetValue(SelectBackgroundProperty); }
            set { SetValue(SelectBackgroundProperty, value); }
         }

      #region IsFirstItem
      /// <summary>
      /// 获取或者设置该项在列表中是否是第一个
      /// </summary>
      [Bindable(true), Description("获取或者设置该项在列表中是否是第一个")]
        public bool IsFirstItem
        {
            get { return (bool)GetValue(IsFirstItemProperty); }
            set { SetValue(IsFirstItemProperty, value); }
        }

        public static readonly DependencyProperty IsFirstItemProperty =
            DependencyProperty.Register("IsFirstItem", typeof(bool), typeof(SegmentItem), new PropertyMetadata(false));

        #endregion

        #region IsMiddleItem

        /// <summary>
        /// 获取或者设置该项在列表中是否是中间的一个
        /// </summary>
        [Bindable(true), Description("获取或者设置该项在列表中是否是中间的一个")]
        public bool IsMiddleItem
        {
            get { return (bool)GetValue(IsMiddleItemProperty); }
            set { SetValue(IsMiddleItemProperty, value); }
        }

        public static readonly DependencyProperty IsMiddleItemProperty =
            DependencyProperty.Register("IsMiddleItem", typeof(bool), typeof(SegmentItem), new PropertyMetadata(false));

        #endregion

        #region IsLastItem
        /// <summary>
        /// 获取或者设置该项在列表中是否是最后一个
        /// </summary>
        [Bindable(true), Description("获取或者设置该项在列表中是否是最后一个")]
        public bool IsLastItem
        {
            get { return (bool)GetValue(IsLastItemProperty); }
            set { SetValue(IsLastItemProperty, value); }
        }

        public static readonly DependencyProperty IsLastItemProperty =
            DependencyProperty.Register("IsLastItem", typeof(bool), typeof(SegmentItem), new PropertyMetadata(false));

        #endregion

        #region CornerRadius

        /// <summary>
        /// 获取或者设置空间的边框圆角
        /// </summary>
        [Bindable(true), Description("获取或者设置空间的边框圆角")]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(SegmentItem));

        #endregion

        #endregion

        #region Constructors

        static SegmentItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SegmentItem), new FrameworkPropertyMetadata(typeof(SegmentItem)));
        }

        #endregion

        #region Override

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.MouseLeftButtonUp += ButtonGroupItem_MouseLeftButtonUp;
        }

        #endregion

        #region private function

        #endregion

        #region Event Implement Function

        private void ButtonGroupItem_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.ParentItemsControl.OnItemClick(this, this);
        }

        #endregion
    }
}
