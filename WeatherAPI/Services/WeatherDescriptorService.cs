using WeatherAPI.Models;

namespace WeatherAPI.Services;

public class WeatherDescriptorService(IConfiguration config)
{
    private readonly IConfiguration _config = config;
    public string Describe(WeatherData weather)
    {
        string? description = weather.TemperatureC switch
        {
            > 20 => _config.GetValue<string>("WeatherDescription:Warm"),
            < 0 => _config.GetValue<string>("WeatherDescription:Cold"),
            _ => _config.GetValue<string>("WeatherDescription:Normal")
        };

        if (description is null) throw new KeyNotFoundException("Нет запрашиваемого значения");

        return description;
    }
}
