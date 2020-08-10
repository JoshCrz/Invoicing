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


        public static CqrsResponse<TQueryResponse> QueryFail<TQueryResponse>(List<ValidationFailure> validationErrors)
        {
            return new CqrsResponse<TQueryResponse>(validationErrors);
        }

        public static CqrsResponse<TQueryResponse> NotFound<TQueryResponse>(string message = "Not Found")
        {
            return new CqrsResponse<TQueryResponse>(message);
        }
    }


    public class CqrsResponse<TResponse>
    {
        public CqrsResponse(TResponse response)
        {
            Response = response;
        }

        public CqrsResponse(List<ValidationFailure> validationErrors)
        {
            Response = default;
            ValidationErrors = validationErrors;
        }

        public CqrsResponse(string message)
        {
            ValidationErrors = new List<ValidationFailure>();
            ValidationErrors.Add(new ValidationFailure("", message));
        }

        public TResponse Response { get; set; }
        public IList<ValidationFailure> ValidationErrors { get; set; }

    }
}
