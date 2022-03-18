using Microsoft.AspNetCore.Mvc;

namespace FaultyService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : Controller
    {
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeather")]
        public IActionResult GetWeather()
        {
            int value = new Random().Next(5);
            if (value == 0)
            {
                _logger.LogError("error");
                return StatusCode(500);
            }

            _logger.LogInformation("ok");
            return Ok("overcast");
        }
    }
}
