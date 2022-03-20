using Consumer.Clients;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumerController : Controller
    {
        private readonly FaultyServiceClient _client;

        public ConsumerController(FaultyServiceClient client)
        {
            _client = client;
        }

        [HttpGet(Name = "GetWeather")]
        public async Task<IActionResult> GetWeather(bool willBreak)
        {
            string weather = await _client.GetWeatherAsync(willBreak);
            return Ok(weather);
        }
    }
}
