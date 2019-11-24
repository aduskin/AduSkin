using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AduSkin.Utility.AduMethod
{
    public class DateTimeHelper
    {
        /// <summary>
        /// 判断月份是否相等
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static bool MonthIsEqual(DateTime dt1, DateTime dt2)
        {
            bool flag = false;

            if(dt1.Year == dt2.Year && dt1.Month == dt2.Month)
            {
                flag = true;
            }

            return flag;
        }
    }
}
