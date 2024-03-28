namespace WeatherAPI.Models;

public class WeatherData
{
    // Краткое описание погоды
    public string? Description { get; set; }

    // Температура в Цельсиях
    public float? TemperatureC { get; set; }

    // Процент влажности
    public float? Humidity { get; set; }

    // Вероятность осадков
    public float? Precipitation { get; set; }
}
