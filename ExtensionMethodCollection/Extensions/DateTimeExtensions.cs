using System;
using System.Collections.Generic;

namespace ExtensionMethodCollection.Extensions
{
    /// <summary>
    /// Extension-methods for the DateTime-object.
    /// </summary>
    public static class DateTimeExtensions
    {
        private static DateTime _minimumSqlDateTime = new DateTime(1753, 1, 1);
        private static DateTime _maximumSqlDateTime = new DateTime(9999, 12, 31);

        /// <summary>
        /// Checks if the DateTime is valid.
        /// </summary>
        /// <param name="dateTime">The DateTime to validate.</param>
        /// <returns>TRUE = valid DateTime | FALSE = invalid DateTime</returns>
        public static Boolean IsValidSqlDateTime(this DateTime dateTime)
        {
            if (dateTime == null) return false;
            if (dateTime == DateTime.MinValue) return false;
            if (dateTime <= _minimumSqlDateTime) return false;
            if (dateTime >= _maximumSqlDateTime) return false;

            return true;
        }

        /// <summary>
        /// Checks if the DateTime is valid.
        /// </summary>
        /// <param name="dateTime">The DateTime to validate.</param>
        /// <returns>TRUE = valid DateTime | FALSE = invalid DateTime</returns>
        public static Boolean IsValidSqlDateTime(this DateTime? dateTime)
        {
            if (!dateTime.HasValue) return false;

            return IsValidSqlDateTime(dateTime.Value);
        }

        /// <summary>
        /// Generate a random DateTime.
        /// </summary>
        /// <param name="from">The beginning of the range to generate a DateTime from.</param>
        /// <param name="to">The ending of the range to generate a DateTime from.</param>
        /// <returns>A random DateTime object.</returns>
        public static DateTime GenerateRandomDateTime(this DateTime from, DateTime to)
        {
            var random = new Random();

            var range = to - from;
            var randomTimeSpan = new TimeSpan((long)(random.NextDouble() * range.Ticks));

            return from + randomTimeSpan;
        }

        /// <summary>
        /// Return a new DateTime of the first day of the year.
        /// </summary>
        /// <param name="dateTime">The DateTime from which the beginning of the year needs to be found.</param>
        /// <returns>A DateTime-object for the first day of the year.</returns>
        public static DateTime BeginOfYear(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 1, 1, 0, 0, 0);
        }

        /// <summary>
        /// Return a new DateTime of the last day of the year.
        /// </summary>
        /// <param name="dateTime">The DateTime from which the end of the year needs to be found.</param>
        /// <returns>A DateTime-object for the last day of the year.</returns>
        public static DateTime EndOfYear(this DateTime dateTime)
        {
            return dateTime.BeginOfYear().AddYears(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// Return a new DateTime of the first day of the month.
        /// </summary>
        /// <param name="dateTime">The DateTime from which the beginning of the month needs to be found.</param>
        /// <returns>A DateTime object for the first day of the month.</returns>
        public static DateTime BeginOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1, 0, 0, 0);
        }

        /// <summary>
        /// Returns a new DateTime of the last day of the month.
        /// </summary>
        /// <param name="dateTime">The DateTime from which the end of the month needs to be found.</param>
        /// <returns>A DateTime object for the last day of the month.</returns>
        public static DateTime EndOfMonth(this DateTime dateTime)
        {
            return dateTime.BeginOfMonth().AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Return a new DateTime of the first second of the current date.
        /// </summary>
        /// <param name="dateTime">The DateTime from which the beginning of the day needs to be found.</param>
        /// <returns>A DateTime object for the first second of a day.</returns>
        public static DateTime BeginOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        }
        /// <summary>
        /// Return a new DateTime of the last second of the current date.
        /// </summary>
        /// <param name="dateTime">The DateTime from which the end of the day needs to be found.</param>
        /// <returns>A DateTime object for the last second of a day.</returns>

        public static DateTime EndOfDay(this DateTime dateTime)
        {
            return dateTime.BeginOfDay().AddDays(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// Returns a new DateTime of the first second of the hour and date.
        /// </summary>
        /// <param name="dateTime">The DateTime from which the beginning of the hour needs to be found.</param>
        /// <returns>A DateTime object for the first second of the hour.</returns>
        public static DateTime BeginOfHour(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0);
        }

        /// <summary>
        /// Return a new DateTime of the last second of the hour and date.
        /// </summary>
        /// <param name="dateTime">The DateTime from which the end of the hour needs to be found.</param>
        /// <returns>A DateTime object for the last second of the hour.</returns>
        public static DateTime EndOfHour(this DateTime dateTime)
        {
            return dateTime.BeginOfHour().AddHours(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// Return a new DateTime of the first second of the minute and date.
        /// </summary>
        /// <param name="dateTime">The DateTime from which the beginning of the minute needs to be found.</param>
        /// <returns>A DateTime object for the first second of the minute.</returns>
        public static DateTime BeginOfMinute(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0);
        }

        /// <summary>
        /// Return a new DateTime of the last second of the minute and date.
        /// </summary>
        /// <param name="dateTime">The DateTime from which the end of the minute needs to be found.</param>
        /// <returns>A DateTime object for the last second of the minute.</returns>
        public static DateTime EndOfMinute(this DateTime dateTime)
        {
            return dateTime.BeginOfMinute().AddMinutes(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// Returns a new DateTime of the first millisecond of the second and date.
        /// </summary>
        /// <param name="dateTime">The DateTime from which the beginning of the second needs to be found.</param>
        /// <returns>A DateTime object for the first millisecond of the second.</returns>
        public static DateTime BeginOfSecond(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        }

        /// <summary>
        /// Return a new dateTime of the last millisecond of the second and date.
        /// </summary>
        /// <param name="dateTime">The DateTime from which the end of the second needs to be found.</param>
        /// <returns>A DateTime object for the last millisecond of the second.</returns>
        public static DateTime EndOfSecond(this DateTime dateTime)
        {
            return dateTime.BeginOfSecond().AddSeconds(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// Perform an action for every hour in the day.
        /// </summary>
        /// <param name="date">The date for which an action needs to be performed for every hour.</param>
        /// <param name="action">The action to be performed for every hour.</param>
        public static void ForEachHourInDay(this DateTime date, Action<DateTime> action)
        {
            // First make sure the variable "date" is set to the beginning of the day
            date = date.BeginOfDay();
            DateTime nextDay = date.Date.AddDays(1);

            // Then loop through every hour until the next day is reached
            do
            {
                // Perform the action that is needed
                action.Invoke(date);

                // And update the date to the next hour
                date = date.AddHours(1);
            } while (date <= nextDay);
            // Once the day has been fully passed, stop the loop
        }

        /// <summary>
        /// Perform an action for every second in a specific timespan
        /// </summary>
        /// <param name="start">The beginning of the timespan.</param>
        /// <param name="end">The end of the timespan.</param>
        /// <param name="action">The action to be performed for every second.</param>
        public static void ForEachSecondInTimespan(this DateTime start, DateTime end, Action<DateTime> action)
        {
            // Loop through every second until the end is reached
            do
            {
                // Perform the action given
                action.Invoke(start);

                // Also update the date one second further
                start = start.AddSeconds(1);
            } while (start <= end);

            // Once the end has reached, stop the loop
        }

        /// <summary>
        /// Get every day from a certain point to a certain point.
        /// </summary>
        /// <param name="from">The first day.</param>
        /// <param name="thru">The last day.</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (DateTime day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
            {
                yield return day;
            }
        }

        /// <summary>
        /// Checks if the hour of 2 DateTime-variables are different.
        /// This means that the following statement returns FALSE for it has the same hour:
        /// new DateTime(2000, 01, 01, 15, 10, 00).IsDifferentHour(new DateTime(2010, 08, 10, 15, 50, 12))
        /// </summary>
        /// <param name="start">The first DateTime to be compared.</param>
        /// <param name="end">The second DateTime to be compared.</param>
        /// <returns>TRUE = the hour is different | FALSE = the hour is the same</returns>
        public static Boolean IsDifferentHour(this DateTime start, DateTime end)
        {
            if (start.Hour != end.Hour) return true;
            return false;
        }
    }
}
