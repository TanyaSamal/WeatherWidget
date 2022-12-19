namespace WeatherWidget.Services.Exceptions;

public class FetchGeoInfoException : Exception
{
    public FetchGeoInfoException()
    {
    }

    public FetchGeoInfoException(string message) : base(message)
    {
    }

    public FetchGeoInfoException(string message, Exception innerException) : base(message, innerException)
    {
    }
}