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
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="replacement"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static String RegExpReplace(this String input, String pattern, String replacement, RegexOptions options = RegexOptions.None)
        {
            return Regex.Replace(input, pattern, replacement, options);
        }
    }
}
