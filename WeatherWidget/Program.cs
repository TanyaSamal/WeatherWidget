using System.Reflection;
using WeatherWidget.Middleware;
using WeatherWidget.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("WeatherApi", config =>
{
    config.BaseAddress = new Uri(builder.Configuration.GetValue<string>("WeatherApiBaseUri"));
});

builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


DotNetEnv.Env.Load();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();