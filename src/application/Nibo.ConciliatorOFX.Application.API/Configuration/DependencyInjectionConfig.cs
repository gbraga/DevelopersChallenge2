using Microsoft.Extensions.DependencyInjection;
using Nibo.ConciliatorOFX.Application.API.Services.Factories;

namespace Nibo.ConciliatorOFX.Application.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<OfxElementFactory>();

            return services;
        }
    }
}
