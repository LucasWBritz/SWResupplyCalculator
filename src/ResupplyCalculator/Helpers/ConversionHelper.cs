using System;
using System.Text.RegularExpressions;

namespace ResupplyCalculator.Helpers
{
    public static class ConversionHelper
    {
        public static bool ConvertToValidInteger(this string src, out long result)
        {
            if (!String.IsNullOrWhiteSpace(src))
            {
                src = Regex.Replace(src, @"[^\d]", "");
                if (Int64.TryParse(src, out result))
                {
                    return true;
                }
            }
            result = 0;
            return false;
        }

        public static long? ConvertToLongOrNull(this string src)
        {
            if(src.ConvertToValidInteger(out long result))
            {
                return result;
            }
            return null;
        }
    }
}
