using DiyorMarket.Domain.Interfaces.Repositories;
using DiyorMarket.Domain.Interfaces.Services;
using DiyorMarket.Infrastructure.Persistence;
using DiyorMarket.Infrastructure.Persistence.Repositories;
using DiyorMarket.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DiyorMarket.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICommonRepository, CommonRepository>();

            return services;
        }

        public static IServiceCollection ConfigureLogger(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.File("logs/error_.txt", Serilog.Events.LogEventLevel.Error, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            return services;
        }

        public static IServiceCollection ConfigureDatabaseContext(this IServiceCollection services)
        {
            services.AddDbContext<DiyorMarketDbContext>(options =>
                options.UseSqlServer("Data Source=DESKTOP-11M5EOQ;Initial Catalog=DiyorMarket;Integrated Security=True;TrustServerCertificate=True;"));

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
