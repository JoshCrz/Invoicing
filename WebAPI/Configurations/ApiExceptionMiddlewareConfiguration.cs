using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Exceptions;

namespace WebAPI.Configurations
{
    public static class ApiExceptionMiddlewareConfiguration
    {
        public static void AddExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiExceptionMiddleware>();
        }

        public static void AddExceptionHandler(this IServiceCollection services)
        {
            services.AddScoped<IExceptionResponseHandler, ExceptionResponseHandler>();
        }
    }
}
