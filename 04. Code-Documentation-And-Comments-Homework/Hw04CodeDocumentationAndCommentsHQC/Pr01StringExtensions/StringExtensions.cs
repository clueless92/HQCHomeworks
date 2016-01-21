namespace Pr01StringExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    public static class StringExtensions
    {
        /// <summary>
        /// Uses the MD5 message-digest algorithm as a hash function to produce a 128bit hash value from a string.
        /// The hash value is expressed in text (string) format as a 32 digit hexadecimal number.
        /// </summary>
        /// <param name="input">String value to get hash value from.</param>
        /// <returns>String</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Tries to parse a string to a Boolean.
        /// Returns true for any of the following values (case insensitive): "true", "ok", "yes", "1", "да"
        /// and false for everything else.
        /// </summary>
        /// <param name="input">String value to be parsed.</param>
        /// <returns>Boolean</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" }; // anything else is false
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Tries to parse a string to a 16 bit signed integer. If the string cannot be parsed - returns 0.
        /// </summary>
        /// <param name="input">String value to be parsed.</param>
        /// <returns>Int16</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Tries to parse a string to a 32 bit signed integer. If the string cannot be parsed - returns 0.
        /// </summary>
        /// <param name="input">String value to be parsed.</param>
        /// <returns>Int32</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Tries to parse a string to a 64 bit signed integer. If the string cannot be parsed - returns 0.
        /// </summary>
        /// <param name="input">String value to be parsed.</param>
        /// <returns>Int64</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Tries to parse a string to DateTime using Invariant culture separators.
        /// If the string cannot be parsed - returns 0001-01-01 00:00:00.
        /// </summary>
        /// <param name="input">String value to be parsed.</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Using current culture settings attempts to capitalize the first letter in a string and returns a copy of it.
        /// If the string is empty or the first character is not a letter - returns a copy of the unaltered string.
        /// </summary>
        /// <param name="input">String value to have first character capitalized.</param>
        /// <returns>String</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return 
                input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + 
                input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns the string between a specified start and end string. If nothing is found returns an empty string.
        /// Can optionally start search from a specified character index.
        /// </summary>
        /// <param name="input">String to be searched.</param>
        /// <param name="startString">Start string value.</param>
        /// <param name="endString">End string value.</param>
        /// <param name="startFrom">Index value for search start.</param>
        /// <returns>String</returns>
        public static string GetStringBetween(
            this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = 
                input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }


        /// <summary>
        /// Converts all bulgarian cyrillic letters in a string to their latin representations.
        /// </summary>
        /// <param name="input">Input string with cyrillic letters.</param>
        /// <returns>String of only latin latters.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
            {
                "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
                "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
            };
            var latinRepresentationsOfBulgarianLetters = new[]
            {
                "a", "b", "v", "g", "d", "e", "zh", "z", "i", "j", "k", "l", "m", "n", "o",
                "p", "r", "s", "t", "u", "f", "h", "c", "ch", "sh", "sht", "y", "i", "iu", "q"
            };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(),
                    latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts all latin letters in a string to their bulgarian cyrillic representations.
        /// </summary>
        /// <param name="input">Input string with latin letters.</param>
        /// <returns>String of only cyrillic latters.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
                "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

            var bulgarianRepresentationOfLatinKeyboard = new[]
            {
                "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к", "л", "м",
                "н", "о", "п", "я", "р", "с", "т", "у", "ж", "в", "ь", "ъ", "з"
            };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(),
                    bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Transforms or removes all invalid characters in a string representing a username and returns the new string.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>String of only valid characters.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Transforms or removes all invalid characters in a string representing a file name and returns the new string.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>String of only valid characters.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns a substring from 0 to the specified count.
        /// If the count is greater than the original string length - returns a copy of the original string.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="charsCount">Char count.</param>
        /// <returns>String</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns the extention from a full file name.
        /// </summary>
        /// <param name="fileName">Input string.</param>
        /// <returns>String</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Converts a file extention string to its corresponding file type.
        /// </summary>
        /// <param name="fileExtension">Input string.</param>
        /// <returns>String</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
            {
                { "jpg", "image/jpeg" },
                { "jpeg", "image/jpeg" },
                { "png", "image/x-png" },
                { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                { "doc", "application/msword" },
                { "pdf", "application/pdf" },
                { "txt", "text/plain" },
                { "rtf", "application/rtf" }
            };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }


        /// <summary>
        /// Converts a string to a byte array of the Int8 representations of the characters in the string.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Byte[]</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
