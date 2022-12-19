using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace WeatherWidget.Middleware;

public class ExceptionMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var problem = JsonSerializer.Serialize(new
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Message = "An internal server error occurred."
            });

            await context.Response.WriteAsync(problem);
            context.Response.ContentType = MediaTypeNames.Application.Json;
        }
    }
}