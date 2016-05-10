using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ForecastIO;

namespace Forecast.Models
{
    public class Location
    {
        public float windSpeed { get; set; }
        public float temperature { get; set; }

        public static Dictionary<string,float> GetLocations()
        {
            var request = new ForecastIORequest(EnvironmentVariables.apiKey, 45.520705f, -122.677397f, Unit.si);
            var response = request.Get();
            var current = response.currently;
            var loc = new Dictionary<string, float>();
            loc.Add("temp", response.currently.temperature);
            loc.Add("wind", response.currently.windSpeed);
            return loc;
        }

    }
}
