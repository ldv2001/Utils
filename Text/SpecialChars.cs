using System;
using System.Text;

namespace Utils.Text
{
    /// <summary>
    /// Class dedicated to operations on/with special chars
    /// </summary>
    class SpecialChars
    {
        /// <summary>
        /// Function to remove diacritics in a String
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String RemoveDiacritics(String str)
        {
            var tab = Encoding.GetEncoding(1251).GetBytes(str);
            return Encoding.ASCII.GetString(tab);
        }
    }
}
