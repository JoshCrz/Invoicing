using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
   public static class ServiceResponse
    {

        public static ServiceResponse<T> Ok<T>(T data, string message = "success")
        {
            return new ServiceResponse<T>(data, message, false);
        }

        public static ServiceResponse<T> Fail<T>(T data, string message = "error")
        {
            return new ServiceResponse<T>(data, message, true);
        }

    }


    public class ServiceResponse<T>
    {

        public ServiceResponse(T data, string message, bool failed)
        {
            Data = data;
            Message = message;
            Failed = failed;
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public bool Failed { get; set; }
    }

}
