using System;

namespace ResupplyCalculator.Helpers
{
    public static class TimeConversionHelper
    {
        private static readonly Func<int, int> ConvertDays = (days) => days * 24;
        private static readonly Func<int, int> ConvertWeeks = (weeks) => weeks * 7 * 24;
        private static readonly Func<int, int> ConvertMonths = (months) => months * 30 * 24; // I'm using 30 days as the total days for 1 month.
        private static readonly Func<int, int> ConvertYears = (years) => years * 365 * 30 * 24;  // I'm using 365 as the total days for 1 year.

        private static int? ConvertToHours(string type, int ammount)
        {
            switch (type)
            {
                case "day":
                case "days":
                    return ConvertDays(ammount);
                case "week":
                case "weeks":
                    return ConvertWeeks(ammount);
                case "month":
                case "months":
                    return ConvertMonths(ammount);
                case "year":
                case "years":
                    return ConvertYears(ammount);
                default:
                    return null;
            }
        }

        public static bool IsUnknown(this string src)
        {
            return src.ToLower().Trim() == "unknown";
        }

        public static int? ComputeConsumablesDuration(this string src)
        {
            if (String.IsNullOrWhiteSpace(src) || src.IsUnknown())
            {
                return null;
            }
            string[] elements = src.ToLower().Trim().Split(' ');
            if (elements.Length != 2)
                return null;

            int number = 0;
            if (!Int32.TryParse(elements[0], out number))
            {
                return null;
            }

            return ConvertToHours(elements[1], number);
        }
    }
}
