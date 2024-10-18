using Microsoft.AspNetCore.Mvc;
using React_ASPNETCore.Data;
using React_ASPNETCore.Models;
using React_ASPNETCore.Services;

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
        // Service for generating weather forefcasts
        private readonly WeatherForecastService _weatherService;

        // The _logger variable is used for logging information, errors,
        // or other events during the application's execution, helpful for
        // debugging and monitoring
        private readonly ILogger<WeatherForecastController> _logger;

        // The constructor accepts an ILogger instance (injected via
        // dependency injection) and assigns it to the _logger field
        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        // This method is called when a GET request is made to "/WeatherForecast"
        // It returns a list of weather forecasts
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("Fetching weather forecast data...");
            return _weatherService.GetWeatherForecasts(5);
        }
    }
}
