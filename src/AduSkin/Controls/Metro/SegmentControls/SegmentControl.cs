using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    /// <summary>
    /// 分段按钮控件，类似IOS的SegmentControl
    /// </summary>
    /// <remarks>add by zhidf 2017.7.9</remarks>
    public class SegmentControl : ListBox
    {
        #region private fields

        #endregion

        #region DependencyProperty

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
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(SegmentControl));

        #endregion

        #region IsAllRound

        /// <summary>
        /// 获取或者设置SegmentItem的四周的圆角是否与SegmentControl一致
        /// </summary>
        [Bindable(true), Description("获取或者设置SegmentItem的四周的圆角是否与SegmentControl一致")]
        public bool IsAllRound
        {
            get { return (bool)GetValue(IsAllRoundProperty); }
            set { SetValue(IsAllRoundProperty, value); }
        }
        
        public static readonly DependencyProperty IsAllRoundProperty =
            DependencyProperty.Register("IsAllRound", typeof(bool), typeof(SegmentControl), new PropertyMetadata(false));

        #endregion

        #endregion

        #region 路由事件

        #region ItemClickEvent

        public static readonly RoutedEvent ItemClickEvent = EventManager.RegisterRoutedEvent("ItemClick",
            RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(SegmentControl));

        public event RoutedPropertyChangedEventHandler<object> ItemClick
        {
            add
            {
                this.AddHandler(ItemClickEvent, value);
            }
            remove
            {
                this.RemoveHandler(ItemClickEvent, value);
            }
        }

        public virtual void OnItemClick(object oldValue, object newValue)
        {
            RoutedPropertyChangedEventArgs<object> arg = new RoutedPropertyChangedEventArgs<object>(oldValue, newValue, ItemClickEvent);
            this.RaiseEvent(arg);
        }

      #endregion

      #endregion

      #region Constructors
      public SegmentControl()
      {
         Utility.Refresh(this);
      }

      static SegmentControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SegmentControl), new FrameworkPropertyMetadata(typeof(SegmentControl)));
        }

        #endregion

        #region Override

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            int index = this.ItemContainerGenerator.IndexFromContainer(element);
            SegmentItem segmentItem = element as SegmentItem;
            if (segmentItem == null)
            {
                return;
            }

            if (index == 0)
            {
                segmentItem.IsFirstItem = true;
                segmentItem.CornerRadius = new CornerRadius(this.CornerRadius.TopLeft, 0, 0, this.CornerRadius.BottomLeft);
            }

            if (index == this.Items.Count - 1)
            {
                segmentItem.IsLastItem = true;
                segmentItem.CornerRadius = new CornerRadius(0, this.CornerRadius.TopRight, this.CornerRadius.BottomRight, 0);
            }

            if(this.IsAllRound)
            {
                segmentItem.CornerRadius = this.CornerRadius;
                segmentItem.BorderThickness = new Thickness(0);
                segmentItem.Padding = new Thickness(20, 5, 20, 5);
            }

            base.PrepareContainerForItemOverride(segmentItem, item);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new SegmentItem();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            //以下代码是为了新增项或者移除项时，正确设置每个Item的外观
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewStartingIndex == 0) //如果新添加项是放在第一位，则更改原来的第一位的属性值
                    {
                        this.SetSegmentItem(e.NewStartingIndex + e.NewItems.Count);
                    }

                    //如果新添加项是放在最后一位，则更改原来的最后一位的属性值
                    if (e.NewStartingIndex == this.Items.Count - e.NewItems.Count)
                    {
                        this.SetSegmentItem(e.NewStartingIndex - 1);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldStartingIndex == 0) //如果移除的是第一个，则更改更新后的第一项的属性值
                    {
                        this.SetSegmentItem(0);
                    }
                    else
                    {
                        this.SetSegmentItem(e.OldStartingIndex - 1);
                    }
                    break;
            }
        }

        #endregion

        #region private function

        /// <summary>
        /// 设置SegmentItem的位置属性
        /// </summary>
        /// <param name="index"></param>
        private void SetSegmentItem(int index)
        {
            if (index > this.Items.Count || index < 0)
            {
                return;
            }

            SegmentItem segmentItem = this.ItemContainerGenerator.ContainerFromIndex(index) as SegmentItem;
            if (segmentItem == null)
            {
                return;
            }
            segmentItem.IsFirstItem = index == 0;
            segmentItem.IsLastItem = index == this.Items.Count - 1;
            segmentItem.IsMiddleItem = index > 0 && index < this.Items.Count - 1;
        }

        #endregion

        #region Event Implement Function

        #endregion
    }
}
