using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// Class dedicated to Text util functions
    /// </summary>
    public static class Text
    {
        /// <summary>
        /// A case insensitive comparison function
        /// </summary>
        /// <param name="str1">First string to be compared</param>
        /// <param name="str2">Second string to be compared</param>
        /// <returns></returns>
        public static bool CaseInsensitiveComparison(String str1, String str2)
        {
            str1 = RemoveDiacritics(str1.ToLower());
            str2 = RemoveDiacritics(str2.ToLower());
            if (str1 == str2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Function to remove diacritics in a String
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String RemoveDiacritics(String str)
        {
            byte[] tab = System.Text.Encoding.GetEncoding(1251).GetBytes(str);
            return System.Text.Encoding.ASCII.GetString(tab);
        }
    }
}
