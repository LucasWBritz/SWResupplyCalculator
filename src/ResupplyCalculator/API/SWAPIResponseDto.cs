using System.Collections.Generic;

namespace ResupplyCalculator.API
{
    internal class SWAPIResponseDto
    {
        public string Next { get; set; }
        public IEnumerable<StarshipDto> Results { get; set; } = new List<StarshipDto>();
    }
}
