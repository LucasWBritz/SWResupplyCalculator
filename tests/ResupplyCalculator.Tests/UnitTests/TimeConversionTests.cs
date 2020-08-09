using ResupplyCalculator.Helpers;
using Xunit;

namespace ResupplyCalculator.Tests.UnitTests
{
    public class TimeConversionTests
    {
        [Theory(DisplayName = "Convert from days to hours")]
        [InlineData("1 day", 24)]
        [InlineData("1 DAY", 24)]
        [InlineData("2 days", 48)]
        [InlineData("10 days", 240)]
        public void ShouldConvertToHoursFromDays(string srcValue, int expectedHours)
        {
            Assert.Equal<int>(expectedHours, srcValue.ComputeConsumablesDuration().Value);
        }

        [Theory(DisplayName = "Convert from weeks to hours")]
        [InlineData("1 week", 168)]
        [InlineData("1 WEEK", 168)]
        [InlineData("2 weeks", 336)]
        [InlineData("10 weeks", 1680)]
        public void ShouldConvertToHoursFromWeeks(string srcValue, int expectedHours)
        {
            Assert.Equal<int>(expectedHours, srcValue.ComputeConsumablesDuration().Value);
        }

        [Theory(DisplayName = "Convert from months to hours")]
        [InlineData("1 month", 720)]
        [InlineData("1 MONTH", 720)]
        [InlineData("2 months", 1440)]
        [InlineData("10 months", 7200)]
        public void ShouldConvertToHoursFromMonths(string srcValue, int expectedHours)
        {
            Assert.Equal<int>(expectedHours, srcValue.ComputeConsumablesDuration().Value);
        }

        [Theory(DisplayName = "Convert from years to hours")]
        [InlineData("1 year", 262800)]
        [InlineData("1 YEAR", 262800)]
        [InlineData("2 years", 525600)]
        [InlineData("10 years", 2628000)]
        public void ShouldConvertToHoursFromYears(string srcValue, int expectedHours)
        {
            Assert.Equal<int>(expectedHours, srcValue.ComputeConsumablesDuration().Value);
        }

        [Theory(DisplayName = "Should return null if there is an error when converting the data")]
        [InlineData("1 dayse", null)]
        [InlineData("1 weeek", null)]
        [InlineData("1 monthse", null)]
        [InlineData("1 yiar", null)]
        [InlineData("s yiars", null)]
        [InlineData("", null)]
        [InlineData("- -", null)]
        public void ShouldNotConvertToHoursWhenInvalidDataIsPassed(string srcValue, int? expectedHours)
        {
            Assert.Equal<int?>(expectedHours, srcValue.ComputeConsumablesDuration());
        }

        [Fact(DisplayName = "Should return null if 'unknown' is converted.")]
        public void ShouldNotConvertToHoursWhenUnknownIsPassed()
        {
            Assert.Null("unknown".ComputeConsumablesDuration());
        }

        [Theory(DisplayName = "Should return true if 'unknown' is being checked.")]
        [InlineData(" ", false)]
        [InlineData("-", false)]
        [InlineData("", false)]
        [InlineData(" , unknow", false)]
        [InlineData(" unknown", true)]
        [InlineData(" UNknoWN", true)]
        [InlineData("unknown", true)]
        public void ShouldReturnTrueOnlyIfUnknownIsPassed(string value, bool expectedResult)
        {
            Assert.Equal(expectedResult, value.IsUnknown());
        }
    }
}
