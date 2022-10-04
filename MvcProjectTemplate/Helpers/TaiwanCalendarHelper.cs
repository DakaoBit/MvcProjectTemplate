using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Util.Helpers
{
          public static class TaiwanCalendarHelper
          {
                    /// <summary>
                    /// 改成台灣年月日
                    /// </summary>
                    /// <param name="x"></param>
                    /// <param name="format"></param>
                    /// <returns></returns>
                    public static string ChangeTaiwanCalendar(this DateTime x, string format)
                    {
                              var tc = new TaiwanCalendar();

                              var regex = new Regex(@"[yY]");
                              format = regex.Replace(format, tc.GetYear(x).ToString("000"));
                              return x.ToString(format);
                    }         
          }
}