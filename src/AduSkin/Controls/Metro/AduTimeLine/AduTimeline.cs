using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace AduSkin.Controls.Metro
{
    /// <summary>
    /// 时间轴
    /// </summary>
    /// <remarks>add by zhidanfeng 2017.5.29</remarks>
    public class AduTimeline : ItemsControl
    {
        #region private fields

        #endregion

        #region DependencyProperty

        #region FirstSlotTemplate

        /// <summary>
        /// 获取或者设置第一个时间轴点的样子
        /// </summary>
        [Bindable(true), Description("获取或者设置第一个时间轴点的样子")]
        public DataTemplate FirstSlotTemplate
        {
            get { return (DataTemplate)GetValue(FirstSlotTemplateProperty); }
            set { SetValue(FirstSlotTemplateProperty, value); }
        }
        
        public static readonly DependencyProperty FirstSlotTemplateProperty =
            DependencyProperty.Register("FirstSlotTemplate", typeof(DataTemplate), typeof(AduTimeline));

        #endregion

        #region MiddleSlotTemplate

        /// <summary>
        /// 获取或者设置中间的时间轴点的样子
        /// </summary>
        [Bindable(true), Description("获取或者设置中间的时间轴点的样子")]
        public DataTemplate MiddleSlotTemplate
        {
            get { return (DataTemplate)GetValue(MiddleSlotTemplateProperty); }
            set { SetValue(MiddleSlotTemplateProperty, value); }
        }
        
        public static readonly DependencyProperty MiddleSlotTemplateProperty =
            DependencyProperty.Register("MiddleSlotTemplate", typeof(DataTemplate), typeof(AduTimeline));

        #endregion

        #region LastItemTemplate

        /// <summary>
        /// 获取或者设置最后一个时间轴点的样子
        /// </summary>
        [Bindable(true), Description("获取或者设置最后一个时间轴点的样子")]
        public DataTemplate LastSlotTemplate
        {
            get { return (DataTemplate)GetValue(LastSlotTemplateProperty); }
            set { SetValue(LastSlotTemplateProperty, value); }
        }
        
        public static readonly DependencyProperty LastSlotTemplateProperty =
            DependencyProperty.Register("LastSlotTemplate", typeof(DataTemplate), typeof(AduTimeline));

        #endregion

        #region IsCustomEverySlot

        /// <summary>
        /// 获取或者设置是否自定义每一个时间轴点的外观。
        /// </summary>
        [Bindable(true), Description("获取或者设置是否自定义每一个时间轴点的外观。当属性值为True时，FirstSlotTemplate、MiddleSlotTemplate、LastSlotTemplate属性都将失效，只能设置SlotTemplate来定义每一个时间轴点的样式")]
        public bool IsCustomEverySlot
        {
            get { return (bool)GetValue(IsCustomEverySlotProperty); }
            set { SetValue(IsCustomEverySlotProperty, value); }
        }
        
        public static readonly DependencyProperty IsCustomEverySlotProperty =
            DependencyProperty.Register("IsCustomEverySlot", typeof(bool), typeof(AduTimeline), new PropertyMetadata(false));

        #endregion

        #region SlotTemplate

        /// <summary>
        /// 获取或者设置每个时间轴点的外观
        /// </summary>
        [Bindable(true), Description("获取或者设置每个时间轴点的外观。只有当IsCustomEverySlot属性为True时，该属性才生效")]
        public DataTemplate SlotTemplate
        {
            get { return (DataTemplate)GetValue(SlotTemplateProperty); }
            set { SetValue(SlotTemplateProperty, value); }
        }
        
        public static readonly DependencyProperty SlotTemplateProperty =
            DependencyProperty.Register("SlotTemplate", typeof(DataTemplate), typeof(AduTimeline));

        #endregion

        #endregion

        #region Constructors

        static AduTimeline()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AduTimeline), new FrameworkPropertyMetadata(typeof(AduTimeline)));
        }

        #endregion

        #region Override

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            int index = this.ItemContainerGenerator.IndexFromContainer(element);
            AduTimelineItem timelineItem = element as AduTimelineItem;
            if(timelineItem == null)
            {
                return;
            }

            if(index == 0)
            {
                timelineItem.IsFirstItem = true;
            }

            if(index == this.Items.Count - 1)
            {
                timelineItem.IsLastItem = true;
            }

            base.PrepareContainerForItemOverride(timelineItem, item);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new AduTimelineItem();
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
                        this.SetAduTimelineItem(e.NewStartingIndex + e.NewItems.Count);
                    }

                    //如果新添加项是放在最后一位，则更改原来的最后一位的属性值
                    if (e.NewStartingIndex == this.Items.Count - e.NewItems.Count)
                    {
                        this.SetAduTimelineItem(e.NewStartingIndex - 1);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if(e.OldStartingIndex == 0) //如果移除的是第一个，则更改更新后的第一项的属性值
                    {
                        this.SetAduTimelineItem(0);
                    }
                    else
                    {
                        this.SetAduTimelineItem(e.OldStartingIndex - 1);
                    }
                    break;
            }
        }
        #endregion

        #region private function
        /// <summary>
        /// 设置AduTimelineItem的位置属性
        /// </summary>
        /// <param name="index"></param>
        private void SetAduTimelineItem(int index)
        {
            if(index > this.Items.Count || index < 0)
            {
                return;
            }

            AduTimelineItem AduTimelineItem = this.ItemContainerGenerator.ContainerFromIndex(index) as AduTimelineItem;
            if(AduTimelineItem == null)
            {
                return;
            }
            AduTimelineItem.IsFirstItem = index == 0;
            AduTimelineItem.IsLastItem = index == this.Items.Count - 1;
            AduTimelineItem.IsMiddleItem = index > 0 && index < this.Items.Count - 1;
        }
        #endregion
    }
}
