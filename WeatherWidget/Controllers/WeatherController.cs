using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeatherWidget.Services.Services;

namespace WeatherWidget.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly ILogger<WeatherController> _logger;
    private readonly IWeatherService _weatherService;
    private readonly IMapper _mapper;

    public WeatherController(
        ILogger<WeatherController> logger,
        IWeatherService weatherService, IMapper mapper)
    {
        _logger = logger;
        _weatherService = weatherService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<WeatherResponse>> GetWeather([FromQuery] string lat, [FromQuery] string lon)
    {
        var weather =  await _weatherService.GetWeatherAsync(lat, lon);

        return Ok(_mapper.Map<WeatherResponse>(weather));
    }
}