using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Exceptions
{
    public class ServiceExceptionModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

       
    }
}
