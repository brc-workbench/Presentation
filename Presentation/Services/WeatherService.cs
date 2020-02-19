using Microsoft.Extensions.Logging;
using SwaggerSpecs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class WeatherService : IWeatherService
    {
        private static readonly string _baseUrl = "https://bclausingwb-api.azurewebsites.net/";
        private static readonly string _weatherForecastPath = "weatherforecast";
        private readonly HttpClient _httpClient;
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(HttpClient httpClient, ILogger<WeatherService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllForecasts()
        {
            _logger.LogInformation($"Begin WeatherService.GetAllForecasts @ {DateTime.Now} FROM front-end application TO microservice");
            
            using HttpResponseMessage response = await _httpClient.GetAsync(_baseUrl + _weatherForecastPath);
            response.EnsureSuccessStatusCode();
            IEnumerable<WeatherForecast> result = await response.Content?.ReadAsAsync<IEnumerable<WeatherForecast>>();
            
            _logger.LogInformation($"End WeatherService.GetAllForecasts @ {DateTime.Now} FROM front-end application TO microservice");

            return result ?? new List<WeatherForecast>();
        }
    }
}
