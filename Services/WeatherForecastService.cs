using React_ASPNETCore.Models;

// Business logic
namespace React_ASPNETCore.Services
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> GetWeatherForecasts(int days)
        {
            return Enumerable.Range(1, days).Select(index =>
            {
                int temperatureC = Random.Shared.Next(-20, 55);
                string summary = GetSummaryBasedOnTemperature(temperatureC);

                return new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = temperatureC,
                    Summary = summary
                };
            });
        }

        private string GetSummaryBasedOnTemperature(int temperatureC)
        {
            if (temperatureC <= 0)
                return "Freezing";
            else if (temperatureC <= 10)
                return "Chilly"; 
            else if (temperatureC <= 20)
                return "Cool";            
            else if (temperatureC <= 30)
                return "Mild";            
            else if (temperatureC <= 40)
                return "Warm";            
            else if (temperatureC <= 50)
                return "Hot";
            else
                return "Scorching";
        }
    }
}