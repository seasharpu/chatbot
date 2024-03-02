using chatbotv1.Data;
using chatbotv1.Models;
using Microsoft.AspNetCore.Mvc;

namespace chatbotv1.Controllers
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
        private MyDBContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MyDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public String GetDefault() 
        {
            return _context.Database.ProviderName ?? "";
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
