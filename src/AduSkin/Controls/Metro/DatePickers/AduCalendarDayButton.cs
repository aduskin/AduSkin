using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class AduCalendarDayButton : Button
    {
        #region Private属性

        #endregion

        #region Fields
        public AduCalendar Owner { get; set; }
        #endregion

        #region 依赖属性set get

        #region IsSelected
        /// <summary>
        /// 获取或设置日期是否已选中
        /// </summary>
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(AduCalendarDayButton), new PropertyMetadata(false));
        #endregion

        #region IsToday
        /// <summary>
        /// 获取或设置日期是否是今日
        /// </summary>
        public bool IsToday
        {
            get { return (bool)GetValue(IsTodayProperty); }
            set { SetValue(IsTodayProperty, value); }
        }
        
        public static readonly DependencyProperty IsTodayProperty =
            DependencyProperty.Register("IsToday", typeof(bool), typeof(AduCalendarDayButton), new PropertyMetadata(false));
        #endregion

        #region IsBlackedOut
        public bool IsBlackedOut
        {
            get { return (bool)GetValue(IsBlackedOutProperty); }
            set { SetValue(IsBlackedOutProperty, value); }
        }
        
        public static readonly DependencyProperty IsBlackedOutProperty =
            DependencyProperty.Register("IsBlackedOut", typeof(bool), typeof(AduCalendarDayButton), new PropertyMetadata(false));
        #endregion

        #region IsBelongCurrentMonth 是否属于该月
        /// <summary>
        /// 获取或设置日期是否属于该月
        /// </summary>
        public bool IsBelongCurrentMonth
        {
            get { return (bool)GetValue(IsBelongCurrentMonthProperty); }
            set { SetValue(IsBelongCurrentMonthProperty, value); }
        }
        
        public static readonly DependencyProperty IsBelongCurrentMonthProperty =
            DependencyProperty.Register("IsBelongCurrentMonth", typeof(bool), typeof(AduCalendarDayButton), new PropertyMetadata(true));
        #endregion

        #region IsHighlight
        /// <summary>
        /// 获取或设置该日期是否高亮(多日期模式下多选)
        /// </summary>
        public bool IsHighlight
        {
            get { return (bool)GetValue(IsHighlightProperty); }
            set { SetValue(IsHighlightProperty, value); }
        }

        public static readonly DependencyProperty IsHighlightProperty =
            DependencyProperty.Register("IsHighlight", typeof(bool), typeof(AduCalendarDayButton), new PropertyMetadata(true));
        #endregion

        #endregion

        #region Constructors
        static AduCalendarDayButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AduCalendarDayButton), new FrameworkPropertyMetadata(typeof(AduCalendarDayButton)));
        }
        #endregion

        #region Override方法

        #endregion

        #region Private方法

        #endregion
    }
}
