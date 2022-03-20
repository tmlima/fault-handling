using Polly;
using Polly.CircuitBreaker;
using System.Net;

namespace Consumer.Extensions
{
    public class FallbackExtension
    {
        public static IAsyncPolicy<HttpResponseMessage> CreatePolicy()
        {
            return Policy<HttpResponseMessage>
                .Handle<BrokenCircuitException>()
                .FallbackAsync(FallbackAction, OnFallbackAsync);
        }

        private static Task OnFallbackAsync(DelegateResult<HttpResponseMessage> response, Context context)
        {
            Console.WriteLine("Will call the fallback action");
            return Task.CompletedTask;
        }
        private static Task<HttpResponseMessage> FallbackAction(DelegateResult<HttpResponseMessage> responseToFailedRequest, Context context, CancellationToken cancellationToken)
        {
            Console.WriteLine("Fallback action is executing");

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Fallback")
            };
            return Task.FromResult(httpResponseMessage);
        }
    }
}
