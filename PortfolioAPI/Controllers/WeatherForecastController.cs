using Microsoft.AspNetCore.Mvc;

namespace PortfolioAPI.Controllers
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

        // Sample Feature //
        [HttpGet(Name = "GetWeatherForecast")]
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
        
        [HttpGet(Name = "GetRandomNumber")]
        public int GetRandomNumber()
        {
            int randomNumber2 = random.Next(100);
            return randomNumber2;
        }

        [HttpGet(Name = "GetBiggestNumber")]
        public int GetRandomNumber()
        {
            int biggestNumber = int.MaxValue;
            return biggestNumber;
        }

        [HttpGet(Name = "GetBiggestPrimeNumber")]
        public int GetBiggestPrimeNumber()
        {
            int biggestPrimeNumber = 0;
            for (int i = 2; i < int.MaxValue; i++)
            {
                if (IsPrime(i))
                {
                    biggestPrimeNumber = i;
                }
            }
            return biggestPrimeNumber;
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

    }
}
