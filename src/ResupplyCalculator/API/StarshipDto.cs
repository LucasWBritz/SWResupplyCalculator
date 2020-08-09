using Newtonsoft.Json;

namespace ResupplyCalculator.API
{
    public class StarshipDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("consumables")]
        public string Consumables { get; set; }

        [JsonProperty("MGLT")]
        public string MGLT { get; set; }
    }
}
