using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static int DaysBetweenDates(string date1, string date2)
        {
            DateTime day1 = DateTime.Parse(date1);
            DateTime day2 = DateTime.Parse(date2);

            int days = Math.Abs((day2 - day1).Days);

            return days;

        }
    }
}
