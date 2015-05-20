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
            str1 = StringOperations.RemoveDiacritics(str1.ToLower());
            str2 = StringOperations.RemoveDiacritics(str2.ToLower());
            return str1 == str2;
        }
    }
}
