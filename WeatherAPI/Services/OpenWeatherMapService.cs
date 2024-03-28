using WeatherAPI.Models;

namespace WeatherAPI.Services;

public class OpenWeatherMapService(ILogger<OpenWeatherMapService> logger, IConfiguration config, IHttpClientFactory httpClientFactory) : IWeatherService
{
    private readonly ILogger _logger = logger;
    private readonly IConfiguration _config = config;
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("owm");
    private readonly string apiKey = config.GetValue<string>("OpenWeatherMap:Token")!;


    private async Task<OpenWeatherMapResponse?> GetWeatherDataAsync(string city)
    {
        _logger.LogDebug("Getting weather data from OpenWeatherMap with key: {apiKey}", apiKey);       
        var res = await _httpClient.GetFromJsonAsync<OpenWeatherMapResponse>($"weather?q={city}&appid={apiKey}");           
        if (res is not null) _logger.LogDebug("Got response, id: {weatherId}", res?.id);
        else _logger.LogDebug("Got empty respose");
        return res;
    }

    public async Task<WeatherData?> GetWeatherAsync(string city)
    {
        var response = await GetWeatherDataAsync(city);

        var weather = new WeatherData()
        {
            Description = response?.weather?[0].main,
            TemperatureK = response?.main?.temp,
            Humidity = response?.main?.humidity,
            Precipitation = response?.rain?._1h
        };
        return weather;
    }

}
