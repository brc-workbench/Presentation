using SwaggerSpecs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetAllForecasts();
    }
}
