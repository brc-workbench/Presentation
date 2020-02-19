using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwaggerSpecs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Presentation.Services;

namespace Project.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherService weatherService, ILogger<WeatherForecastController> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            _logger.LogInformation($"Begin GET/weatherforecast @ {DateTime.Now} FROM front-end application TO microservice");
            IEnumerable<WeatherForecast> result;

            try
            {
                result = await _weatherService.GetAllForecasts();
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex);
            }

            _logger.LogInformation($"End GET/weatherforecast @ {DateTime.Now} FROM front-end application TO microservice");

            return Ok(result ?? new List<WeatherForecast>());
        }
    }
}
