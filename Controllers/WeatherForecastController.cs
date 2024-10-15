using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace React_ASPNETCore.Controllers
{
    // This attribute marks the class as an API controller
    // meaning it will handle HTTP API requests
    [ApiController]

    // The Route attribute defines the URL pattern for this controller
    // "[controller]" is a place holder that will be replaced with the name
    // of the controller class (without "Controller"), making the route "/WeatherForecast"
    [Route("[controller]")]

    // Inherits from ControllerBase, providing basic functionalities
    // for handling API requests, like returning responses
    public class WeatherForecastController : ControllerBase
    {

        // A static array of weather summaries used to randomly select
        // a weather condition for each forecast
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // The _logger variable is used for logging information, errors,
        // or other events during the application's execution, helpful for
        // debugging and monitoring
        private readonly ILogger<WeatherForecastController> _logger;

        // The constructor accepts an ILogger instance (injected via
        // dependency injection) and assigns it to the _logger field
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // This method is called when a GET request is made to "/WeatherForecast"
        // It returns a list of weather forecasts
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index =>
            {
                // Random temperature between -20 and 55°C.
                int temperatureC = Random.Shared.Next(-20, 55);

                // Summary is now based on the temperature.
                string summary = GetSummaryBasedOnTemperature(temperatureC);

                return new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = temperatureC,
                    Summary = summary
                };
            })
            .ToArray();
        }

        // Method to determine summary based on temps
        private string GetSummaryBasedOnTemperature(int temperatureC)
        {
            if (temperatureC <= 0)
                return "Freezing"; // 0°C or lower
            else if (temperatureC <= 10)
                return "Chilly";   // 1°C to 10°C
            else if (temperatureC <= 20)
                return "Cool";     // 11°C to 20°C
            else if (temperatureC <= 30)
                return "Mild";     // 21°C to 30°C
            else if (temperatureC <= 40)
                return "Warm";     // 31°C to 40°C
            else if (temperatureC <= 50)
                return "Hot";      // 41°C to 50°C
            else
                return "Scorching"; // Above 50°C
        }
    }
}
