using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public static class CqrsResponse
    {

        public static CqrsResponse<TQueryRequest, TQueryResponse> QuerySuccess<TQueryRequest, TQueryResponse>(TQueryRequest query, TQueryResponse response)
        {
            return new CqrsResponse<TQueryRequest, TQueryResponse>(query, response);
        }


        public static CqrsResponse<TQueryRequest, TQueryResponse> QueryFail<TQueryRequest, TQueryResponse>(TQueryRequest query, TQueryResponse response, IEnumerable<FluentValidation.Results.ValidationFailure> validationErrors)
        {
            return new CqrsResponse<TQueryRequest, TQueryResponse>(query, response, validationErrors);
        }
    }


    public class CqrsResponse<TIn, TOut>
    {
        public CqrsResponse(TIn query, TOut response, IEnumerable<FluentValidation.Results.ValidationFailure> validationErrors = null)
        {
            DataIn = query;
            DataOut = response;
            ValidationErrors = validationErrors;
        }
        public TIn DataIn { get; set; }
        public TOut DataOut { get; set; }
        IEnumerable<FluentValidation.Results.ValidationFailure> ValidationErrors { get; set; }

    }
}
