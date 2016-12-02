using System;
using System.IO;

namespace ExtensionMethodCollection.Extensions
{
    /// <summary>
    /// Extension-methods for the String-object.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Get substring of specified number of characters on the right.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="length">The length beginning from right.</param>
        /// <returns>A converted string-value.</returns>
        public static String Right(this string value, int length)
        {
            if (String.IsNullOrWhiteSpace(value)) return value;

            length = Math.Abs(length);

            return value.Substring(value.Length - length);
        }

        /// <summary>
        /// Get substring of specified number of characters on the left.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="length">The length beginning from left.</param>
        /// <returns>A converted string-value.</returns>
        public static String Left(this string value, int length)
        {
            if (String.IsNullOrWhiteSpace(value)) return value;

            length = Math.Abs(length);

            return value.Substring(0, length);
        }

        /// <summary>
        /// Make the filename valid.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>The valid filename.</returns>
        public static String MakeValidFilename(this string filename)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                filename = filename.Replace(c, '_');
            }

            return filename;
        }

        /// <summary>
        /// Make the filename valid and make sure the prefix ".txt" is added.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>The valid filename.</returns>
        public static String MakeValidFilenameForTxtFile(this string filename)
        {
            filename = filename.MakeValidFilename();
            if (!filename.EndsWith(".txt")) filename = filename + ".txt";

            return filename;
        }
    }
}
