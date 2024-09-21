using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WMS.Shared
{
    public static class WMSContextExtensions
    {
        public static IServiceCollection AddWMSContext(
            this IServiceCollection services,
            string relativePath = "..",
            string databaseFileName = "WMS.db"
        )
        {
            string databasePath = Path.Combine(relativePath, databaseFileName);

            services.AddDbContext<WmsContext>(options =>
            {
                options.UseSqlite($"Data Source={databasePath}");

                options.LogTo(WriteLine,
                new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });


            },
            contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);

            return services;
        }
    }
}