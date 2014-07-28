using System;
using System.Collections.ObjectModel;
using System.Text;

namespace Archimind.Platform.Core.Text
{
    /// <summary>
    /// Helper class to manipulate strings.
    /// </summary>
    public static class Strings
    {
        #region Public Methods

        /// <summary>
        /// Returns a boolean indicating if value1 is lesser than value2.
        /// </summary>
        /// <param name="value1">First string to compare.</param>
        /// <param name="value2">Second string to compare.</param>
        /// <returns>A boolean indicating if value1 is less than value2.</returns>
        public static bool LessThan(string value1, string value2)
        {
            return LessThan(value1, value2, true);
        }

        /// <summary>
        /// Returns a boolean indicating if value1 is lesser than value2.
        /// </summary>
        /// <param name="value1">First string to compare.</param>
        /// <param name="value2">Second string to compare.</param>
        /// <param name="ignoreCase">Ignore case.</param>
        /// <returns>A boolean indicating if value1 is less than value2.</returns>
        public static bool LessThan(string value1, string value2, bool ignoreCase)
        {
            return string.Compare(value1, value2, ignoreCase, Internal.Application.UICulture) < 0;
        }

        /// <summary>
        /// Returns a boolean indicating if value1 is lesser or equal to value2.
        /// </summary>
        /// <param name="value1">First string to compare.</param>
        /// <param name="value2">Second string to compare.</param>
        /// <returns>A boolean indicating if value1 is less than or equal to value2.</returns>
        public static bool LessThanOrEqualTo(string value1, string value2)
        {
            return LessThanOrEqualTo(value1, value2, true);
        }

        /// <summary>
        /// Returns a boolean indicating if value1 is lesser or equal to value2.
        /// </summary>
        /// <param name="value1">First string to compare.</param>
        /// <param name="value2">Second string to compare.</param>
        /// <param name="ignoreCase">Ignore case.</param>
        /// <returns>A boolean indicating if value1 is less than or equal to value2.</returns>
        public static bool LessThanOrEqualTo(string value1, string value2, bool ignoreCase)
        {
            return string.Compare(value1, value2, ignoreCase, Internal.Application.UICulture) <= 0;
        }

        /// <summary>
        /// Returns a boolean indicating if value1 is greater than value2.
        /// </summary>
        /// <param name="value1">First string to compare.</param>
        /// <param name="value2">Second string to compare.</param>
        /// <returns>A boolean indicating if value1 is greater than value2.</returns>
        public static bool GreaterThan(string value1, string value2)
        {
            return GreaterThan(value1, value2, true);
        }

        /// <summary>
        /// Returns a boolean indicating if value1 is greater than value2.
        /// </summary>
        /// <param name="value1">First string to compare.</param>
        /// <param name="value2">Second string to compare.</param>
        /// <param name="ignoreCase">Ignore case.</param>
        /// <returns>A boolean indicating if value1 is greater than value2.</returns>
        public static bool GreaterThan(string value1, string value2, bool ignoreCase)
        {
            return string.Compare(value1, value2, ignoreCase, Internal.Application.UICulture) > 0;
        }

        /// <summary>
        /// Returns a boolean indicating if value1 is greater or equal to value2.
        /// </summary>
        /// <param name="value1">First string to compare.</param>
        /// <param name="value2">Second string to compare.</param>
        /// <returns>A boolean indicating if value1 is greater than or equal to value2.</returns>
        public static bool GreaterThanOrEqualTo(string value1, string value2)
        {
            return GreaterThanOrEqualTo(value1, value2, true);
        }

        /// <summary>
        /// Returns a boolean indicating if value1 is greater or equal to value2.
        /// </summary>
        /// <param name="value1">First string to compare.</param>
        /// <param name="value2">Second string to compare.</param>
        /// <param name="ignoreCase">Ignore case.</param>
        /// <returns>A boolean indicating if value1 is greater than or equal to value2.</returns>
        public static bool GreaterThanOrEqualTo(string value1, string value2, bool ignoreCase)
        {
            return string.Compare(value1, value2, ignoreCase, Internal.Application.UICulture) >= 0;
        }

        /// <summary>
        /// Returns a string that contains only the length left most characters of the original string.
        /// </summary>
        /// <param name="text">The original string.</param>
        /// <param name="length">The number of characters to return.</param>
        /// <returns>A string that contains only the length left most characters of the original string.</returns>
        public static string Left(string text, int length)
        {
            if (text == null)
            {
                return null;
            }
            else
            {
                if (length > text.Length)
                {
                    length = text.Length;
                }

                return text.Substring(0, length);
            }
        }

        /// <summary>
        /// Returns a string that contains only the length right most characters of the original string.
        /// </summary>
        /// <param name="text">The original string.</param>
        /// <param name="length">The number of characters to return.</param>
        /// <returns>A string that contains only the length right most characters of the original string.</returns>
        public static string Right(string text, int length)
        {
            if (text == null)
            {
                return null;
            }
            else
            {
                if (length > text.Length)
                {
                    length = text.Length;
                }

                return text.Substring(text.Length - length, length);
            }
        }

        /// <summary>
        /// Returns the string that corresponds to an array of bytes.
        /// </summary>
        /// <remarks>The array must be in UTF8 encoding.</remarks>
        /// <param name="value">Array of bytes that contains the string.</param>
        /// <returns>The string that corresponds to an array of bytes.</returns>
        public static string GetString(byte[] value)
        {
            return Encoding.UTF8.GetString(value);
        }

        /// <summary>
        /// Returns the array of bytes that represents a string.
        /// </summary>
        /// <remarks>The array is returned in UTF8 encoding.</remarks>
        /// <param name="text">The string.</param>
        /// <returns>The array of bytes that corresponds to the string.</returns>
        public static byte[] GetBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        /// <summary>
        /// Returns a collection of the substrings of text that are delimited by the specified separator.
        /// </summary>
        /// <param name="text">The string where substrings will be searched.</param>
        /// <param name="separator">The separator of the substrings.</param>
        /// <returns>Collection of String.</returns>
        public static Collection<string> Split(string text, char separator)
        {
            Collection<string> result = new Collection<string>();
            string[] parts = text.Split(new char[] { separator }, StringSplitOptions.None);

            foreach (string part in parts)
            {
                result.Add(part);
            }

            return result;
        }

        /// <summary>
        /// Removes all occurrences of a specific char in a string.
        /// </summary>
        /// <param name="text">The string from where the char will be removed.</param>
        /// <param name="character">The char to remove.</param>
        /// <returns>The string without all occurrences of the specified char.</returns>
        public static string RemoveChar(string text, char character)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            return text.Replace(new string(character, 1), string.Empty);
        }

        /// <summary>
        /// Replaces the last numberOfChars characters of a string with another string.
        /// </summary>
        /// <param name="text">The string whose characters will be replaced.</param>
        /// <param name="numberOfChars">The number of characters to replace.</param>
        /// <param name="replacement">The string that will replace the original characters.</param>
        /// <returns>The string with the specified char replaced.</returns>
        public static string ReplaceAtEnd(string text, int numberOfChars, string replacement)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            return text.Substring(0, text.Length - numberOfChars) + replacement;
        }

        /// <summary>
        /// Replaces the first numberOfChars characters of a string with another string.
        /// </summary>
        /// <param name="text">The string whose characters will be replaced.</param>
        /// <param name="numberOfChars">The number of characters to replace.</param>
        /// <param name="replacement">The string that will replace the original characters.</param>
        /// <returns>The string with the specified chars replaced.</returns>
        public static string ReplaceAtBeginning(string text, int numberOfChars, string replacement)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            return replacement + text.Substring(numberOfChars);
        }

        /// <summary>
        /// Remove the first numberOfChars characters of a string.
        /// </summary>
        /// <param name="text">The string whose characters will be removed.</param>
        /// <param name="numberOfChars">The number of characters to remove.</param>
        /// <returns>The string with the specified chars removed.</returns>
        public static string RemoveAtBeginning(string text, int numberOfChars)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            return text.Substring(numberOfChars);
        }

        /// <summary>
        /// Remove the last numberOfChars characters of a string.
        /// </summary>
        /// <param name="text">The string whose characters will be removed.</param>
        /// <param name="numberOfChars">The number of characters to remove.</param>
        /// <returns>The string without the specified chars.</returns>
        public static string RemoveAtEnd(string text, int numberOfChars)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            return text.Substring(0, text.Length - numberOfChars);
        }

        /// <summary>
        /// Compares a string to null and returns another string if it's null.
        /// </summary>
        /// <param name="value">String to compare.</param>
        /// <param name="valueIfNull">Replacement string (if null).</param>
        /// <returns>The string after the comparison.</returns>
        public static string IfNull(string value, string valueIfNull)
        {
            return value == null ? valueIfNull : value;
        }

        /// <summary>
        /// Compares a string to null or the empty string and returns another string if it's null or empty.
        /// </summary>
        /// <param name="value">String to compare.</param>
        /// <param name="valueIfNull">Replacement string.</param>
        /// <returns>The string after the comparison.</returns>
        public static string IfNullOrEmpty(string value, string valueIfNull)
        {
            return value == null ? valueIfNull : (value.Length == 0 ? valueIfNull : value);
        }

        /// <summary>
        /// Compares a string to the empty string and returns another string if it's empty.
        /// </summary>
        /// <param name="value">String to compare.</param>
        /// <param name="valueIfEmpty">Replacement string.</param>
        /// <returns>The string after the comparison.</returns>
        public static string IfEmpty(string value, string valueIfEmpty)
        {
            if (value == null)
            {
                return value;
            }

            return value.Length == 0 ? valueIfEmpty : value;
        }

        /// <summary>
        /// Verifies if a string is not null.
        /// </summary>
        /// <param name="value">String to compare.</param>
        /// <returns>Boolean that indicates if the string is not null.</returns>
        public static bool IsNotNull(string value)
        {
            return !IsNull(value);
        }

        /// <summary>
        /// Verifies if an object is of type string.
        /// </summary>
        /// <param name="value">The object whose type will be evaluated.</param>
        /// <returns>Boolean that indicates if the object is a string.</returns>
        public static bool IsString(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.GetType() == typeof(string);
        }

        /// <summary>
        /// Verifies if a string is null.
        /// </summary>
        /// <param name="value">String to compare.</param>
        /// <returns>Boolean that indicates if the string is null.</returns>
        public static bool IsNull(string value)
        {
            return value == null;
        }

        /// <summary>
        /// Verifies if a string is not null and not equal to the empty string.
        /// </summary>
        /// <param name="value">String to compare.</param>
        /// <returns>Boolean that indicates if the string is not null and not equal to the empty string.</returns>
        public static bool IsNotNullOrEmpty(string value)
        {
            return !IsNullOrEmpty(value);
        }

        /// <summary>
        /// Verifies if a string is null or equal to the empty string.
        /// </summary>
        /// <param name="value">String to compare.</param>
        /// <returns>Boolean that indicates if the string is null or equal to the empty string.</returns>
        public static bool IsNullOrEmpty(string value)
        {
            return value == null ? true : (value.Length == 0);
        }

        /// <summary>
        /// Verifies if a string is equal to the empty string.
        /// </summary>
        /// <param name="value">String to compare.</param>
        /// <returns>Boolean that indicates if the string is equal to the empty string.</returns>
        /// <remarks>The null string is considered not equal to the empty string.</remarks>
        public static bool IsEmpty(string value)
        {
            return value == null ? false : (value.Length == 0);
        }

        /// <summary>
        /// Verifies if a string is not equal to the empty string.
        /// </summary>
        /// <param name="value">String to compare.</param>
        /// <returns>Boolean that indicates if the string is not equal to the empty string.</returns>
        /// <remarks>The null string is considered not equal to the empty string.</remarks>
        public static bool IsNotEmpty(string value)
        {
            return !IsEmpty(value);
        }

        #endregion
    }
}
