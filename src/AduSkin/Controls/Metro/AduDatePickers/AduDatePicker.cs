using AduSkin.Controls;
using AduSkin.Utility.AduMethod;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace AduSkin.Controls.Metro
{
   /// <summary>
   /// 日期选择控件
   /// </summary>
   /// <remarks>add by zhidanfeng</remarks>
   public class AduDatePicker : Control
   {
      #region Private属性

      #region 控件内部元素
      private Popup PART_Popup_New;
      private Popup PART_Popup_TimeSelector;
      /// <summary>
      /// 日历：单个日历
      /// </summary>
      private AduCalendar PART_Calendar;
      /// <summary>
      /// 日历：双日期模式下的第二个日历
      /// </summary>
      private AduCalendar PART_Calendar_Second;
      /// <summary>
      /// 时间选择器
      /// </summary>
      private AduTimeSelector PART_TimeSelector;
      /// <summary>
      /// 文本框：显示选中的日期
      /// </summary>
      private TextBox PART_TextBox_New;
      /// <summary>
      /// 快捷菜单：今天
      /// </summary>
      private Button PART_Btn_Today;
      /// <summary>
      /// 快捷菜单：昨天
      /// </summary>
      private Button PART_Btn_Yestday;
      /// <summary>
      /// 快捷菜单：一周前
      /// </summary>
      private Button PART_Btn_AWeekAgo;
      /// <summary>
      /// 快捷菜单：最近一周
      /// </summary>
      private Button PART_Btn_RecentlyAWeek;
      /// <summary>
      /// 快捷菜单：最近一个月
      /// </summary>
      private Button PART_Btn_RecentlyAMonth;
      /// <summary>
      /// 快捷菜单：最近三个月
      /// </summary>
      private Button PART_Btn_RecentlyThreeMonth;
      /// <summary>
      /// 按钮：清除所选日期
      /// </summary>
      private Button PART_ClearDate;
      /// <summary>
      /// 按钮：确认选择所选日期
      /// </summary>
      private Button PART_ConfirmSelected;
      #endregion

      #endregion

      #region MyRegion

      public string TextInternal
      {
         get { return (string)GetValue(TextInternalProperty); }
         private set { SetValue(TextInternalProperty, value); }
      }

      public static readonly DependencyProperty TextInternalProperty =
          DependencyProperty.Register("TextInternal", typeof(string), typeof(AduDatePicker), new PropertyMetadata(string.Empty));


      #endregion

      #region 依赖属性set get

      #region Type 日历类型
      /// <summary>
      /// 日历类型。SingleDate：单个日期，SingleDateRange：连续的多个日期
      /// </summary>
      public EnumDatePickerType Type
      {
         get { return (EnumDatePickerType)GetValue(TypeProperty); }
         set { SetValue(TypeProperty, value); }
      }

      public static readonly DependencyProperty TypeProperty =
          DependencyProperty.Register("Type", typeof(EnumDatePickerType), typeof(AduDatePicker), new PropertyMetadata(EnumDatePickerType.SingleDate, TypeChangedCallback));

      private static void TypeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         AduDatePicker datePicker = d as AduDatePicker;
         datePicker.SetSelectionMode(datePicker, (EnumDatePickerType)e.NewValue);
      }
      #endregion

      #region IsShowShortCuts 是否显示快捷操作菜单
      /// <summary>
      /// 是否显示快捷操作菜单
      /// </summary>
      public bool IsShowShortCuts
      {
         get { return (bool)GetValue(IsShowShortCutsProperty); }
         set { SetValue(IsShowShortCutsProperty, value); }
      }

      public static readonly DependencyProperty IsShowShortCutsProperty =
          DependencyProperty.Register("IsShowShortCuts", typeof(bool), typeof(AduDatePicker), new PropertyMetadata(false));
      #endregion

      #region SelectedDate

      /// <summary>
      /// 获取或设置选中的日期
      /// </summary>
      public DateTime? SelectedDate
      {
         get { return (DateTime?)GetValue(SelectedDateProperty); }
         set { 
            SetValue(SelectedDateProperty, value);
            //设置DateTime
            if (this.SelectedTime == null || this.SelectedDate == null)
            {
               return;
            }
            this.SelectedDateTime = Convert.ToDateTime(this.SelectedDate.Value.ToString("yyyy-MM-dd") + " " + SelectedTime.Value.ToString("HH:mm:ss"));
         }
      }

      public static readonly DependencyProperty SelectedDateProperty =
          DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(AduDatePicker), new PropertyMetadata(null, SelectedDateCallback, SelectedDateCoerceValueCallback));

      private static void SelectedDateCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         AduDatePicker datePicker = d as AduDatePicker;
         DateTime? dateTime = (DateTime?)e.NewValue;
         if (dateTime.HasValue)
         {
            DateTime dt = dateTime.Value;
            if (datePicker.SelectedTime == null)
            {
               datePicker.SelectedTime = dt;
            }

            datePicker.SetSingleDateToTextBox(dt);
         }
         else
         {
            //TODO
            //显示水印
         }
      }

      private static object SelectedDateCoerceValueCallback(DependencyObject d, object value)
      {
         AduDatePicker datePicker = d as AduDatePicker;

         DateTime? dateTime = (DateTime?)value;
         if (datePicker.PART_Calendar != null)
         {
            datePicker.PART_Calendar.SelectedDate = dateTime;
         }
         return dateTime;
      }

      #endregion

      #region SelectedDates
      public ObservableCollection<DateTime> SelectedDates
      {
         get { return (ObservableCollection<DateTime>)GetValue(SelectedDatesProperty); }
         set { SetValue(SelectedDatesProperty, value); }
      }

      public static readonly DependencyProperty SelectedDatesProperty =
          DependencyProperty.Register("SelectedDates", typeof(ObservableCollection<DateTime>), typeof(AduDatePicker), new PropertyMetadata(null, SelectedDateChangedCallback));

      private static void SelectedDateChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         AduDatePicker datePicker = d as AduDatePicker;

         foreach (DateTime date in datePicker.SelectedDates)
         {
            if (date.Year == datePicker.PART_Calendar.DisplayDate.Year
                && date.Month == datePicker.PART_Calendar.DisplayDate.Month)
            {
               datePicker.PART_Calendar.SelectedDates.Add(date);
            }
            else
            {
               datePicker.PART_Calendar_Second.SelectedDates.Add(date);
            }
         }
      }
      #endregion

      #region SelectedDateStart

      public DateTime? SelectedDateStart
      {
         get { return (DateTime?)GetValue(SelectedDateStartProperty); }
         set { SetValue(SelectedDateStartProperty, value); }
      }

      public static readonly DependencyProperty SelectedDateStartProperty =
          DependencyProperty.Register("SelectedDateStart", typeof(DateTime?), typeof(AduDatePicker), new PropertyMetadata(null));

      #endregion

      #region SelectedDateEnd

      public DateTime? SelectedDateEnd
      {
         get { return (DateTime?)GetValue(SelectedDateEndProperty); }
         set { SetValue(SelectedDateEndProperty, value); }
      }

      public static readonly DependencyProperty SelectedDateEndProperty =
          DependencyProperty.Register("SelectedDateEnd", typeof(DateTime?), typeof(AduDatePicker), new PropertyMetadata(null, SelectedDateEndCallback, CoerceSelectedDateEnd));

      private static object CoerceSelectedDateEnd(DependencyObject d, object value)
      {
         AduDatePicker datePicker = d as AduDatePicker;
         DateTime? dateTime = (DateTime?)value;
         if (datePicker.PART_Calendar != null)
         {
            datePicker.PART_Calendar.SelectedDate = dateTime;
         }
         datePicker.SetSelectedDates(datePicker.SelectedDateStart, datePicker.SelectedDateEnd);
         return dateTime;
      }

      private static void SelectedDateEndCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {

      }

      #endregion

      #region SelectedTime
      /// <summary>
      /// 获取或设置选中的时间
      /// </summary>
      public DateTime? SelectedTime
      {
         get { return (DateTime?)GetValue(SelectedTimeProperty); }
         set { 
            SetValue(SelectedTimeProperty, value);
            //设置DateTime
            if (this.SelectedTime == null || this.SelectedDate == null)
            {
               return;
            }
            this.SelectedDateTime = Convert.ToDateTime(this.SelectedDate.Value.ToString("yyyy-MM-dd") + " " + SelectedTime.Value.ToString("HH:mm:ss"));
         }
      }

      public static readonly DependencyProperty SelectedTimeProperty =
          DependencyProperty.Register("SelectedTime", typeof(DateTime?), typeof(AduDatePicker), new PropertyMetadata(null, SelectedTimeChangedCallback));

      private static void SelectedTimeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         AduDatePicker datePicker = d as AduDatePicker;
         datePicker.SetSingleDateToTextBox(datePicker.SelectedDate);
      }

      #endregion
      #region SelectedDateTime
      /// <summary>
      /// 获取或设置选中的日期和时间
      /// </summary>
      public DateTime? SelectedDateTime
      {
         get { return (DateTime?)GetValue(SelectedDateTimeProperty); }
         set { SetValue(SelectedDateTimeProperty, value); }
      }

      public static readonly DependencyProperty SelectedDateTimeProperty =
          DependencyProperty.Register("SelectedDateTime", typeof(DateTime?), typeof(AduDatePicker), new PropertyMetadata(null, SelectedDateTimeChangedCallback));

      private static void SelectedDateTimeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
      {
         AduDatePicker datePicker = d as AduDatePicker;
         DateTime? dateTime = (DateTime?)e.NewValue;
         if (dateTime.HasValue)
         {
            DateTime dt = dateTime.Value;
            if (datePicker.SelectedDate == null)
            {
               datePicker.SelectedDate = dt;
            }
         }
      }
      #endregion

      #region DisplayDate

      public DateTime DisplayDate
      {
         get { return (DateTime)GetValue(DisplayDateProperty); }
         set { SetValue(DisplayDateProperty, value); }
      }

      public static readonly DependencyProperty DisplayDateProperty =
          DependencyProperty.Register("DisplayDate", typeof(DateTime), typeof(AduDatePicker));

      #endregion

      #region DateStringFormat

      public string DateStringFormat
      {
         get { return (string)GetValue(DateStringFormatProperty); }
         set { SetValue(DateStringFormatProperty, value); }
      }

      public static readonly DependencyProperty DateStringFormatProperty =
          DependencyProperty.Register("DateStringFormat", typeof(string), typeof(AduDatePicker), new PropertyMetadata("yyyy年MM月dd日"));

      #endregion

      #region TimeStringFormat

      public string TimeStringFormat
      {
         get { return (string)GetValue(TimeStringFormatProperty); }
         set { SetValue(TimeStringFormatProperty, value); }
      }

      public static readonly DependencyProperty TimeStringFormatProperty =
          DependencyProperty.Register("TimeStringFormat", typeof(string), typeof(AduDatePicker), new PropertyMetadata("HH:mm:ss"));

      #endregion

      #region CornerRadius

      public CornerRadius CornerRadius
      {
         get { return (CornerRadius)GetValue(CornerRadiusProperty); }
         set { SetValue(CornerRadiusProperty, value); }
      }

      public static readonly DependencyProperty CornerRadiusProperty =
          DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(AduDatePicker));

      #endregion

      #region IsShowConfirm
      /// <summary>
      /// 获取或设置是否显示确认按钮
      /// </summary>
      public bool IsShowConfirm
      {
         get { return (bool)GetValue(IsShowConfirmProperty); }
         set { SetValue(IsShowConfirmProperty, value); }
      }

      public static readonly DependencyProperty IsShowConfirmProperty =
          DependencyProperty.Register("IsShowConfirm", typeof(bool), typeof(AduDatePicker), new PropertyMetadata(false));

      #endregion

      #region IsDropDownOpen

      public bool IsDropDownOpen
      {
         get { return (bool)GetValue(IsDropDownOpenProperty); }
         set { SetValue(IsDropDownOpenProperty, value); }
      }

      public static readonly DependencyProperty IsDropDownOpenProperty =
          DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(AduDatePicker), new PropertyMetadata(false));

      #endregion

      #endregion

      #region 内部依赖属性
      public DateTime? SelectedDateInternal
      {
         get { return (DateTime?)GetValue(SelectedDateInternalProperty); }
         set { SetValue(SelectedDateInternalProperty, value); }
      }

      public static readonly DependencyProperty SelectedDateInternalProperty =
          DependencyProperty.Register("SelectedDateInternal", typeof(DateTime?), typeof(AduDatePicker));


      public DateTime DisplayDateInternal
      {
         get { return (DateTime)GetValue(DisplayDateInternalProperty); }
         set { SetValue(DisplayDateInternalProperty, value); }
      }

      public static readonly DependencyProperty DisplayDateInternalProperty =
          DependencyProperty.Register("DisplayDateInternal", typeof(DateTime), typeof(AduDatePicker));


      #endregion

      #region Constructors
      static AduDatePicker()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(AduDatePicker), new FrameworkPropertyMetadata(typeof(AduDatePicker)));
      }

      public AduDatePicker()
      {
         Utility.Refresh(this);
         this.SelectedDates = new ObservableCollection<DateTime>();
      }
      #endregion

      #region Override方法
      public override void OnApplyTemplate()
      {
         if (this.PART_Calendar != null)
         {
            this.PART_Calendar.Owner = null;
         }
         if (this.PART_Calendar_Second != null)
         {
            this.PART_Calendar_Second.Owner = null;
         }

         base.OnApplyTemplate();

         this.PART_Popup_New = GetTemplateChild("PART_Popup_New") as Popup;
         this.PART_Popup_TimeSelector = GetTemplateChild("PART_Popup_TimeSelector") as Popup;
         this.PART_Calendar = GetTemplateChild("PART_Calendar") as AduCalendar;
         this.PART_Calendar_Second = GetTemplateChild("PART_Calendar_Second") as AduCalendar;
         this.PART_TimeSelector = GetTemplateChild("PART_TimeSelector") as AduTimeSelector;
         this.PART_TextBox_New = GetTemplateChild("PART_TextBox_New") as TextBox;
         this.PART_Btn_Today = GetTemplateChild("PART_Btn_Today") as Button;
         this.PART_Btn_Yestday = GetTemplateChild("PART_Btn_Yestday") as Button;
         this.PART_Btn_AWeekAgo = GetTemplateChild("PART_Btn_AWeekAgo") as Button;
         this.PART_Btn_RecentlyAWeek = GetTemplateChild("PART_Btn_RecentlyAWeek") as Button;
         this.PART_Btn_RecentlyAMonth = GetTemplateChild("PART_Btn_RecentlyAMonth") as Button;
         this.PART_Btn_RecentlyThreeMonth = GetTemplateChild("PART_Btn_RecentlyThreeMonth") as Button;
         this.PART_ConfirmSelected = GetTemplateChild("PART_ConfirmSelected") as Button;
         this.PART_ClearDate = GetTemplateChild("PART_ClearDate") as Button;

         if (this.PART_Popup_New != null)
         {
            this.PART_Popup_New.Opened += PART_Popup_New_Opened;
         }

         if (this.PART_Popup_TimeSelector != null)
         {
            this.PART_Popup_TimeSelector.Opened += PART_Popup_TimeSelector_Opened;
         }

         if (this.PART_Calendar != null)
         {
            this.PART_Calendar.Owner = this;
            this.PART_Calendar.DateClick += PART_Calendar_DateClick;
            this.PART_Calendar.DisplayDateChanged += PART_Calendar_DisplayDateChanged;
            if (this.Type == EnumDatePickerType.SingleDateRange)
            {
               this.PART_Calendar.DisplayDate = new DateTime(this.DisplayDate.Year, this.DisplayDate.Month, 1);
            }
         }

         if (this.PART_Calendar_Second != null)
         {
            this.PART_Calendar_Second.Owner = this;
            this.PART_Calendar_Second.DisplayMode = CalendarMode.Month;
            this.PART_Calendar_Second.DisplayDate = this.PART_Calendar.DisplayDate.AddMonths(1);

            this.PART_Calendar_Second.DisplayDateChanged += PART_Calendar_Second_DisplayDateChanged;
            this.PART_Calendar_Second.DateClick += PART_Calendar_Second_DateClick;
         }

         if (this.PART_TimeSelector != null)
         {
            this.PART_TimeSelector.SelectedTimeChanged += PART_TimeSelector_SelectedTimeChanged;
         }

         if (this.PART_Btn_Today == null)
         {
            this.PART_Btn_Today.Click -= this.PART_Btn_Today_Click;
         }
         if (this.PART_Btn_Yestday == null)
         {
            this.PART_Btn_Yestday.Click -= this.PART_Btn_Yestday_Click;
         }
         if (this.PART_Btn_AWeekAgo == null)
         {
            this.PART_Btn_AWeekAgo.Click -= PART_Btn_AnWeekAgo_Click;
         }

         if (this.PART_Btn_Today != null)
         {
            this.PART_Btn_Today.Click += PART_Btn_Today_Click;
         }
         if (this.PART_Btn_Yestday != null)
         {
            this.PART_Btn_Yestday.Click += PART_Btn_Yestday_Click;
         }
         if (this.PART_Btn_AWeekAgo != null)
         {
            this.PART_Btn_AWeekAgo.Click += PART_Btn_AnWeekAgo_Click;
         }
         if (this.PART_Btn_RecentlyAWeek != null)
         {
            this.PART_Btn_RecentlyAWeek.Click += PART_Btn_RecentlyAWeek_Click; ;
         }
         if (this.PART_Btn_RecentlyAMonth != null)
         {
            this.PART_Btn_RecentlyAMonth.Click += PART_Btn_RecentlyAMonth_Click; ;
         }
         if (this.PART_Btn_RecentlyThreeMonth != null)
         {
            this.PART_Btn_RecentlyThreeMonth.Click += PART_Btn_RecentlyThreeMonth_Click; ;
         }

         if (this.PART_ConfirmSelected != null)
         {
            this.PART_ConfirmSelected.Click += (o, e) => { this.IsDropDownOpen = false; };
         }

         if (this.PART_ClearDate != null)
         {
            this.PART_ClearDate.Click += PART_ClearDate_Click;
         }

         if (this.SelectedDate.HasValue)
         {
            this.SetSingleDateToTextBox(this.SelectedDate);
            this.SetSelectedDate();
         }

         if (this.SelectedDateStart.HasValue && this.SelectedDateEnd.HasValue)
         {
            this.SetRangeDateToTextBox(this.SelectedDateStart, this.SelectedDateEnd);
            this.SetSelectedDates(this.SelectedDateStart, this.SelectedDateEnd);
         }
         this.SetSelectionMode(this, this.Type);
         this.SetIsShowConfirm();
      }

      private void PART_Popup_TimeSelector_Opened(object sender, EventArgs e)
      {
         if (this.PART_TimeSelector != null)
         {
            this.PART_TimeSelector.SetButtonSelected();
         }
      }

      private void PART_TimeSelector_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
      {
         if (e.NewValue.HasValue)
         {
            this.SelectedTime = e.NewValue;
         }
      }
      #endregion

      #region Private方法

      private void SetSelectedDate()
      {
         if (this.PART_Calendar != null)
         {
            this.PART_Calendar.SelectedDate = this.SelectedDate;
         }
      }

      private void PART_ClearDate_Click(object sender, RoutedEventArgs e)
      {
         if (this.PART_TextBox_New != null)
         {
            this.PART_TextBox_New.Text = string.Empty;
         }
         this.ClearSelectedDates();
      }

      /// <summary>
      /// 日期点击处理事件
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void PART_Calendar_DateClick(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
      {
         if (this.PART_Calendar.DisplayMode == CalendarMode.Month)
         {
            AduCalendar calendar = sender as AduCalendar;
            if (calendar == null)
            {
               return;
            }
            if (calendar.SelectedDate == null)
            {
               return;
            }
            switch (this.Type)
            {
               case EnumDatePickerType.SingleDate:
               case EnumDatePickerType.DateTime:
                  this.SetSelectedDate(calendar.SelectedDate.Value);
                  break;
               case EnumDatePickerType.SingleDateRange:
                  this.HandleSingleDateRange(calendar);
                  break;
            }
         }
      }

      /// <summary>
      /// 双日历模式下的第二个日历的日期点击处理事件
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void PART_Calendar_Second_DateClick(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
      {
         if (this.PART_Calendar_Second.SelectedDate == null)
         {
            return;
         }

         if (sender is AduCalendar)
         {
            if (this.PART_Calendar_Second.DisplayMode == CalendarMode.Month)
            {
               AduCalendar calendar = sender as AduCalendar;
               if (calendar == null)
               {
                  return;
               }
               if (calendar.SelectedDate == null)
               {
                  return;
               }
               switch (this.Type)
               {
                  case EnumDatePickerType.SingleDateRange:
                     this.HandleSingleDateRange(calendar);
                     break;
               }
            }
         }
      }

      /// <summary>
      /// 日期连选
      /// </summary>
      /// <param name="calendar"></param>
      private void HandleSingleDateRange(AduCalendar calendar)
      {
         DateTime? dateTime = calendar.SelectedDate;
         if (this.SelectedDateStart != null && this.SelectedDateEnd != null)
         {
            this.SelectedDates.Clear();
            this.PART_Calendar.SelectedDates.Clear();
            this.PART_Calendar_Second.SelectedDates.Clear();
            this.SelectedDateStart = null;
            this.SelectedDateEnd = null;
            this.PART_Calendar.SelectedDate = null;
            this.PART_Calendar_Second.SelectedDate = null;
         }

         if (this.SelectedDateStart == null)
         {
            this.SelectedDateStart = dateTime;
            calendar.SelectedDate = dateTime;
         }
         else if (calendar.SelectedDate < this.SelectedDateStart)
         {
            this.SelectedDates.Clear();
            this.PART_Calendar.SelectedDates.Clear();
            this.PART_Calendar_Second.SelectedDates.Clear();
            this.SelectedDateStart = dateTime;
            this.PART_Calendar.SelectedDate = null;
            this.PART_Calendar_Second.SelectedDate = null;
            calendar.SelectedDate = dateTime;
         }
         else
         {
            this.SelectedDateEnd = dateTime;
            this.SetSelectedDates(this.SelectedDateStart, this.SelectedDateEnd);

            this.SetRangeDateToTextBox(this.SelectedDateStart, this.SelectedDateEnd);
         }
      }

      private void HandleSelectedDatesChanged()
      {
         AduDatePicker datePicker = this;
         if (datePicker.PART_Calendar == null || datePicker.PART_Calendar_Second == null)
         {
            return;
         }

         datePicker.PART_Calendar.SelectedDates.Clear();
         datePicker.PART_Calendar_Second.SelectedDates.Clear();

         ObservableCollection<DateTime> dt1 = new ObservableCollection<DateTime>();
         ObservableCollection<DateTime> dt2 = new ObservableCollection<DateTime>();

         foreach (DateTime date in datePicker.SelectedDates)
         {
            //选中的日期段可能会跨越好几个月，因此先找出属于第一个日历的日期，然后剩余的日期都显示在第二个日历上面
            if (DateTimeHelper.MonthIsEqual(date, this.PART_Calendar.DisplayDate))
            {
               dt1.Add(date);
            }
            else
            {
               dt2.Add(date);
            }
         }

         datePicker.PART_Calendar.SelectedDates = dt1;
         datePicker.PART_Calendar_Second.SelectedDates = dt2;
      }

      private void PART_Popup_New_Opened(object sender, EventArgs e)
      {
         if (this.PART_Calendar == null)
         {
            return;
         }

         this.PART_Calendar.DisplayMode = CalendarMode.Month;

         switch (this.Type)
         {
            case EnumDatePickerType.SingleDate:
               break;
            case EnumDatePickerType.SingleDateRange:
               this.PART_Calendar_Second.DisplayMode = CalendarMode.Month;
               break;
            default:
               break;
         }
      }

      #region 双日历模式下联动日期

      private void PART_Calendar_DisplayDateChanged(object sender, RoutedPropertyChangedEventArgs<DateTime> e)
      {
         if (e.NewValue == null)
         {
            return;
         }
         if (e.NewValue == null)
         {
            return;
         }

         if (this.Type == EnumDatePickerType.SingleDateRange)
         {
            this.PART_Calendar_Second.DisplayDate = e.NewValue.AddMonths(1);
         }
      }

      private void PART_Calendar_Second_DisplayDateChanged(object sender, RoutedPropertyChangedEventArgs<DateTime> e)
      {
         if (this.PART_Calendar == null)
         {
            return;
         }
         if (e.NewValue == null)
         {
            return;
         }
         if (e.NewValue == null)
         {
            return;
         }

         if (this.Type == EnumDatePickerType.SingleDateRange)
         {
            this.PART_Calendar.DisplayDate = e.NewValue.AddMonths(-1);
         }
      }
      #endregion

      #region 快捷菜单点击事件
      /// <summary>
      /// 点击了“今天”快捷键
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void PART_Btn_Today_Click(object sender, RoutedEventArgs e)
      {
         this.SetSelectedDate(DateTime.Today);
      }

      /// <summary>
      /// 点击了“昨天”快捷键
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void PART_Btn_Yestday_Click(object sender, RoutedEventArgs e)
      {
         this.SetSelectedDate(DateTime.Today.AddDays(-1));
      }

      /// <summary>
      /// 点击了“一周前”快捷键
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void PART_Btn_AnWeekAgo_Click(object sender, RoutedEventArgs e)
      {
         this.SelectedDates.Clear();
         this.PART_Calendar.SelectedDates.Clear();
         this.PART_Calendar_Second.SelectedDates.Clear();
         this.SelectedDateStart = null;
         this.SelectedDateEnd = null;
         this.PART_Calendar.SelectedDate = null;
         this.PART_Calendar_Second.SelectedDate = null;
         this.SetSelectedDate(DateTime.Today.AddDays(-7));
      }

      /// <summary>
      /// 点击了“最近一周”快捷键
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void PART_Btn_RecentlyAWeek_Click(object sender, RoutedEventArgs e)
      {
         this.ClearSelectedDates();
         this.FastSetSelectedDates(DateTime.Today.AddDays(-7), DateTime.Today);
      }

      /// <summary>
      /// 点击了“最近一个月”快捷键
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void PART_Btn_RecentlyAMonth_Click(object sender, RoutedEventArgs e)
      {
         this.ClearSelectedDates();
         this.FastSetSelectedDates(DateTime.Today.AddMonths(-1), DateTime.Today);
      }

      /// <summary>
      /// 点击了“最近三个月”快捷键
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void PART_Btn_RecentlyThreeMonth_Click(object sender, RoutedEventArgs e)
      {
         this.ClearSelectedDates();
         this.FastSetSelectedDates(DateTime.Today.AddMonths(-3), DateTime.Today);
      }
      #endregion

      private void FastSetSelectedDates(DateTime? startDate, DateTime? endDate)
      {
         if (this.PART_Calendar == null || this.PART_Calendar_Second == null)
         {
            return;
         }

         this.SelectedDateStart = startDate;
         this.SelectedDateEnd = endDate;
         this.PART_Calendar_Second.SelectedDate = null;
         this.PART_Calendar.SelectedDate = null;

         this.PART_Calendar.DisplayDate = new DateTime(startDate.Value.Date.Year, startDate.Value.Date.Month, 1);
         this.PART_Calendar_Second.DisplayDate = new DateTime(endDate.Value.Date.Year, endDate.Value.Date.Month, 1);

         this.SetSelectedDates(this.SelectedDateStart, this.SelectedDateEnd);
      }

      /// <summary>
      /// 根据起始日期与结束日期，计算总共的选中日期
      /// </summary>
      /// <param name="selectedDateStart"></param>
      /// <param name="selectedDateEnd"></param>
      private void SetSelectedDates(DateTime? selectedDateStart, DateTime? selectedDateEnd)
      {
         this.SelectedDates.Clear();
         DateTime? dtTemp = selectedDateStart;
         while (dtTemp <= selectedDateEnd)
         {
            this.SelectedDates.Add(dtTemp.Value);
            dtTemp = dtTemp.Value.AddDays(1);
         }
         this.HandleSelectedDatesChanged();

         if (this.PART_TextBox_New != null && selectedDateStart.HasValue && selectedDateEnd.HasValue)
         {
            this.SetRangeDateToTextBox(selectedDateStart, selectedDateEnd);
         }
      }

      /// <summary>
      /// 设置选中的日期
      /// </summary>
      /// <param name="dateTime"></param>
      private void SetSelectedDate(DateTime dateTime)
      {
         this.SelectedDate = dateTime;
         this.DisplayDate = dateTime;
         //if(this.PART_Calendar != null)
         //{
         //    this.PART_Calendar.SelectedDate = dateTime;
         //}
         //设置弹出框是否关闭
         this.IsDropDownOpen = this.IsShowConfirm;
      }

      /// <summary>
      /// 将当前选择的日期显示到文本框中
      /// </summary>
      /// <param name="selectedDate"></param>
      private void SetSingleDateToTextBox(DateTime? selectedDate)
      {
         if (this.PART_TextBox_New != null)
         {
            if (!selectedDate.HasValue)
            {
               selectedDate = new DateTime?(DateTime.Today);
            }
            switch (this.Type)
            {
               case EnumDatePickerType.SingleDate:
                  this.PART_TextBox_New.Text = selectedDate.Value.ToString(this.DateStringFormat);
                  break;
               case EnumDatePickerType.DateTime:
                  if (this.SelectedTime.HasValue && this.PART_TimeSelector != null)
                  {
                     this.PART_TimeSelector.SelectedTime = this.SelectedTime;
                     this.PART_TextBox_New.Text = string.Format("{0} {1}"
                         , selectedDate.Value.ToString(this.DateStringFormat)
                         , this.SelectedTime.Value.ToString(this.TimeStringFormat));
                  }
                  break;
            }

            this.SetSelectedDate(selectedDate.Value);
         }
      }

      /// <summary>
      /// 将当前选择的日期段显示到文本框中
      /// </summary>
      /// <param name="startDate"></param>
      /// <param name="endDate"></param>
      private void SetRangeDateToTextBox(DateTime? startDate, DateTime? endDate)
      {
         if (this.PART_TextBox_New == null)
         {
            return;
         }

         if (startDate.HasValue && endDate.HasValue)
         {
            this.PART_TextBox_New.Text = startDate.Value.ToString(this.DateStringFormat) + " - " + endDate.Value.ToString(this.DateStringFormat);
         }
         //选了两个日期之后，关闭日期选择框
         this.IsDropDownOpen = this.IsShowConfirm;
      }

      /// <summary>
      /// 设置控件的类型
      /// </summary>
      /// <param name="datePicker"></param>
      /// <param name="type"></param>
      private void SetSelectionMode(AduDatePicker datePicker, EnumDatePickerType type)
      {
         switch (type)
         {
            case EnumDatePickerType.SingleDate:
               if (datePicker.PART_Calendar != null)
               {
                  datePicker.PART_Calendar.SelectionMode = CalendarSelectionMode.SingleDate;
               }
               break;
            case EnumDatePickerType.SingleDateRange:
               if (datePicker.PART_Calendar != null)
               {
                  datePicker.PART_Calendar.SelectionMode = CalendarSelectionMode.SingleRange;
               }
               if (datePicker.PART_Calendar_Second != null)
               {
                  datePicker.PART_Calendar_Second.SelectionMode = CalendarSelectionMode.SingleRange;
               }
               break;
            case EnumDatePickerType.Year:
               break;
            case EnumDatePickerType.Month:
               break;
            case EnumDatePickerType.DateTime:
               break;
            case EnumDatePickerType.DateTimeRange:
               break;
            default:
               break;
         }
      }

      /// <summary>
      /// 根据控件类型，设置是否显示确认框
      /// </summary>
      private void SetIsShowConfirm()
      {
         //当控件可以选择时间的时候，默认显示确认框
         switch (this.Type)
         {
            case EnumDatePickerType.DateTime:
            case EnumDatePickerType.DateTimeRange:
               this.IsShowConfirm = true;
               break;
            default:
               break;
         }
      }

      /// <summary>
      /// 清除已选择的日期
      /// </summary>
      private void ClearSelectedDates()
      {
         this.SelectedDates.Clear();
         this.SelectedDateStart = null;
         this.SelectedDateEnd = null;
         this.SelectedDateTime = null;
         if (this.PART_Calendar != null)
         {
            this.SelectedDate = null;
            this.PART_Calendar.SelectedDate = null;
            this.PART_Calendar.SelectedDates.Clear();
         }
         if (this.PART_Calendar_Second != null)
         {
            this.SelectedDate = null;
            this.PART_Calendar_Second.SelectedDate = null;
            this.PART_Calendar_Second.SelectedDates.Clear();
         }
      }
      #endregion
   }
}