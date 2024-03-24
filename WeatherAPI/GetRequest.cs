using System.Net;
using System.Text.Json;
using WeatherAPI.Models;

namespace WeatherAPI
{
    public class GetRequest(string sity)
    {
        public async Task<OpenWeatherApi> response()
        {
            var ApiKey = "085c7bbda8b1803f3cef66fee41022a3";
            using var client = new HttpClient();
            var weather = await client.GetStringAsync(
                $"https://api.openweathermap.org/data/2.5/weather?q={sity}&appid={ApiKey}"
                );
            var modelWeather = JsonSerializer.Deserialize<OpenWeatherApi>(weather);
            return modelWeather;
        }
        
    }
}
