namespace Consumer.Clients
{
    public class FaultyServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public FaultyServiceClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetWeatherAsync(bool willBreak)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_configuration["UriFaultyService"]}Weather?returnError={willBreak}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
