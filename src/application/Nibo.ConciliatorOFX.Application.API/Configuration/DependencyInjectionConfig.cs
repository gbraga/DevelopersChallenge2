using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nibo.ConciliatorOFX.Application.API.Services;
using Nibo.ConciliatorOFX.Application.API.Services.Factories;
using Nibo.ConciliatorOFX.Data;
using Nibo.ConciliatorOFX.Data.Repositories;

namespace Nibo.ConciliatorOFX.Application.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<OfxElementFactory>();
            services.AddScoped<IOfxParser, OfxParser>();
            services.AddScoped<IOfxConciliate, OfxConciliate>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBankStatementRepository, BankStatementRepository>();

            services.AddAutoMapper(typeof(Startup).Assembly);
            
            services.AddDbContext<ConciliatorOFXContext>(options =>
                options.UseLazyLoadingProxies()
                       .UseSqlServer(configuration.GetConnectionString("ApplicationDbContext")));

            return services;
        }
    }
}
