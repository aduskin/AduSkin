using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AduSkin.Controls.Converter
{
    /// <summary>
    /// true则隐藏，false则显示
    /// </summary>
    public class CalendarDayButtonTypeConverter : IMultiValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = string.Empty;
            List<DateTime> list = (List<DateTime>)value[0];
            if (list.Count > 1)
            {
                DateTime dtStart = ((List<DateTime>)value[0])[0];
                DateTime dtEnd = ((List<DateTime>)value[0])[1];
                DateTime dtDayButton = (DateTime)value[1];
                if (dtDayButton == dtStart)
                {
                    str = "Left";
                }
                else if(dtDayButton > dtStart && dtDayButton < dtEnd)
                {
                    str = "Middle";
                }
                else if(dtDayButton == dtEnd)
                {
                    str = "Right";
                }
            }
            return str;
        }
        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
        #endregion
    }
}
