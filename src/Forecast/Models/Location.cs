using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ForecastIO;
using ForecastIO.Extensions;
using RestSharp;
using Microsoft.Data.Entity.Storage;

namespace Forecast.Models
{
    public class Location
    {
        public float Latitude;
        public float Longitude;

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

        //public void Send()
        //{
        //    var request = new ForecastIORequest(EnvironmentVariables.apiKey, Latitude, Longitude, Unit.si);

        //    Latitude.ToString();
        //    Longitude.ToString();
        //    request.AddParameter("Latitude", Latitude);
        //    request.("Longitude", Longitude);
        //}

    }
}
