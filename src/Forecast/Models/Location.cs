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

        public static List<Dictionary<string, string>> GetLocations()
        {
            var request = new ForecastIORequest(EnvironmentVariables.apiKey, 45.520705f, -122.677397f, Unit.us);
            var response = request.Get();
            dynamic daily = response.daily.data;
            //var loc = new Dictionary<string, string>();
            var list = new List<Dictionary<string, string>>(); 
            for (int i = 0; i < 7; i++)
            {
                var loc = new Dictionary<string, string>();
                loc.Add("date", DateTime.Now.AddDays(i).ToString("dddd, MMMM dd, yyyy")); 
                loc.Add("maxTemp", response.daily.data[i].temperatureMax.ToString());
                loc.Add("minTemp", response.daily.data[i].temperatureMin.ToString());
                loc.Add("summary", response.daily.data[i].summary);
                list.Add(loc); 
            }


            return list; 
        }

    }
}
