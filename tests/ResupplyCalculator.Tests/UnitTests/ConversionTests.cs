using ResupplyCalculator.Helpers;
using Xunit;

namespace ResupplyCalculator.Tests.UnitTests
{
    public class ConversionTests
    {
        [Theory(DisplayName = "Should return false when unable to convert a string to a valid integer.")]
        [InlineData("   ")]
        [InlineData(" --  ")]
        [InlineData("<>,w")]
        [InlineData("-----!!?")]
        public void ShouldReturnFalseWhenUnableToConvertToAValidInteger(string src)
        {
            Assert.False(src.ConvertToValidInteger(out _)); // Using the discard operator to directly discard the output value.
        }

        [Theory(DisplayName = "Should return true when able to convert a string to a valid integer.")]
        [InlineData(" 234  ")]
        [InlineData(" --471  ")]
        [InlineData("<>,344w")]
        [InlineData("----567-!!?")]
        [InlineData("123456789")]
        public void ShouldReturnTrueWhenAbleToConvertToAValidInteger(string src)
        {
            Assert.True(src.ConvertToValidInteger(out _)); // Using the discard operator to directly discard the output value.
        }
    }
}
