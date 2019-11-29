using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace AduSkin.Controls.Metro
{
    public class AduTimelineItem : ContentControl
    {
        #region DependencyProperty

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
            DependencyProperty.Register("IsFirstItem", typeof(bool), typeof(AduTimelineItem), new PropertyMetadata(false));

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
            DependencyProperty.Register("IsMiddleItem", typeof(bool), typeof(AduTimelineItem), new PropertyMetadata(false));

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
            DependencyProperty.Register("IsLastItem", typeof(bool), typeof(AduTimelineItem), new PropertyMetadata(false));

        #endregion

        #endregion

        #region Constructors

        static AduTimelineItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AduTimelineItem), new FrameworkPropertyMetadata(typeof(AduTimelineItem)));
        }

        #endregion
    }
}
