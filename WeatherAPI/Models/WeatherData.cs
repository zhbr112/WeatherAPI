using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.Models;

public class WeatherData
{
    // Краткое описание погоды
    [Required]
    public string? Description { get; set; }

    // Температура в Кельвинах
    [Required]
    public float? TemperatureK { get; set; }

    // Температура в Цельсиях
    [Required]
    public float? TemperatureC => TemperatureK - 273.15f;

    // Процент влажности
    [Required]
    public float? Humidity { get; set; }

    // Вероятность осадков
    [Required]
    public float? Precipitation { get; set; }
}
