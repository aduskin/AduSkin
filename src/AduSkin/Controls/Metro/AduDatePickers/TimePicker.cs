using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AduSkin.Controls.Metro
{
    public class TimePicker : Control
    {
        static TimePicker()
        {
            SelectedTimeChangedEvent = EventManager.RegisterRoutedEvent("SelectedTimeChanged"
                , RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>)
                , typeof(TimePicker));
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimePicker), new FrameworkPropertyMetadata(typeof(TimePicker)));
        }

        #region 路由事件
        public static readonly RoutedEvent SelectedTimeChangedEvent;

        public event RoutedPropertyChangedEventHandler<object> SelectedTimeChanged
        {
            add
            {
                base.AddHandler(SelectedTimeChangedEvent, value);
            }
            remove
            {
                base.RemoveHandler(SelectedTimeChangedEvent, value);
            }
        }

        protected virtual void OnSelectedTimeChanged(object oldValue, object newValue)
        {
            RoutedPropertyChangedEventArgs<object> arg =
                new RoutedPropertyChangedEventArgs<object>(oldValue, newValue, SelectedTimeChangedEvent);
            this.RaiseEvent(arg);
        }
        #endregion

        #region 依赖属性
        public static readonly DependencyProperty HourProperty = DependencyProperty.Register("Hour"
            , typeof(int), typeof(TimePicker), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnValueChanged)));

        /// <summary>
        /// 小时
        /// </summary>
        public int Hour
        {
            get { return (int)GetValue(HourProperty); }
            set { SetValue(HourProperty, value); }
        }

        public static readonly DependencyProperty MinuteProperty = DependencyProperty.Register("Minute"
            , typeof(int), typeof(TimePicker), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnValueChanged)));

        /// <summary>
        /// 分钟
        /// </summary>
        public int Minute
        {
            get { return (int)GetValue(MinuteProperty); }
            set { SetValue(MinuteProperty, value); }
        }

        public static readonly DependencyProperty SecondProperty = DependencyProperty.Register("Second"
            , typeof(int), typeof(TimePicker), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnValueChanged)));

        /// <summary>
        /// 秒数
        /// </summary>
        public int Second
        {
            get { return (int)GetValue(SecondProperty); }
            set { SetValue(SecondProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value"
            , typeof(DateTime?), typeof(TimePicker), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnValueChanged)));

        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime? Value
        {
            get { return (DateTime?)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TimePicker timePicker = (TimePicker)sender;
            DateTime dt1 = DateTime.Now;
            if (e.Property == ValueProperty)
            {
                DateTime dt = Convert.ToDateTime(e.NewValue);

                timePicker.Hour = dt.Hour;
                timePicker.Minute = dt.Minute;
                timePicker.Second = dt.Second;
            }
            else
            {
                string time = string.Format("{0}:{1}:{2}", timePicker.Hour, timePicker.Minute, timePicker.Second);
                dt1 = Convert.ToDateTime(time);
                timePicker.Value = dt1;
            }
            timePicker.OnSelectedTimeChanged(dt1, dt1);
        }
        #endregion

        public TimePicker()
        {
            
        }
    }
}
