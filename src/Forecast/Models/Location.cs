using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ForecastIO;
using Forecast.Models;

namespace Forecast.Models
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double WindSpeed { get; set; }
        public double Temperature { get; set; }

        public static List<Location> GetLocations()
        {
            var request = new ForecastIORequest(EnvironmentVariables.apiKey, 45.520705f, -122.677397f, Unit.si);
            var response = request.Get();

            JObject jsonResponse = (JObject)JsonConvert.DeserializeObject(response.currently.ToString());

            var locationlist = JsonConvert.DeserializeObject<List<Location>>(jsonResponse["locations"].ToString());
            return locationlist;
        }
    }
}
