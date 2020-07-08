using FluentValidation.Results;
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

        public static ServiceResponse<TIn, TOut> Ok<TIn, TOut>(TIn command, TOut response, string message = "success")
        {
            return new ServiceResponse<TIn, TOut>(command, response, message, false, null);
        }
        public static ServiceResponse<TIn, TOut> Fail<TIn, TOut>(TIn command, TOut response, IEnumerable<ValidationFailure> errors, string message = "success")
        {
            return new ServiceResponse<TIn, TOut>(command, response, message, true, errors);
        }

        public static ServiceResponse<TIn, TOut> NotFound<TIn, TOut>(TIn command, TOut response, string message = "Not Found")
        {
            return new ServiceResponse<TIn, TOut>(command, response, message, true, null);
        }

        public static ServiceResponse<TIn, TOut> MismatchIDs<TIn, TOut>(TIn command, TOut response, string message = "IDs Did Not Match")
        {
            return new ServiceResponse<TIn, TOut>(command, response, message, true, null);
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

    public class ServiceResponse<TIn, TOut>
    {

        public ServiceResponse(TIn dataIn, TOut dataOut, string message, bool failed, IEnumerable<ValidationFailure>  errors)
        {
            DataIn = dataIn;
            DataOut = dataOut;
            Message = message;
            Failed = failed;
            ErrorList = errors;
        }

        public TIn DataIn { get; set; }
        public TOut DataOut { get; set; }

        public string Message { get; set; }
        public bool Failed { get; set; }

        public IEnumerable<ValidationFailure> ErrorList { get; set; }
    }

}
