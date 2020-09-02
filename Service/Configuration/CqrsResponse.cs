using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public static class CqrsResponse
    {

        public static CqrsResponse<TQueryResponse> QuerySuccess<TQueryResponse>(TQueryResponse response)
        {
            return new CqrsResponse<TQueryResponse>(response);
        }

    }
    
    public class CqrsResponse<TResponse>
    {
        public CqrsResponse(TResponse response)
        {
            Response = response;
        }

        public TResponse Response { get; set; }

    }
}
