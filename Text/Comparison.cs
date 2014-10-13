using System;

namespace Utils.Text
{
    /// <summary>
    /// Class dedicated to comparison text functions
    /// </summary>
    public static class Comparison
    {
        /// <summary>
        /// A case insensitive comparison function
        /// </summary>
        /// <param name="str1">First string to be compared</param>
        /// <param name="str2">Second string to be compared</param>
        /// <returns></returns>
        public static bool CaseInsensitiveComparison(String str1, String str2)
        {
            str1 = SpecialChars.RemoveDiacritics(str1.ToLower());
            str2 = SpecialChars.RemoveDiacritics(str2.ToLower());
            if (str1 == str2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
