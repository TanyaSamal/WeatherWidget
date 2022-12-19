namespace WeatherWidget.Services.Exceptions;

public class FetchWeatherInfoException : Exception
{
    public FetchWeatherInfoException()
    {
    }

    public FetchWeatherInfoException(string message) : base(message)
    {
    }

    public FetchWeatherInfoException(string message, Exception innerException) : base(message, innerException)
    {
    }
}