using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nibo.ConciliatorOFX.Application.API.Services;
using Nibo.ConciliatorOFX.Application.API.Services.Factories;

namespace Nibo.ConciliatorOFX.Application.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<OfxElementFactory>();
            services.AddScoped<IOfxParser, OfxParser>();

            services
                .Configure<DatabaseSettings>(configuration)
                .AddSingleton(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            //services.AddSingleton(dbSettings);

            return services;
        }
    }
}
