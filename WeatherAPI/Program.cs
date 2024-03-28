using Microsoft.Extensions.Logging;
using WeatherAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("owm", (c) =>
{
    c.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
});
//builder.Services.AddScoped(http => new HttpClient
//{
//    BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/")
//});

builder.Services.AddTransient<IWeatherService, OpenWeatherMapService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
