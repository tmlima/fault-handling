using Polly;
using Polly.CircuitBreaker;

namespace Consumer.Extensions
{
    public class CircuitBreakerExtension
    {
        public static AsyncCircuitBreakerPolicy<HttpResponseMessage> CreatePolicy(
            int exceptionsAllowedBeforeBreaking,
            TimeSpan durationOfBreak)
        {
            return Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(
                exceptionsAllowedBeforeBreaking, 
                durationOfBreak,
                onBreak: (_, _) =>
                {
                    PrintCircuitState(CircuitState.Open);
                },
                onReset: () =>
                {
                    PrintCircuitState(CircuitState.Close);
                },
                onHalfOpen: () =>
                {
                    PrintCircuitState(CircuitState.HalfOpen);
                });
        }

        private static void PrintCircuitState(CircuitState circuitState)
        {
            Console.WriteLine(circuitState);
        }
    }

    enum CircuitState
    {
        Close,
        Open,
        HalfOpen
    }
}
