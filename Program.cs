using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPICleint
{
    class TheCar
    {
        [JsonProperty("launch_date_utc")]
        public string LaunchDate { get; set; }

        [JsonProperty("earth_distance_mi")]
        public double DistanceFromEarth { get; set; }

        [JsonProperty("mars_distance_mi")]
        public double DistanceFromMars { get; set; }

        [JsonProperty("speed_mph")]
        public double SpeedOfCar { get; set; }


    }
 class Program
   {
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        await ProcessRepositories();
    }
    private static async Task ProcessRepositories() 
    {
        
            try
            {
                Console.WriteLine("That car SpaceX launched into space.");

                var result = await client.GetAsync("https://api.spacexdata.com/v3/roadster");
                var resultRead = await result.Content.ReadAsStringAsync();

                var car = JsonConvert.DeserializeObject<TheCar>(resultRead);

                    Console.WriteLine("--");
                    Console.WriteLine("It was launched on:" + car.LaunchDate);
                    Console.WriteLine("Distance from earth(miles): " + car.DistanceFromEarth);
                    Console.WriteLine("Distance from mars(miles): " + car.DistanceFromMars); 
                    Console.WriteLine("Speed (miles per hour): " + car.SpeedOfCar);
                    Console.WriteLine("\n--");


                }
            catch (Exception)
            {
                Console.WriteLine("ERROR: API isn't working.");
            }
        
       }
    }

    
}