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
                .RetryAsync(retryCount, onRetry: (message, retryCount) =>
                {
                    string msg = $"Retry: {retryCount}";
                    Console.Out.WriteLineAsync(msg);
                });
        }
    }
}
