namespace WeatherWidget.Services.Models;

public class WeatherInfoResponse
{
    public Main Main { get; set; }
    public string Name { get; set; } = string.Empty;
    public Sys Sys { get; set; }
}

public class Main
{
    public double Temp { get; set; }
}

public class Sys
{
    public string Country { get; set; } = string.Empty;
}