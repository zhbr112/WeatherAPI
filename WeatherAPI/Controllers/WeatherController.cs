using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {       
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{sity}")]
        public string Get1(string sity)
        {
            var res = (new GetRequest(sity)).response().Result; 
            return res.weather[0].main;
        }
    }
}
