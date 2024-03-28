using WeatherAPI.Models;

namespace WeatherAPI.Services;

public interface IWeatherService
{
    public Task<WeatherData?> GetWeatherAsync(string city);
}
