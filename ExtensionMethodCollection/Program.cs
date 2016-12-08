using ExtensionMethodCollection.Extensions;
using ExtensionMethodCollection.Translations;
using System;

namespace ExtensionMethodCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = DateTime.Today.BeginOfYear();
            Console.WriteLine($"Begin of current year: {date.ConvertToString(DateTimeTranslationOptions.DayMonthYearHourMinuteSecond)}");
            date = DateTime.Today.EndOfYear();
            Console.WriteLine($"End of current year: {date.ConvertToString(DateTimeTranslationOptions.DayMonthYearHourMinuteSecond)}");
            date = DateTime.Today.BeginOfYear().GenerateRandomDateTime(DateTime.Today.EndOfYear());
            Console.WriteLine($"Random day of current year: {date.ConvertToString(DateTimeTranslationOptions.DayMonthYearHourMinuteSecond)}");

            Console.ReadLine();
        }
    }
}
