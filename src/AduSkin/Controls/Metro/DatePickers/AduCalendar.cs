
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
    public enum EnumCalendarType
    {
        One,
        Second,
    }

    public class AduCalendar : Control
    {
        #region Private属性
        private AduCalendarItem PART_CalendarItem;
        #endregion

        public AduDatePicker Owner { get; set; }

        #region 事件定义

        #region SelectedDateChanged
        public static readonly RoutedEvent SelectedDateChangedEvent = EventManager.RegisterRoutedEvent("SelectedDateChanged",
            RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<DateTime?>), typeof(AduCalendar));

        public event RoutedPropertyChangedEventHandler<DateTime?> SelectedDateChanged
        {
            add
            {
                this.AddHandler(SelectedDateChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(SelectedDateChangedEvent, value);
            }
        }

        public virtual void OnSelectedDateChanged(DateTime? oldValue, DateTime? newValue)
        {
            RoutedPropertyChangedEventArgs<DateTime?> arg = new RoutedPropertyChangedEventArgs<DateTime?>(oldValue, newValue, SelectedDateChangedEvent);
            this.RaiseEvent(arg);
        }
        #endregion

        #region DateClick

        public static readonly RoutedEvent DateClickEvent = EventManager.RegisterRoutedEvent("DateClick",
            RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<DateTime?>), typeof(AduCalendar));

        public event RoutedPropertyChangedEventHandler<DateTime?> DateClick
        {
            add
            {
                this.AddHandler(DateClickEvent, value);
            }
            remove
            {
                this.RemoveHandler(DateClickEvent, value);
            }
        }

        public virtual void OnDateClick(DateTime? oldValue, DateTime? newValue)
        {
            RoutedPropertyChangedEventArgs<DateTime?> arg = new RoutedPropertyChangedEventArgs<DateTime?>(oldValue, newValue, DateClickEvent);
            this.RaiseEvent(arg);
        }

        #endregion

        #region DisplayDateChanged

        public static readonly RoutedEvent DisplayDateChangedEvent = EventManager.RegisterRoutedEvent("DisplayDateChanged",
            RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<DateTime>), typeof(AduCalendar));

        public event RoutedPropertyChangedEventHandler<DateTime> DisplayDateChanged
        {
            add
            {
                this.AddHandler(DisplayDateChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(DisplayDateChangedEvent, value);
            }
        }

        public virtual void OnDisplayDateChanged(DateTime oldValue, DateTime newValue)
        {
            RoutedPropertyChangedEventArgs<DateTime> arg = new RoutedPropertyChangedEventArgs<DateTime>(oldValue, newValue, DisplayDateChangedEvent);
            this.RaiseEvent(arg);
        }

        #endregion

        #region DisplayModeChanged

        public static readonly RoutedEvent DisplayModeChangedEvent = EventManager.RegisterRoutedEvent("DisplayModeChanged",
            RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<CalendarMode>), typeof(AduCalendar));

        public event RoutedPropertyChangedEventHandler<CalendarMode> DisplayModeChanged
        {
            add
            {
                this.AddHandler(DisplayModeChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(DisplayModeChangedEvent, value);
            }
        }

        public virtual void OnDisplayModeChanged(CalendarMode oldValue, CalendarMode newValue)
        {
            RoutedPropertyChangedEventArgs<CalendarMode> arg = new RoutedPropertyChangedEventArgs<CalendarMode>(oldValue, newValue, DisplayModeChangedEvent);
            this.RaiseEvent(arg);
        }

        #endregion

        #endregion

        #region 依赖属性定义

        #endregion

        #region 依赖属性set get

        #region CalendarItemStyle
        public Style CalendarItemStyle
        {
            get { return (Style)GetValue(CalendarItemStyleProperty); }
            set { SetValue(CalendarItemStyleProperty, value); }
        }

        public static readonly DependencyProperty CalendarItemStyleProperty =
            DependencyProperty.Register("CalendarItemStyle", typeof(Style), typeof(AduCalendar));
        #endregion

        #region CalendarDayButtonStyle
        public Style CalendarDayButtonStyle
        {
            get { return (Style)GetValue(CalendarDayButtonStyleProperty); }
            set { SetValue(CalendarDayButtonStyleProperty, value); }
        }

        public static readonly DependencyProperty CalendarDayButtonStyleProperty =
            DependencyProperty.Register("CalendarDayButtonStyle", typeof(Style), typeof(AduCalendar));
        #endregion

        #region DayTitleTemplate
        public DataTemplate DayTitleTemplate
        {
            get { return (DataTemplate)GetValue(DayTitleTemplateProperty); }
            set { SetValue(DayTitleTemplateProperty, value); }
        }
        
        public static readonly DependencyProperty DayTitleTemplateProperty =
            DependencyProperty.Register("DayTitleTemplate", typeof(DataTemplate), typeof(AduCalendar));
        #endregion

        #region DisplayDate
        public DateTime DisplayDate
        {
            get { return (DateTime)GetValue(DisplayDateProperty); }
            set { SetValue(DisplayDateProperty, value); }
        }

        public static readonly DependencyProperty DisplayDateProperty =
            DependencyProperty.Register("DisplayDate", typeof(DateTime), typeof(AduCalendar), new PropertyMetadata(DateTime.Today, DisplayDateChangedCalllback));

        private static void DisplayDateChangedCalllback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AduCalendar calendar = d as AduCalendar;
            DateTime oldTime = Convert.ToDateTime(e.OldValue);
            DateTime newTime = Convert.ToDateTime(e.NewValue);
            if (calendar != null)
            {
                calendar.UpdateCellItems();
                calendar.OnDisplayDateChanged(oldTime, newTime);
            }
        }
        #endregion

        #region DisplayDateStart
        public DateTime DisplayDateStart
        {
            get { return (DateTime)GetValue(DisplayDateStartProperty); }
            set { SetValue(DisplayDateStartProperty, value); }
        }
        
        public static readonly DependencyProperty DisplayDateStartProperty =
            DependencyProperty.Register("DisplayDateStart", typeof(DateTime), typeof(AduCalendar), new PropertyMetadata(DateTime.MinValue));
        #endregion

        #region DisplayDateEnd
        public DateTime DisplayDateEnd
        {
            get { return (DateTime)GetValue(DisplayDateEndProperty); }
            set { SetValue(DisplayDateEndProperty, value); }
        }
        
        public static readonly DependencyProperty DisplayDateEndProperty =
            DependencyProperty.Register("DisplayDateEnd", typeof(DateTime), typeof(AduCalendar), new PropertyMetadata(DateTime.MaxValue));
        #endregion

        #region DisplayMode
        public CalendarMode DisplayMode
        {
            get { return (CalendarMode)GetValue(DisplayModeProperty); }
            set { SetValue(DisplayModeProperty, value); }
        }
        
        public static readonly DependencyProperty DisplayModeProperty =
            DependencyProperty.Register("DisplayMode", typeof(CalendarMode), typeof(AduCalendar), new PropertyMetadata(CalendarMode.Month, DisplayModeChangedCallback));

        private static void DisplayModeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AduCalendar calendar = d as AduCalendar;
            if (calendar != null)
            {
                calendar.UpdateCellItems();
                calendar.OnDisplayModeChanged((CalendarMode)e.OldValue, (CalendarMode)e.NewValue);
            }
        }
        #endregion

        #region SelectedDate
        public DateTime? SelectedDate
        {
            get { return (DateTime?)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }
        
        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(AduCalendar), new PropertyMetadata(null, SelectedDateChangedCallback));

        private static void SelectedDateChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AduCalendar calendar = d as AduCalendar;
            if(calendar.SelectionMode == CalendarSelectionMode.SingleDate)
            {
                calendar.OnSelectedDateChanged(new DateTime?(Convert.ToDateTime(e.OldValue)), new DateTime?(Convert.ToDateTime(e.NewValue)));
            }
            if(calendar.PART_CalendarItem != null)
            {
                calendar.PART_CalendarItem.UpdateMonthMode();
            }
        }
        #endregion

        #region SelectedDates
        public ObservableCollection<DateTime> SelectedDates
        {
            get { return (ObservableCollection<DateTime>)GetValue(SelectedDatesProperty); }
            set { SetValue(SelectedDatesProperty, value); }
        }
        
        public static readonly DependencyProperty SelectedDatesProperty =
            DependencyProperty.Register("SelectedDates", typeof(ObservableCollection<DateTime>), typeof(AduCalendar), new PropertyMetadata(null, SelectedDatesChangedCallback));

        private static void SelectedDatesChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AduCalendar calendar = d as AduCalendar;
            if(calendar.PART_CalendarItem == null)
            {
                return;
            }
            calendar.PART_CalendarItem.SetSelectedDatesHighlight(calendar.SelectedDates);
        }
        #endregion

        #region FirstDayOfWeek
        public DayOfWeek FirstDayOfWeek
        {
            get { return (DayOfWeek)GetValue(FirstDayOfWeekProperty); }
            set { SetValue(FirstDayOfWeekProperty, value); }
        }
        
        public static readonly DependencyProperty FirstDayOfWeekProperty =
            DependencyProperty.Register("FirstDayOfWeek", typeof(DayOfWeek), typeof(AduCalendar), new PropertyMetadata(DayOfWeek.Monday));
        #endregion

        #region SelectionMode
        public CalendarSelectionMode SelectionMode
        {
            get { return (CalendarSelectionMode)GetValue(SelectionModeProperty); }
            set { SetValue(SelectionModeProperty, value); }
        }
        
        public static readonly DependencyProperty SelectionModeProperty =
            DependencyProperty.Register("SelectionMode", typeof(CalendarSelectionMode), typeof(AduCalendar), new PropertyMetadata(CalendarSelectionMode.SingleDate));
        #endregion

        #region IsShowExtraDays 是否显示上个月和下个月多余的日期
        /// <summary>
        /// 是否显示上个月和下个月多余的日期
        /// </summary>
        public bool IsShowExtraDays
        {
            get { return (bool)GetValue(IsShowExtraDaysProperty); }
            set { SetValue(IsShowExtraDaysProperty, value); }
        }
        
        public static readonly DependencyProperty IsShowExtraDaysProperty =
            DependencyProperty.Register("IsShowExtraDays", typeof(bool), typeof(AduCalendar), new PropertyMetadata(true));
        #endregion

        #region Type
        public EnumCalendarType Type
        {
            get { return (EnumCalendarType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(EnumCalendarType), typeof(AduCalendar), new PropertyMetadata(EnumCalendarType.One));
        #endregion

        #endregion

        #region Constructors
        static AduCalendar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AduCalendar), new FrameworkPropertyMetadata(typeof(AduCalendar)));
        }

        public AduCalendar()
        {
            this.SelectedDates = new ObservableCollection<DateTime>();
            this.SelectedDates.CollectionChanged += SelectedDates_CollectionChanged;
        }
        #endregion

        #region Override方法
        public override void OnApplyTemplate()
        {
            if (this.PART_CalendarItem != null)
            {
                this.PART_CalendarItem.Owner = null;
            }

            base.OnApplyTemplate();
            
            this.DisplayDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            this.PART_CalendarItem = this.GetTemplateChild("PART_CalendarItem") as AduCalendarItem;
            if (this.PART_CalendarItem != null)
            {
                this.PART_CalendarItem.Owner = this;
            }

            //Calendar有个问题，当选中一个日期之后，似乎焦点并没有得到释放，当鼠标移动其他位置时，需要先点击一下鼠标
            //然后鼠标对应的部分才能获取到焦点，为了解决这个问题，作此处理
            this.PreviewMouseUp += AduCalendar_PreviewMouseUp;
        }

        private void SelectedDates_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (this.PART_CalendarItem == null)
            {
                return;
            }
            this.PART_CalendarItem.SetSelectedDatesHighlight(this.SelectedDates);
        }

        private void AduCalendar_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.Captured is System.Windows.Controls.Primitives.CalendarItem)
            {
                Mouse.Capture(null);
            }
        }
        
        #endregion

        #region Private方法
        private void UpdateCellItems()
        {
            if(this.PART_CalendarItem != null)
            {
                switch (this.DisplayMode)
                {
                    case CalendarMode.Month:
                        this.PART_CalendarItem.UpdateMonthMode();
                        break;
                    case CalendarMode.Year:
                        this.PART_CalendarItem.UpdateYearMode();
                        break;
                    case CalendarMode.Decade:
                        this.PART_CalendarItem.UpdateDecadeMode();
                        break;
                    default:
                        break;
                }
            }
        }

        private DateTime TryParseToDateTime(string str)
        {
            DateTime dt = DateTime.MinValue;
            if(DateTime.TryParse(str, out dt))
            {
                
            }
            return dt;
        }
        #endregion
    }
}
