using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        //public ServiceErrorResponse Error()
        //{
        //    var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        //    var exception = context?.Error; // Your exception
        //    var code = 500; // Internal Server Error by default

        //    if (exception is FluentValidation.ValidationException)
        //    {
        //        code = 404; // Not Found
        //    }

        //    Response.StatusCode = code; // You can use HttpStatusCode enum instead

        //    return ServiceResponse.InternalServerError("Internal Error", 500);// Your error model
        //}
    }
}