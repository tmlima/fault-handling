using Polly;
using Polly.Retry;

namespace Consumer.Extensions
{
    public class RetryExtension
    {
        public static AsyncRetryPolicy<HttpResponseMessage> CreatePolicy(int retryCount)
        {
            return Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                //.WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
                .RetryAsync(retryCount, onRetry: (message, retryCount) =>
                {
                    string msg = $"Retry: {retryCount}";
                    Console.Out.WriteLineAsync(msg);
                });
        }
    }
}
