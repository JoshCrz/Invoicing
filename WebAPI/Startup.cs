using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAPI.Configurations;
using Newtonsoft.Json;
using MediatR;
using System.Reflection;
using Service.Queries;
using AutoMapper;
using EntityModels;
using Service.ViewModels;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddNewtonsoftJson(config=> 
                    config.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore // for nested entities ## move it so separate extension class ?
                    );

            // cors
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", o =>

                    o.SetIsOriginAllowed(s => true)
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });

            // extension: add database context
            services.AddDatabaseConfiguration(Configuration);
            
            // extension: inject services
            services.AddServiceInjections();

            // mediator
            services.AddMediatR(typeof(GetCustomerListQueryHandler).GetTypeInfo().Assembly);

            // automapper
            services.AddAutoMapper(typeof(AutoMapperConfiguration));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowOrigin");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });




            
        }
    }

   

}
