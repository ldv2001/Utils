using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            byte[] tab = System.Text.Encoding.GetEncoding(1251).GetBytes(str);
            return System.Text.Encoding.ASCII.GetString(tab);
        }
    }
}
