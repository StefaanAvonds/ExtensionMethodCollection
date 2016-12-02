using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodCollection.Translations
{
    /// <summary>
    /// A translator for the DateTime-object.
    /// </summary>
    public static class DateTimeTranslations
    {
        /// <summary>
        /// Convert a DateTime to a specific Date-format.
        /// </summary>
        /// <param name="dateTime">The date to convert to a readable string.</param>
        /// <param name="output">The option to convert the string into.</param>
        /// <returns>A formatted string for the DateTime.</returns>
        public static String ConvertToString(this DateTime dateTime, DateTimeTranslationOptions output)
        {
            string result = String.Empty;

            switch (output)
            {
                case DateTimeTranslationOptions.DayMonthYear:
                    result = dateTime.ToString("dd/MM/yyyy");
                    break;
                case DateTimeTranslationOptions.DayMonthSmallYear:
                    result = dateTime.ToString("dd/MM/yy");
                    break;
                case DateTimeTranslationOptions.DayMonthYearHourMinuteSecond:
                    result = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
                    break;
                case DateTimeTranslationOptions.FullDayOfTheWeek:
                    result = dateTime.ToString("dddd");
                    break;
                case DateTimeTranslationOptions.FullMonth:
                    result = dateTime.ToString("MMMM");
                    break;
            }

            return result;
        }
    }
}
