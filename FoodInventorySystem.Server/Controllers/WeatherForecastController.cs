using Microsoft.AspNetCore.Mvc;

namespace FoodInventorySystem.Server.Controllers
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
        public IEnumerable<Inventory> Get()
        {
            int i = 0;
            return Enumerable.Range(1, 5).Select(index => new Inventory
            {
                Id = i++,
                ProductName = Summaries[Random.Shared.Next(Summaries.Length)],
                Quantity = 3,
                MeasurementUnit = "KG",
                ExpirationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(index))
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public Inventory Get(int id)
        {
            // Example: return a single Inventory item based on the id
            return new Inventory
            {
                Id = id,
                ProductName = Summaries[Random.Shared.Next(Summaries.Length)],
                Quantity = 3,
                MeasurementUnit = "KG",
                ExpirationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(id))
            };
        }

    }
}
