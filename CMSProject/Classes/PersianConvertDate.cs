using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace CMSProject
{
    public static class PersianConvertDate
    {
        public static string ToShamsi(this DateTime Value)
        {
            PersianCalendar Pc = new PersianCalendar();
            return Pc.GetYear(Value) + "/" + Pc.GetMonth(Value).ToString("00") + "/" + Pc.GetDayOfMonth(Value).ToString("00");
        }
    }
}