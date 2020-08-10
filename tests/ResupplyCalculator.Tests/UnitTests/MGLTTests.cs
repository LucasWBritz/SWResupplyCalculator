using ResupplyCalculator.API;
using ResupplyCalculator.Helpers;
using Xunit;

namespace ResupplyCalculator.Tests.UnitTests
{
    public class MGLTTests
    {
        [Theory(DisplayName = "Should compute the number of resupply stops required for a given starship.")]
        [InlineData(1000, 80, 24, 0)]
        [InlineData(50000, 80, 24, 26)]
        [InlineData(1000000, 75, 1440, 9)] // Millenium Falcon
        [InlineData(1000000, 80, 168, 74)] // Y-Wing
        [InlineData(1000000, 20, 4320, 11)] // Rebel Transport
        public void ShouldComputeTheNumberOfResupplyStops(int distance, int mglt, int consumableHours, int result)
        {
            Starship s = new Starship()
            {
                Name = "Test ship",
                MGLT = mglt,
                AvailableConsumablesInHours = consumableHours
            };
            var numberOfStops = s.ComputeNumberOfStops(distance);
            Assert.Equal(result, numberOfStops);
        }


        [Theory(DisplayName = "Should return null if a spaceship does not have all the required parameters.")]       
        [InlineData(1000000, 75, null)]
        [InlineData(1000000, null, 168)]
        [InlineData(1000000, null, null)]
        public void ShouldReturnNullOnInvalidSpaceship(int distance, int? mglt, int? consumableHours)
        {
            Starship s = new Starship()
            {
                Name = "Test ship",
                MGLT = mglt,
                AvailableConsumablesInHours = consumableHours
            };
            var numberOfStops = s.ComputeNumberOfStops(distance);
            Assert.Null(numberOfStops);
        }
    }
}
