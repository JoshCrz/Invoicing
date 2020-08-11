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
using FluentValidation;
using System.Security.Authentication;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebAPI.Exceptions
{
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private IExceptionResponseHandler exceptionHandler;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IExceptionResponseHandler exceptionHandler /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                this.exceptionHandler = exceptionHandler;
                await HandleExceptionAsync(context, ex);
            }
        }
               
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            
            var e = exception.InnerException;
            var responseModel = exceptionHandler.CreateResponse(e);

            context.Response.StatusCode = responseModel.StatusCode;
            context.Response.ContentType = responseModel.ContentType;

            // config json
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            return context.Response.WriteAsync(JsonConvert.SerializeObject(responseModel, serializerSettings));
        }

       
        //public static void ConfigureApiExceptionHandler(this IApplicationBuilder app)
        //{
        //    app.UseExceptionHandler(appError =>
        //    {
        //        appError.Run(async context =>
        //        {
        //            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

        //            if (contextFeature != null && contextFeature.Error != null)
        //            {
        //                var ex = contextFeature.Error.InnerException;

        //                // get response model
        //                var responseModel = GetResponseModel(ex);

        //                // set response 
        //                context.Response.StatusCode = responseModel.StatusCode;
        //                context.Response.ContentType = "application/json";

        //                // config json
        //                var serializerSettings = new JsonSerializerSettings();
        //                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        //                // return responseModel
        //                await context.Response.WriteAsync(JsonConvert.SerializeObject(responseModel, serializerSettings));
        //            }
        //        });
        //    });
        //}

        //private static ApiExceptionModel GetResponseModel(Exception e)
        //{
        //    var model = new ApiExceptionModel();

        //    var errors= new List<FluentValidation.Results.ValidationFailure>();
        //    var message= e.Message;
        //    var statusCode = (int)HttpStatusCode.InternalServerError; ;
        //    switch (e)
        //    {
        //        case ServiceException _:
        //            statusCode = 200;
        //            errors = ((ServiceException)e).ValidationErrors.ToList();
        //            message = e.Message;
        //            break;
        //        case DbUpdateException _:
        //            message = e.Message;
        //            break;
        //    }

        //    model = new ApiExceptionModel()
        //    {
        //        ValidationErrors = errors,
        //        Message = message,
        //        StatusCode = statusCode
        //    };

        //    return model;
        //}
    }

}
