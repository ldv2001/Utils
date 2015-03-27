using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils.Text
{
    /// <summary>
    /// Class dedicated to operations on/with special chars
    /// </summary>
    public static class StringOperations
    {
        /// <summary>
        /// Function to remove diacritics in a String
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String RemoveDiacritics(this String str)
        {
            var tab = Encoding.GetEncoding(1251).GetBytes(str);
            return Encoding.ASCII.GetString(tab);
        }


        /// <summary>
        /// Allows to use <see cref="Regex.Replace(string,string,string,System.Text.RegularExpressions.RegexOptions)"/> directly on a String
        /// </summary>
        /// <param name="input">The string to compute</param>
        /// <param name="pattern">The Regexp to apply</param>
        /// <param name="replacement">The replacement expression</param>
        /// <param name="options">Regular Expression engine options</param>
        /// <returns></returns>
        public static String RegExpReplace(this String input, String pattern, String replacement, RegexOptions options = RegexOptions.None)
        {
            return Regex.Replace(input, pattern, replacement, options);
        }

        /// <summary>
        /// Check if a string is Empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns>True if empty, false otherwise</returns>
        public static Boolean IsEmpty(this String str)
        {
            return str == null || str.Equals(String.Empty);
        }
    }
}
