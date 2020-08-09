namespace ResupplyCalculator.API
{
    public class Starship
    {
        public string Name { get; set; }
        public long? MGLT { get; set; }
        public long? AvailableConsumablesInHours { get; set; }

        public bool CanComputeNumberOfStops()
        {
            return MGLT.HasValue && AvailableConsumablesInHours.HasValue;
        }
    }
}
