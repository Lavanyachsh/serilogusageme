using Microsoft.AspNetCore.Mvc;
using Serilog;
namespace serilogusageme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            WeatherForecast[] data = null;
            try
            {
                var username = "lavanya";
                Log.Information("weatherforecast controller.get method excution started"+username);
            data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
                throw new Exception();

                Log.Information("weatherforecast controller.get method excution ended");
            }
            catch (Exception ex)
            {
                Log.Error("custom failure: {@RequestName},{@Error},{@DateTimeUtc}",
                    "GetWeatherforecast method ", ex, DateTime.Today);

            }
            return data;
        }
    }
}
