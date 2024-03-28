using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController(ILogger<WeatherController> logger, IWeatherService weatherService) : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger = logger;
        private readonly IWeatherService _weatherService = weatherService;

        [HttpGet]
        [Route("{city}")]
        public async Task<string?> GetStatusAsync(string city)
        {
            var res = await _weatherService.GetWeatherDescriptionAsync(city);
            return res;
        }
    }
}
