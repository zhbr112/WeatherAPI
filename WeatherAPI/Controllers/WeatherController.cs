using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController(ILogger<WeatherController> logger, IWeatherService weatherService, WeatherDescriptorService descriptorService) : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger = logger;
        private readonly IWeatherService _weatherService = weatherService;
        private readonly WeatherDescriptorService _descriptorService = descriptorService;

        [HttpGet]
        [Route("{city}")]
        public async Task<string?> GetStatusAsync(string city)
        {
            var weather = await _weatherService.GetWeatherAsync(city);

            if (weather is null) return "Сервер не ответил";

            var description = _descriptorService.Describe(weather);

            return description;
        }
    }
}
