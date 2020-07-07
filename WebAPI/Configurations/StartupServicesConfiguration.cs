using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Service;
using Service.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Configurations
{
    public static class StartupServicesConfiguration
    {

        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // register customer context and use default connection (appsettings.json)
            services.AddDbContext<InvoicingContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

        }

        public static void AddServiceInjections(this IServiceCollection services)
        {
            // regsiter business services
            services.AddScoped<CustomersService>();
        }

    }
}
