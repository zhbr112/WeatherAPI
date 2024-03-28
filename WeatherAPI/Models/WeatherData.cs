using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.Models;

public class WeatherData
{
    // Краткое описание погоды
    public required string? Description { get; set; }

    // Температура в Кельвинах
    public required float? TemperatureK { get; set; }

    // Температура в Цельсиях
    public float? TemperatureC => TemperatureK - 273.15f;

    // Процент влажности
    public required float? Humidity { get; set; }

    // Вероятность осадков
    public required float? Precipitation { get; set; }
}
