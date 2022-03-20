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

        [HttpGet("GetWeather")]
        public async Task<IActionResult> GetWeather()
        {
            string weather = await _client.GetWeatherRandomAsync();
            return Ok(weather);
        }

        [HttpGet("ForceResponse")]
        public async Task<IActionResult> ForceResponse(bool willBreak)
        {
            string weather = await _client.GetWeatherAsync(willBreak);
            return Ok(weather);
        }
    }
}
