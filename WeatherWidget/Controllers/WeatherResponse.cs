namespace WeatherWidget.Controllers;

public record WeatherResponse
{
    public string Country { get; set; }
    
    public string City { get; set; }
    
    public double TemperatureInСelsius { get; set; }
}