using System;

namespace Utils.Misc
{
    public static class Misc
    {
        /// <summary>
        /// Converts a count of Bytes to a human readable format
        /// Inspired from : http://stackoverflow.com/a/3758880/2245256 by aioobe
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="si"></param>
        /// <returns></returns>
        public static String HumanReadableByteCount(long bytes, Boolean si = false, int precision = 2)
        {
            int unit = si ? 1000 : 1024;
            if (bytes < unit) return bytes + " B";
            int exp = (int)(Math.Log(bytes) / Math.Log(unit));
            String pre = (si ? "kMGTPE" : "KMGTPE")[(exp - 1)] + (si ? "" : "i");
            return String.Format("{0} {1}{2}", Math.Round(bytes / Math.Pow(unit, exp), precision), pre, si ? "b" : "B");
        }
    }
}
