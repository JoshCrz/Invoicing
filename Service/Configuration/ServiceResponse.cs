using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{

    public static class ServiceResponse
    {
        public static ServiceResponse<TIn, TResponse> Success<TIn, TResponse>(TIn command, CqrsResponse<TResponse> data)
        {
            return new ServiceResponse<TIn, TResponse>(command, data);
        }
    }

    public class ServiceResponse<TIn, TResponse> : IServiceResponse<TIn, TResponse>
    {
        public ServiceResponse(TIn command, CqrsResponse<TResponse> cqrsResponse)
        {
            Data = cqrsResponse.Response;
            Command = command;
        }

        public TIn Command { get; set; }
        public TResponse Data { get; set; }
    }

}
