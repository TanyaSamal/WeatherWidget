namespace WeatherWidget.Services.Exceptions;

public class EnvironmentVariableNotFoundException : Exception
{
    public EnvironmentVariableNotFoundException()
    {
    }

    public EnvironmentVariableNotFoundException(string message) : base(message)
    {
    }

    public EnvironmentVariableNotFoundException(string message, Exception innerException) : base(message,
        innerException)
    {
    }
}