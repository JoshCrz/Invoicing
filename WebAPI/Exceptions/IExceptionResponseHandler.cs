using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Exceptions
{
    public interface IExceptionResponseHandler
    {
        ApiExceptionModel CreateResponse(Exception ex);

    }
}
