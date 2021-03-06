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
using Service;
using FluentValidation;
using Service.Commands;
using WebAPI.Exceptions;

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
                .AddNewtonsoftJson(config =>
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
            services.AddExceptionHandler();

            // mediator
            services.AddMediatR(typeof(CustomersService).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestModelValidator<,>));
            services.AddValidatorsFromAssembly(typeof(CustomersService).Assembly);

            // automapper
            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            // swagger
            services.AddSwaggerGen(c => {
                c.OrderActionsBy(x => x.GroupName);
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Invoicing System API",
                    Version = "v1",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "Peter"
                    }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors("AllowOrigin");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.ConfigureApiExceptionHandler();
            app.AddExceptionMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
                
            });

            
        }
    }

   

}
