using ResupplyCalculator.API;
using ResupplyCalculator.Enums;
using ResupplyCalculator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResupplyCalculator
{
    public class ResupplyCalculatorService
    {
        public List<Starship> Ships { get; private set; }

        public ResupplyCalculatorService()
        {

        }

        /// <summary>
        /// Loads the data from the api and converts to a collection of Starship.
        /// </summary>
        /// <returns></returns>
        public async Task LoadShips()
        {
            var loadedData = await SWAPIClient.DownloadStarshipsData();
            if (loadedData != null)
            {
                Ships = loadedData.Select(x => new Starship()
                {
                    Name = x.Name,
                    MGLT = x.MGLT.ConvertToIntOrNull(),
                    AvailableConsumablesInHours = x.Consumables.ComputeConsumablesDuration()
                }).ToList();
            }
        }

        /// <summary>
        /// Compute the number of stops given a distance in MGLT for each starship
        /// </summary>
        /// <param name="distance">Distance in MGLT</param>
        public IEnumerable<ResupplyStopsResult> CalculateResupplyStops(long distance, Ordenation ordenation)
        {
            Func<ResupplyStopsResult, object> orderBy = x => x.SpaceshipName;
            if (ordenation == Ordenation.ByNumberOfStops)
                orderBy = x => x.NumberOfStops;

            return Ships.AsParallel().Select(x => new ResupplyStopsResult()
            {
                SpaceshipName = x.Name,
                NumberOfStops = x.ComputeNumberOfStops(distance)
            }).OrderBy(orderBy);
        }
    }
}
