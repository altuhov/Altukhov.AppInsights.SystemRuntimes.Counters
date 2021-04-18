using Microsoft.ApplicationInsights.Extensibility.EventCounterCollector;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Altukhov.AppInsights.SystemRuntimes.Counters
{
    public static class ApplicationInsightsExtensions
    {
        private static readonly List<string> SystemRuntimeCustomEvents = new List<string>()
        {
            "gc-heap-size",
            "gen-0-gc-count",
            "gen-1-gc-count",
            "gen-2-gc-count",
            "time-in-gc",
            "gen-0-size",
            "gen-1-size",
            "gen-2-size",
            "loh-size",
            "alloc-rate",
            "assembly-count",
            "threadpool-thread-count",
            "monitor-lock-contention-count",
            "threadpool-queue-length",
            "threadpool-completed-items-count"
        };
        public static IServiceCollection AddSystemRuntimeCustomEvents(this IServiceCollection services)
        {
            services.ConfigureTelemetryModule<EventCounterCollectionModule>(
            (module, o) =>
            {
                foreach (var @event in SystemRuntimeCustomEvents)
                {
                    module.Counters.Add(new EventCounterCollectionRequest("System.Runtime", @event));
                }

            }
        );
            return services;
        }
    }
}
