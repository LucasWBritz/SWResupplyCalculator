using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ResupplyCalculator.API
{
    public static class SWAPIClient
    {
        /// <summary>
        /// Download all the starship data from the api.
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<StarshipDto>> DownloadStarshipsData()
        {
            /*
             * We will start downloading page 1 and keep going until we reach the end of the pagination.
             */ 

            List<StarshipDto> starShips = new List<StarshipDto>();
            SWAPIResponseDto response = await DownloadUrl("https://swapi.dev/api/starships/?page=1");                        
            if (response != null)
            {
                bool stopDownloading;
                do
                {
                    starShips.AddRange(response.Results);
                    if (!String.IsNullOrWhiteSpace(response.Next))
                    {
                        stopDownloading = false;
                        response = await DownloadUrl(response.Next);
                    }
                    else
                        stopDownloading = true;

                } while (!stopDownloading);
            }
            return starShips;
        }

        /// <summary>
        /// Downloads the content of the given url.
        /// </summary>        
        private static async Task<SWAPIResponseDto> DownloadUrl(string url)
        {
            using (var webClient = new HttpClient())
            {
                var requestResponse = await webClient.GetAsync(url);
                if (requestResponse.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<SWAPIResponseDto>(await requestResponse.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception($"Error while downloading url: {url}.");
                }
            }
        }
    }
}
