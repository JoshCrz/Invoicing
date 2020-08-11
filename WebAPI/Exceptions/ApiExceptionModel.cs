using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAPI.Exceptions
{
    public class ApiExceptionModel
    {

        public ApiExceptionModel(ServiceException ex)
        {
            StatusCode = 400;
            ValidationErrors = ex.ValidationErrors?.ToList();
            Message = ex.UserMessage;
            InnerMessage = ex.Message;
            Source = ex.Source;
            TargetSite = ex.TargetSite.ToString();
        }
        public ApiExceptionModel(DbUpdateException ex)
        {
            StatusCode = 400;
            Message = ex.Message;
            if(ex.InnerException != null)
            {
                InnerMessage = ex.InnerException.Message;
            }
            Source = ex.Source;
            TargetSite = ex.TargetSite.ToString();

        }
        public ApiExceptionModel(Exception ex)
        {
            StatusCode = 500;
            Message = ex.Message;
            Source = ex.Source;
            TargetSite = ex.TargetSite.ToString();

        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string InnerMessage { get; set; }
        public string ContentType { get; set; } = "application/json";
        public string TargetSite { get; set; }
        public string Source { get; set; }

        public List<ValidationFailure> ValidationErrors { get; set; }

       
    }
}
