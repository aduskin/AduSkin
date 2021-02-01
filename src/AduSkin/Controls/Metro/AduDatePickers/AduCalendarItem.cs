using AduSkin.Controls.Attach;
using AduSkin.Controls.Metro;
using AduSkin.Utility.AduMethod;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AduSkin.Controls.Metro
{
   [TemplatePart(Name = "PART_MonthView", Type = typeof(Grid))]
   [TemplatePart(Name = "PART_YearView", Type = typeof(Grid))]
   [TemplatePart(Name = "PART_PreviousYearButton", Type = typeof(Button))]
   [TemplatePart(Name = "PART_PreviousMonthButton", Type = typeof(Button))]
   [TemplatePart(Name = "PART_NextMonthButton", Type = typeof(Button))]
   [TemplatePart(Name = "PART_NextYearButton", Type = typeof(Button))]
   [TemplatePart(Name = "PART_HeaderButton", Type = typeof(Button))]
   public class AduCalendarItem : Control
   {
      #region 枚举

      #endregion

      #region Private属性

      #region 控件内部构造属性
      private Grid PART_MonthView;
      private Grid PART_YearView;
      private Button PART_PreviousYearButton;
      private Button PART_PreviousMonthButton;
      private Button PART_NextMonthButton;
      private Button PART_NextYearButton;
      private Button PART_HeaderButton;
      #endregion

      #region Fields
      private AduCalendarDayButton[,] CalendarDayButtons = new AduCalendarDayButton[7, 7];
      private AduCalendarButton[,] CalendarButtons = new AduCalendarButton[3, 4];
      #endregion

      #region 方法内部属性
      private DateTime DisplayDate
      {
         get
         {
            if (this.Owner == null)
            {
               return DateTime.Today;
            }
            return this.Owner.DisplayDate;
         }
      }
      #endregion

      #endregion

      #region public属性
      public AduCalendar Owner { get; set; }
      #endregion

      #region 依赖属性set get

      #endregion

      #region Constructors
      static AduCalendarItem()
      {
         DefaultStyleKeyProperty.OverrideMetadata(typeof(AduCalendarItem), new FrameworkPropertyMetadata(typeof(AduCalendarItem)));
      }
      #endregion

      #region Override方法
      public override void OnApplyTemplate()
      {
         if (this.PART_PreviousYearButton != null)
         {
            this.PART_PreviousYearButton.Click -= PART_PreviousYearButton_Click;
         }
         if (this.PART_PreviousMonthButton != null)
         {
            this.PART_PreviousMonthButton.Click -= PART_PreviousMonthButton_Click;
         }
         if (this.PART_NextMonthButton != null)
         {
            this.PART_NextMonthButton.Click -= PART_NextMonthButton_Click;
         }
         if (this.PART_NextYearButton != null)
         {
            this.PART_NextYearButton.Click -= PART_NextYearButton_Click;
         }
         if (this.PART_HeaderButton != null)
         {
            this.PART_HeaderButton.Click -= PART_HeaderButton_Click;
         }

         base.OnApplyTemplate();

         this.PART_MonthView = this.GetTemplateChild("PART_MonthView") as Grid;
         this.PART_YearView = this.GetTemplateChild("PART_YearView") as Grid;
         this.PART_PreviousYearButton = this.GetTemplateChild("PART_PreviousYearButton") as Button;
         this.PART_PreviousMonthButton = this.GetTemplateChild("PART_PreviousMonthButton") as Button;
         this.PART_NextMonthButton = this.GetTemplateChild("PART_NextMonthButton") as Button;
         this.PART_NextYearButton = this.GetTemplateChild("PART_NextYearButton") as Button;
         this.PART_HeaderButton = this.GetTemplateChild("PART_HeaderButton") as Button;

         #region 注册事件
         if (this.PART_PreviousYearButton != null)
         {
            this.PART_PreviousYearButton.Click += PART_PreviousYearButton_Click;
         }
         if (this.PART_PreviousMonthButton != null)
         {
            this.PART_PreviousMonthButton.Click += PART_PreviousMonthButton_Click;
         }
         if (this.PART_NextMonthButton != null)
         {
            this.PART_NextMonthButton.Click += PART_NextMonthButton_Click;
         }
         if (this.PART_NextYearButton != null)
         {
            this.PART_NextYearButton.Click += PART_NextYearButton_Click;
         }
         if (this.PART_HeaderButton != null)
         {
            this.PART_HeaderButton.Click += PART_HeaderButton_Click;
         }
         #endregion

         this.InitMonthGrid();
         this.InitYearGrid();

         switch (this.Owner.DisplayMode)
         {
            case CalendarMode.Month:
               this.UpdateMonthMode();
               break;
            case CalendarMode.Year:
               this.UpdateYearMode();
               break;
            case CalendarMode.Decade:
               this.UpdateDecadeMode();
               break;
            default:
               break;
         }
      }

      #endregion

      #region 事件实现
      private void PART_PreviousYearButton_Click(object sender, RoutedEventArgs e)
      {
         int year = this.DisplayDate.Year;
         int month = this.DisplayDate.Month;
         switch (this.Owner.DisplayMode)
         {
            case CalendarMode.Month:
            case CalendarMode.Year:
               this.Owner.DisplayDate = new DateTime(year - 1, month, 1);
               break;
            case CalendarMode.Decade:
               this.Owner.DisplayDate = new DateTime(year - 10, month, 1);
               break;
            default:
               break;
         }
      }

      private void PART_PreviousMonthButton_Click(object sender, RoutedEventArgs e)
      {
         int year = this.DisplayDate.Year;
         int month = this.DisplayDate.Month;
         switch (this.Owner.DisplayMode)
         {
            case CalendarMode.Month:
               if (month == 1)
               {
                  this.Owner.DisplayDate = new DateTime(year - 1, 12, 1);
               }
               else
               {
                  this.Owner.DisplayDate = new DateTime(year, month - 1, 1);
               }
               break;
         }
      }

      private void PART_NextMonthButton_Click(object sender, RoutedEventArgs e)
      {
         int year = this.DisplayDate.Year;
         int month = this.DisplayDate.Month;
         switch (this.Owner.DisplayMode)
         {
            case CalendarMode.Month:
               if (month == 12)
               {
                  this.Owner.DisplayDate = new DateTime(year + 1, 1, 1);
               }
               else
               {
                  this.Owner.DisplayDate = new DateTime(year, month + 1, 1);
               }
               break;
         }
      }

      private void PART_NextYearButton_Click(object sender, RoutedEventArgs e)
      {
         int year = this.DisplayDate.Year;
         int month = this.DisplayDate.Month;
         switch (this.Owner.DisplayMode)
         {
            case CalendarMode.Month:
            case CalendarMode.Year:
               this.Owner.DisplayDate = new DateTime(year + 1, month, 1);
               break;
            case CalendarMode.Decade:
               this.Owner.DisplayDate = new DateTime(year + 10, month, 1);
               break;
            default:
               break;
         }
      }

      private void PART_HeaderButton_Click(object sender, RoutedEventArgs e)
      {
         if (this.Owner != null)
         {
            if (this.Owner.DisplayMode == CalendarMode.Month)
            {
               this.Owner.DisplayMode = CalendarMode.Year;
            }
            else
            {
               this.Owner.DisplayMode = CalendarMode.Decade;
            }
         }
      }
      #endregion

      #region Private方法
      private void InitMonthGrid()
      {
         if (this.PART_MonthView == null)
         {
            return;
         }

         //1、加载周一到周日标题
         for (int i = 0; i < 7; i++)
         {
            AduCalendarDayButton calendarDayButton = new AduCalendarDayButton();
            calendarDayButton.Owner = this.Owner;
            calendarDayButton.SetValue(Button.IsEnabledProperty, false);
            calendarDayButton.SetValue(Grid.RowProperty, 0);
            calendarDayButton.SetValue(Grid.ColumnProperty, i);
            calendarDayButton.SetValue(Button.ContentTemplateProperty, this.Owner.DayTitleTemplate);
            this.PART_MonthView.Children.Add(calendarDayButton);
            this.CalendarDayButtons[0, i] = calendarDayButton;
         }

         //2、加载该月的每一天
         for (int j = 1; j < 7; j++)
         {
            for (int k = 0; k < 7; k++)
            {
               AduCalendarDayButton calendarDayButton = new AduCalendarDayButton();
               ElementBackground.SetSelectedBackground(calendarDayButton, ElementBackground.GetSelectedBackground(this));
               ElementBackground.SetMouseOverBackground(calendarDayButton, ElementBackground.GetMouseOverBackground(this));
               ElementBackground.SetHighlightBackground(calendarDayButton, ElementBackground.GetHighlightBackground(this));
               ElementForeground.SetSelectedForeground(calendarDayButton, ElementForeground.GetSelectedForeground(this));
               ElementForeground.SetMouseOverForeground(calendarDayButton, ElementForeground.GetMouseOverForeground(this));
               ElementForeground.SetHighlightForeground(calendarDayButton, ElementForeground.GetHighlightForeground(this));
               calendarDayButton.Owner = this.Owner;
               calendarDayButton.SetValue(Grid.RowProperty, j);
               calendarDayButton.SetValue(Grid.ColumnProperty, k);
               calendarDayButton.SetBinding(FrameworkElement.StyleProperty, new Binding("CalendarDayButtonStyle") { Source = this.Owner });
               calendarDayButton.IsToday = false;
               calendarDayButton.IsBlackedOut = false;
               calendarDayButton.IsSelected = false;
               //calendarDayButton.AddHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(this.Cell_MouseLeftButtonDown), true);
               //calendarDayButton.AddHandler(UIElement.MouseLeftButtonUpEvent, new MouseButtonEventHandler(this.Cell_MouseLeftButtonUp), true);
               //calendarDayButton.AddHandler(UIElement.MouseEnterEvent, new MouseEventHandler(this.Cell_MouseEnter), true);
               calendarDayButton.Click += new RoutedEventHandler(this.DayButton_Clicked);
               //calendarDayButton.AddHandler(UIElement.PreviewKeyDownEvent, new RoutedEventHandler(this.CellOrMonth_PreviewKeyDown), true);
               this.PART_MonthView.Children.Add(calendarDayButton);
               this.CalendarDayButtons[j, k] = calendarDayButton;
            }
         }
      }

      private void InitYearGrid()
      {
         if (this.PART_YearView == null)
         {
            return;
         }

         for (int i = 0; i < 3; i++)
         {
            for (int j = 0; j < 4; j++)
            {
               AduCalendarButton calendarButton = new AduCalendarButton();
               calendarButton.SetValue(Grid.RowProperty, i);
               calendarButton.SetValue(Grid.ColumnProperty, j);
               calendarButton.SetValue(AduCalendarButton.HasSelectedDatesProperty, false);
               calendarButton.Click += CalendarButton_Click;
               this.PART_YearView.Children.Add(calendarButton);
               this.CalendarButtons[i, j] = calendarButton;
            }
         }
      }

      private void DayButton_Clicked(object sender, RoutedEventArgs e)
      {
         AduCalendarDayButton calendarDayButton = sender as AduCalendarDayButton;
         if (!(calendarDayButton.DataContext is DateTime))
         {
            return;
         }
         if (!calendarDayButton.IsBlackedOut)
         {
            DateTime dateTime = (DateTime)calendarDayButton.DataContext;
            switch (this.Owner.SelectionMode)
            {
               case CalendarSelectionMode.SingleDate:
                  this.ClearSelectedDate();
                  this.Owner.DisplayDate = new DateTime(dateTime.Year, dateTime.Month, 1);
                  this.Owner.SelectedDate = new DateTime?(dateTime);
                  break;
               case CalendarSelectionMode.SingleRange:
                  this.Owner.DisplayDate = new DateTime(dateTime.Year, dateTime.Month, 1);
                  this.Owner.SelectedDate = new DateTime?(dateTime);
                  break;
               case CalendarSelectionMode.MultipleRange:
                  break;
               case CalendarSelectionMode.None:
                  break;
               default:
                  break;
            }

            this.Owner.OnDateClick(new DateTime?(dateTime), new DateTime?(dateTime));
         }
      }

      private void CalendarButton_Click(object sender, RoutedEventArgs e)
      {
         AduCalendarButton calendarButton = sender as AduCalendarButton;
         DateTime dateTime = (DateTime)calendarButton.DataContext;
         if (this.Owner.DisplayMode == CalendarMode.Year)
         {
            this.Owner.DisplayMode = CalendarMode.Month;
            this.Owner.DisplayDate = new DateTime(dateTime.Year, dateTime.Month, 1);
         }
         else
         {
            this.Owner.DisplayMode = CalendarMode.Year;
            this.Owner.DisplayDate = new DateTime(dateTime.Year, this.DisplayDate.Month, 1);
         }
      }

      public void UpdateMonthMode()
      {
         this.SetMonthModeHeaderButton();
         this.SetMonthModePreviousButton();
         this.SetMonthModeNextButton();
         if (this.PART_MonthView != null)
         {
            this.SetMonthModeDayTitles();
            this.SetMonthModeCalendarDayButtons();
            this.AddMonthModeHighlight();
         }
      }

      public void UpdateYearMode()
      {
         this.SetYearModeHeaderButton();
         this.SetYearModePreviousButton();
         this.SetYearModeNextButton();
         if (this.PART_YearView != null)
         {
            this.SetYearModeMonthButtons();
         }
      }

      public void UpdateDecadeMode()
      {
         this.SetDecadeModeHeaderButton();
         //this.SetDecadeModePreviousButton();
         //this.SetDecadeModeNextButton(num);
         if (this.PART_YearView != null)
         {
            this.SetYearButtons();
         }
      }

      #region MonthMode
      private void SetMonthModeHeaderButton()
      {
         if (this.PART_HeaderButton != null)
         {
            this.PART_HeaderButton.Content = this.DisplayDate.ToString("yyyy年M月");
         }
      }

      private void SetMonthModePreviousButton()
      {

      }

      private void SetMonthModeNextButton()
      {

      }

      /// <summary>
      /// 设置日期对应的星期
      /// </summary>
      private void SetMonthModeDayTitles()
      {
         string[] dayOfWeeks = new string[] { "日", "一", "二", "三", "四", "五", "六" };

         for (int i = 0; i < 7; i++)
         {
            int index = (i + (int)this.Owner.FirstDayOfWeek) % 7;
            this.CalendarDayButtons[0, i].Content = dayOfWeeks[index];
            this.CalendarDayButtons[0, i].IsHighlight = false;
         }
      }

      /// <summary>
      /// 设置该月的所有日期
      /// </summary>
      private void SetMonthModeCalendarDayButtons()
      {
         DateTime displayDate = this.Owner.DisplayDate;

         int year = displayDate.Year;
         int month = displayDate.Month;

         DateTime firstDay = new DateTime(year, month, 1);
         //获取该月第一天所在的列数
         int firstColIndex = (displayDate.DayOfWeek - this.Owner.FirstDayOfWeek + 7) % 7;

         //获取该月的总天数
         int daysInMonth = DateTime.DaysInMonth(year, month);
         for (int i = 1; i < 7; i++)
         {
            for (int j = 0; j < 7; j++)
            {
               this.CalendarDayButtons[i, j].Content = "";
               this.CalendarDayButtons[i, j].IsToday = false;
               this.CalendarDayButtons[i, j].IsSelected = false;
               this.CalendarDayButtons[i, j].IsHighlight = false;
            }
         }

         DateTime? selectedDate = this.Owner.SelectedDate;

         for (int day = 1; day <= daysInMonth; day++)
         {
            DateTime date = new DateTime(year, month, day);
            if (date > this.Owner.DisplayDateStart && date < this.Owner.DisplayDateEnd)
            {
               int column, row;
               row = (day + firstColIndex - 1) / 7 + 1;
               column = (day + firstColIndex - 1) % 7;
               this.CalendarDayButtons[row, column].IsBelongCurrentMonth = true;
               this.CalendarDayButtons[row, column].IsToday = false;
               this.CalendarDayButtons[row, column].IsSelected = false;
               this.CalendarDayButtons[row, column].DataContext = date;
               this.CalendarDayButtons[row, column].Content = day.ToString();
               this.CalendarDayButtons[row, column].IsHighlight = false;
            }
         }

         if (this.Owner.DisplayDate.Year == DateTime.Today.Year && this.Owner.DisplayDate.Month == DateTime.Today.Month)
         {
            this.SetTodayButtonHighlight();
         }

         if (this.Owner.IsShowExtraDays)
         {
            this.ListAllDaysInMonthMode(year, month);
         }

         if (this.Owner.Owner != null)
         {
            this.SetSelectedDatesHighlight(this.Owner.Owner.SelectedDates);
         }

         if (this.Owner != null)
         {
            this.SetSelectedDateHighlight();
         }
      }

      private void AddMonthModeHighlight()
      {

      }

      /// <summary>
      /// 高亮选中的日期段
      /// </summary>
      public void SetSelectedDatesHighlight(ObservableCollection<DateTime> selectedDates)
      {
         foreach (object item in this.PART_MonthView.Children)
         {
            AduCalendarDayButton dayButton = item as AduCalendarDayButton;
            if (!(dayButton.DataContext is DateTime) || !dayButton.IsBelongCurrentMonth)
            {
               continue;
            }

            DateTime dt = (DateTime)dayButton.DataContext;
            if (selectedDates != null && selectedDates.Contains(dt))
            {
               if (dt == this.Owner.Owner.SelectedDateStart || dt == this.Owner.Owner.SelectedDateEnd)
               {
                  dayButton.IsSelected = true;
               }
               else
               {
                  dayButton.IsHighlight = true;
               }
            }
            else
            {
               dayButton.IsSelected = false;
               dayButton.IsHighlight = false;
            }
         }
      }

      public void SetSelectedDateHighlight()
      {
         foreach (object item in this.PART_MonthView.Children)
         {
            AduCalendarDayButton dayButton = item as AduCalendarDayButton;
            if (!(dayButton.DataContext is DateTime) || !dayButton.IsBelongCurrentMonth)
            {
               continue;
            }

            DateTime dt = (DateTime)dayButton.DataContext;
            if (this.Owner.SelectedDate.HasValue && dt == this.Owner.SelectedDate.Value.Date)
            {
               dayButton.IsSelected = true;
               break;
            }
         }
      }
      #endregion

      #region YearMode
      private void SetYearModeHeaderButton()
      {
         if (this.PART_HeaderButton != null)
         {
            this.PART_HeaderButton.Content = this.DisplayDate.Year.ToString();
         }
      }

      private void SetYearModePreviousButton()
      {

      }

      private void SetYearModeNextButton()
      {

      }

      /// <summary>
      /// 设置Year模式下的子项(1月~12月)
      /// </summary>
      private void SetYearModeMonthButtons()
      {
         //三行四列
         for (int i = 0; i < 3; i++)
         {
            for (int j = 0; j < 4; j++)
            {
               int month = j + i * 4 + 1;
               DateTime dateTime = new DateTime(this.DisplayDate.Year, month, 1);

               this.CalendarButtons[i, j].DataContext = dateTime;
               this.CalendarButtons[i, j].Content = month + "月";
               this.CalendarButtons[i, j].HasSelectedDates = false;
               if (this.Owner != null && this.Owner.DisplayDate != null
                   && DateTimeHelper.MonthIsEqual(dateTime, this.Owner.DisplayDate))
               {
                  this.CalendarButtons[i, j].HasSelectedDates = true;
               }
            }
         }
      }
      #endregion

      #region DecadeMode
      private void SetDecadeModeHeaderButton()
      {
         int decadeStart = this.DisplayDate.Year - this.DisplayDate.Year % 10;
         this.PART_HeaderButton.Content = string.Format("{0}年 - {1}年", decadeStart, decadeStart + 9);
      }

      /// <summary>
      /// 设置Decade模式下的子项(例：2010~2019)
      /// </summary>
      private void SetYearButtons()
      {
         int decadeStart = this.DisplayDate.Year - this.DisplayDate.Year % 10;

         int num = 0;
         foreach (object item in this.PART_YearView.Children)
         {
            DateTime dateTime = new DateTime(decadeStart + num, 1, 1);
            AduCalendarButton calendarButton = item as AduCalendarButton;
            calendarButton.DataContext = dateTime;
            calendarButton.Content = dateTime.Year;
            calendarButton.HasSelectedDates = false;
            if (this.Owner != null && this.Owner.DisplayDate != null && dateTime.Year == this.Owner.DisplayDate.Year)
            {
               calendarButton.HasSelectedDates = true;
            }
            num++;
         }
      }
      #endregion

      /// <summary>
      /// 清空已选中的日期
      /// </summary>
      private void ClearSelectedDate()
      {
         for (int i = 1; i < 7; i++)
         {
            for (int j = 0; j < 7; j++)
            {
               if (this.CalendarDayButtons[i, j] != null)
               {
                  this.CalendarDayButtons[i, j].IsSelected = false;
               }
            }
         }
      }

      /// <summary>
      /// 高亮“今日”
      /// </summary>
      private void SetTodayButtonHighlight()
      {
         //只有月模式下才高亮 “今日”
         if (this.Owner.DisplayMode == CalendarMode.Month)
         {
            foreach (object item in this.PART_MonthView.Children)
            {
               AduCalendarDayButton dayButton = item as AduCalendarDayButton;
               if (dayButton.DataContext is DateTime)
               {
                  DateTime dt = (DateTime)dayButton.DataContext;
                  if (dt == DateTime.Today)
                  {
                     dayButton.IsToday = true;
                     break;
                  }
               }
            }
         }
      }

      /// <summary>
      /// 列出当月所有的日期，包含上个月和下个月多余的天数
      /// </summary>
      private void ListAllDaysInMonthMode(int year, int month)
      {
         DateTime firstDay = this.GetFirsyDay(year, month);
         int firstDayColIndex = this.GetFirstDayColIndex(firstDay.DayOfWeek);

         int monthTemp = month;
         int yearTemp = year;
         if (month == 1)
         {
            yearTemp--;
            monthTemp = 12;
         }
         else
         {
            monthTemp--;
         }

         //获取上个月的天数
         int daysInMonth = DateTime.DaysInMonth(yearTemp, monthTemp);
         //设置当月中显示的上个月的多余的几天
         for (int i = firstDayColIndex - 1; i >= 0; i--)
         {
            DateTime dateTime = new DateTime(yearTemp, monthTemp, daysInMonth);
            this.CalendarDayButtons[1, i].DataContext = dateTime;
            this.CalendarDayButtons[1, i].Content = daysInMonth;
            this.CalendarDayButtons[1, i].IsBelongCurrentMonth = false;
            daysInMonth--;
         }

         yearTemp = year;
         monthTemp = month;
         //如果当月是12月份，那么下个月就是明年的1月份
         if (month == 12)
         {
            yearTemp++;
            monthTemp = 1;
         }
         else
         {
            monthTemp++;
         }
         //获取下个月的天数
         daysInMonth = DateTime.DaysInMonth(year, month);
         int day = 1;
         for (int i = firstDayColIndex + daysInMonth + 7; i < 49; i++)
         {
            int colIndex = i % 7;
            int rowIndex = i / 7;
            DateTime dateTime = new DateTime(yearTemp, monthTemp, day);
            this.CalendarDayButtons[rowIndex, colIndex].DataContext = dateTime;
            this.CalendarDayButtons[rowIndex, colIndex].Content = day;
            this.CalendarDayButtons[rowIndex, colIndex].IsBelongCurrentMonth = false;
            day++;
         }
      }

      /// <summary>
      /// 获取该月的第一天所在Grid中的位置
      /// </summary>
      /// <param name="dayOfWeek"></param>
      /// <returns></returns>
      private int GetFirstDayColIndex(DayOfWeek dayOfWeek)
      {
         return (dayOfWeek - this.Owner.FirstDayOfWeek + 7) % 7;
      }

      /// <summary>
      /// 获取该月的第一天
      /// </summary>
      /// <param name="year"></param>
      /// <param name="month"></param>
      /// <returns></returns>
      private DateTime GetFirsyDay(int year, int month)
      {
         return new DateTime(year, month, 1);
      }
      #endregion
   }
}
