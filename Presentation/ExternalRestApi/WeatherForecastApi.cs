using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Presentation;

namespace Presentation.ExternalRestApi
{
    public class WeatherForecastApi
    {
        private static readonly string baseUrl = "https://bclausingwb-api.azurewebsites.net/";
        private static readonly string getAll = "weatherforecast";
        private static HttpClient client;

        public WeatherForecastApi()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllForecasts()
        {
            IEnumerable<WeatherForecast> result = null;

            using (HttpResponseMessage response = await client.GetAsync(baseUrl + getAll))
            {
                response.EnsureSuccessStatusCode();
                result = await response.Content?.ReadAsAsync<IEnumerable<WeatherForecast>>();
            }

            return result ?? new List<WeatherForecast>();
        }
    }
}
