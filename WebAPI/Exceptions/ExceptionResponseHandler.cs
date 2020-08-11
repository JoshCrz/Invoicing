using Microsoft.EntityFrameworkCore;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Exceptions
{
    public class ExceptionResponseHandler : IExceptionResponseHandler
    {
       
        public ApiExceptionModel CreateResponse(Exception ex)
        {
            ApiExceptionModel model;
            switch (ex)
            {
                case ServiceException _:
                    model = new ApiExceptionModel((ServiceException)ex);
                    break;
                case DbUpdateException _:
                    model = new ApiExceptionModel((DbUpdateException)ex);
                    break;
                default:
                    model = new ApiExceptionModel(ex);
                    break;
            }

            return model;
        }
    }
}
