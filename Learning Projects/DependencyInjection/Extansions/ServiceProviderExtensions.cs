using DependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Extansions
{
    public static class ServiceProviderExtensions
    {
        public static void AddTimeService(this IServiceCollection services)
        {
            services.AddTransient<TimeService>();
        }

    }
}
