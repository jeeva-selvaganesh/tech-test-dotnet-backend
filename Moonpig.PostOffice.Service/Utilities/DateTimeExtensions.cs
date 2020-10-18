using System;
using System.Collections.Generic;
using System.Text;

namespace Moonpig.PostOffice.Service.Utilities
{
    public static class DateTimeExtensions
    {
        public static DateTime AddWorkdays(this DateTime originalDate, int workDays)
        {
            DateTime tmpDate = originalDate;
            while (workDays > 0)
            {
                tmpDate = tmpDate.AddDays(1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday &&
                    !tmpDate.IsHoliday())
                    workDays--;
            }
            return tmpDate;
        }

        public static bool IsHoliday(this DateTime originalDate)
        {
            // Need to add Holiday Calender if enhancement needed.
            return false;
        }
    }
}
