using ResupplyCalculator.API;

namespace ResupplyCalculator.Helpers
{
    public static class MGLTHelper
    {
        /// <summary>
        /// Will compute the number of times a ship needs to stop to resupply.
        /// Will divide the target distance by the speed per hour multiplied the number of hours of availble resources. 
        /// </summary>
        /// <param name="ship">The ship object</param>
        /// <param name="distance">The final distance</param>
        public static long? ComputeNumberOfStops(this Starship ship, long distance)
        {
            if (distance <= 0 || !ship.CanComputeNumberOfStops())
                return null;
            return distance / (ship.AvailableConsumablesInHours * ship.MGLT);
        }
    }
}
