using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Service;
using Newtonsoft.Json.Serialization;

namespace WebAPI.Exceptions
{
    public static class ApiExceptionHandler
    {
        public static void ConfigureApiExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var response = ServiceResponse.InternalServerError("Internal Error", 500);


                        var serializerSettings = new JsonSerializerSettings();
                        serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(response, serializerSettings));
                    }
                });
            });
        }
    }
}
