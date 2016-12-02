using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodCollection
{
    /// <summary>
    /// Possible outputs to print a DateTime.
    /// </summary>
    public enum DateTimeTranslationOptions
    {
        DayMonthYear,
        DayMonthSmallYear,
        DayMonthYearHourMinuteSecond,
        FullDayOfTheWeek,
        FullMonth
    }
}
