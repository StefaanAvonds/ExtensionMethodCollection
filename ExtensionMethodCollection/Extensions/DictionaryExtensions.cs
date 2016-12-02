using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethodCollection.Extensions
{
    /// <summary>
    /// Extension-methods for the Dictionary-object.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Loop through all entries inside the Dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary itself.</param>
        /// <param name="action">The action to be invoked for each element in the dictionary.</param>
        public static void ForEach<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Action<TKey, TValue> action)
        {
            if (dictionary == null) return;

            foreach (KeyValuePair<TKey, TValue> entry in dictionary)
            {
                action.Invoke(entry.Key, entry.Value);
            }
        }

        /// <summary>
        /// Adds a new item if Key isn't found in the Dictionary.
        /// Updates the item if Key is found.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary itself.</param>
        /// <param name="item">The element to add or update.</param>
        public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary == null) return;

            TValue temp;
            if (dictionary.TryGetValue(key, out temp)) dictionary.Remove(key);
            dictionary.Add(key, value);
        }

        /// <summary>
        /// Adds a new item if Key isn't found in the Dictionary.
        /// Increments Value if Key is found.
        /// Can only be used by Dictionary with an integer value!!
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary itself.</param>
        /// <param name="key">The key of the value to add or increment.</param>
        /// <param name="value">The value to add or increment.</param>
        public static void AddOrIncrement<TKey>(this Dictionary<TKey, int> dictionary, TKey key, int value)
        {
            int temp = 0;
            if (dictionary.TryGetValue(key, out temp)) dictionary.Remove(key);
            dictionary.Add(key, value + temp);
        }

        /// <summary>
        /// Return an ordered dictionary by key.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary..</typeparam>
        /// <param name="dictionary">The dictionary itself.</param>
        /// <returns>A sorted dictionary.</returns>
        public static Dictionary<TKey, TValue> OrderByKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            return dictionary.OrderBy(x => x.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        /// <summary>
        /// Return an empty Dictionary of DateTime and Integer for every hour of the current date.
        /// </summary>
        /// <returns>An empty dictionary with the value 0 for every hour of the current date.</returns>
        public static Dictionary<DateTime, int> NewEmptyIntegerDictionaryForEveryHourOfToday()
        {
            return new Dictionary<DateTime, int>().NewEmptyIntegerDictionaryForEveryHourOfToday();
        }

        /// <summary>
        /// Return an empty Dictionary of DateTime and Integer for every hour of the current date.
        /// </summary>
        /// <param name="dictionary">The dictionary itself.</param>
        /// <returns>An empty dictionary with the value 0 for every hour of the current date.</returns>
        public static Dictionary<DateTime, int> NewEmptyIntegerDictionaryForEveryHourOfToday(this Dictionary<DateTime, int> dictionary)
        {
            return dictionary.NewEmptyIntegerDictionaryForEveryHourOfDay(DateTime.Today);
        }

        /// <summary>
        /// Return an empty Dictionary of DateTime and Integer for every hour of a specific date.
        /// </summary>
        /// <param name="day">The specific date for the dictionary to fill its values.</param>
        /// <returns>An empty dictionary with the value 0 for every hour of a specific date.</returns>
        public static Dictionary<DateTime, int> NewEmptyIntegerDictionaryForEveryHourOfDay(DateTime day)
        {
            return new Dictionary<DateTime, int>().NewEmptyIntegerDictionaryForEveryHourOfDay(day);
        }

        /// <summary>
        /// Return an empty Dictionary of DateTime and Integer for every hour of a specific date.
        /// </summary>
        /// <param name="dictionary">The dictionary itself.</param>
        /// <param name="day">The specific date for the dictionary to fill its values.</param>
        /// <returns>An empty dictionary with the value 0 for every hour of a specific date.</returns>
        public static Dictionary<DateTime, int> NewEmptyIntegerDictionaryForEveryHourOfDay(this Dictionary<DateTime, int> dictionary, DateTime day)
        {
            day = day.BeginOfDay();
            // Instantiate new dictionary
            dictionary = new Dictionary<DateTime, int>();

            // Loop through every hour of the date and make the value 0
            day.ForEachHourInDay((hour) => dictionary.Add(hour, 0));

            return dictionary;
        }

        /// <summary>
        /// Return an empty Dictionary of DateTime and Integer for every second during a specific Timespan.
        /// </summary>
        /// <param name="start">The beginning of the TimeSpan.</param>
        /// <param name="end">The end of the TimeSpan.</param>
        /// <returns>An empty dictionary with the value 0 for every second in a specific TimeSpan.</returns>
        public static Dictionary<DateTime, int> NewEmptyIntegerDictionaryForEverySecondInTimespan(DateTime start, DateTime end)
        {
            return new Dictionary<DateTime, int>().NewEmptyIntegerDictionaryForEverySecondInTimespan(start, end);
        }

        /// <summary>
        /// Return an empty Dictionary of DateTime and Integer for every second during a specific Timespan.
        /// </summary>
        /// <param name="dictionary">The dictionary itself.</param>
        /// <param name="start">The beginning of the TimeSpan.</param>
        /// <param name="end">The end of the TimeSpan.</param>
        /// <returns>An empty dictionary with the value 0 for every second in a specific TimeSpan.</returns>
        public static Dictionary<DateTime, int> NewEmptyIntegerDictionaryForEverySecondInTimespan(this Dictionary<DateTime, int> dictionary, DateTime start, DateTime end)
        {
            dictionary = new Dictionary<DateTime, int>();
            start = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, start.Second);
            end = new DateTime(end.Year, end.Month, end.Day, end.Hour, end.Minute, end.Second);

            // If the end DateTime is smaller than start => return an empty Dictionary
            if (end < start) return dictionary;

            // Else loop through every second within the timespan and insert the value 0
            start.ForEachSecondInTimespan(end, (second) => dictionary.Add(second, 0));

            return dictionary;
        }

        /// <summary>
        /// Return an empty Dictionary of DateTime and Decimal for every second during a specific Timespan.
        /// </summary>
        /// <param name="start">The beginning of the TimeSpan.</param>
        /// <param name="end">The end of the TimeSpan.</param>
        /// <returns>An empty dictionary with the value 0 for every second in a specific TimeSpan.</returns>
        public static Dictionary<DateTime, decimal> NewEmptyDecimalDictionaryForEverySecondInTimespan(DateTime start, DateTime end)
        {
            return new Dictionary<DateTime, decimal>().NewEmptyDecimalDictionaryForEverySecondInTimespan(start, end);
        }

        /// <summary>
        /// Return an empty Dictionary of DateTime and Integer for every second during a specific Timespan.
        /// </summary>
        /// <param name="dictionary">The dictionary itself.</param>
        /// <param name="start">The beginning of the TimeSpan.</param>
        /// <param name="end">The end of the TimeSpan.</param>
        /// <returns>An empty dictionary with the value 0 for every second in a specific TimeSpan.</returns>
        public static Dictionary<DateTime, decimal> NewEmptyDecimalDictionaryForEverySecondInTimespan(this Dictionary<DateTime, decimal> dictionary, DateTime start, DateTime end)
        {
            dictionary = new Dictionary<DateTime, decimal>();

            // If the end DateTime is smaller than start => return an empty Dictionary
            if (end < start) return dictionary;

            // Else loop through every second within the timespan and insert the value 0
            start.ForEachSecondInTimespan(end, (second) => dictionary.Add(second, 0));

            return dictionary;
        }
    }
}
