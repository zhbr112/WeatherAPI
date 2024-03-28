using Microsoft.Extensions.DependencyInjection;
using WeatherAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("Config/WeatherDescription.json");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("owm", (c) =>
{
    c.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
});

builder.Services.AddScoped<IWeatherService, OpenWeatherMapService>();
builder.Services.AddSingleton<WeatherDescriptorService>();

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
