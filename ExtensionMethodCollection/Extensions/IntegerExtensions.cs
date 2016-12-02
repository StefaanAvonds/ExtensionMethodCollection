using System;
using System.Text;

namespace ExtensionMethodCollection.Extensions
{
    /// <summary>
    /// Extension-methods for the Integer-object.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Convert an integer to a string-value with a specific length.
        /// If the length requested is shorter than the integer-value, the integer-value will be returned.
        /// For example: 1234.ConvertToLongString(2) will result in "1234".
        /// 
        /// If the length requested is greater than the integer-value, the remaining characters will be filled with 0.
        /// For example: 15.ConvertToLongString(5) will result in "00015".
        /// </summary>
        /// <param name="value">The integer-value to convert to a string-value.</param>
        /// <param name="length">The requested length for the string-value.</param>
        /// <returns>A converted string-value.</returns>
        public static String ConvertToLongString(this int value, int length)
        {
            length = Math.Abs(length);

            int intLength = value.IntLength();
            if (intLength > length) return value.ToString();

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < length; i++) builder.Append("0");

            string stringValue = builder.ToString() + value;

            return stringValue.Right(length);
        }

        /// <summary>
        /// Get the length of the integer.
        /// For example: 98413518.IntLength() will result in "8".
        /// </summary>
        /// <param name="value">Integer value.</param>
        /// <returns>The length of the integer-value.</returns>
        public static int IntLength(this int value)
        {
            if (value < 0) return 0;
            if (value == 0) return 1;

            return (int)Math.Floor(Math.Log10(value)) + 1;
        }
    }
}
