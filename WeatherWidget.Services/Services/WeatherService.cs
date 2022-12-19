using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherWidget.Services.Exceptions;
using WeatherWidget.Services.Models;

namespace WeatherWidget.Services.Services;

public class WeatherService : IWeatherService
{
    private readonly ILogger<WeatherService> _logger;
    private const string WeatherInfoUri = "data/2.5/weather?lat={0}&lon={1}&appid={2}";
    private readonly HttpClient _httpClient;

    public WeatherService(ILogger<WeatherService> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient("WeatherApi");
    }

    public async Task<Weather> GetWeatherAsync(string latitude, string longitude)
    {
        _logger.LogInformation("Getting weather information");

        var key = Environment.GetEnvironmentVariable("WeatherApiKey");

        if (string.IsNullOrEmpty(key))
        {
            throw new EnvironmentVariableNotFoundException("Api key not found");
        }

        var weather = new Weather
        {
            WeatherInfoResponse = await FetchWeatherInfoAsync(latitude, longitude, key)
        };

        return weather;
    }

    private async Task<WeatherInfoResponse> FetchWeatherInfoAsync(
        string latitude,
        string longitude,
        string key)
    {
        _logger.LogInformation("Fetching weather information");
            
        var response = await _httpClient
            .GetAsync(string.Format(WeatherInfoUri, latitude, longitude, key));

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new FetchWeatherInfoException("Couldn't get weather information, see inner exception", e);
        }

        var content = JsonConvert.DeserializeObject<WeatherInfoResponse>(await response.Content.ReadAsStringAsync());

        return content;
    }
}