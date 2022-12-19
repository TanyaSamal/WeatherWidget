using WeatherWidget.Services.Models;

namespace WeatherWidget.Services.Services;

public interface IWeatherService
{
    Task<Weather> GetWeatherAsync(string latitude, string longitude);
}