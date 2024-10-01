using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;
using Infrastructure.Security;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv8", Version = "v1" });
            });

            services.AddDbContext<WMSContext>(options =>
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                string connStr = string.Empty;

                if (env == "Development")
                {
                    connStr = config.GetConnectionString("DefaultConnection");
                }
                else
                {
                    // TODO - Configure Production Database
                }
                options.UseSqlite(connStr);
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:3000");
                });
            });

            // TODO - Add services here
            //services.AddScoped<IUserAccessor, UserAccessor>();

            return services;
        }
    }
}