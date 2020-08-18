using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{

    public static class ServiceExceptions
    {
        public static ServiceException CqrsValidationException(List<ValidationFailure> errors, string message = "Validation Error")
        {
            return new ServiceException(errors, message);
        }

        public static ServiceException CqrsNotFountException(string message = "Entity not found")
        {
            return new ServiceException(message);
        }
    }

    public class ServiceException : Exception
    {
        public ServiceException(List<ValidationFailure> errors, string message)
        {
            ValidationErrors = errors;
            UserMessage = message;
        }
        public ServiceException(string message)
        {
            UserMessage = message;
        }
        public string UserMessage { get; set; }
        public IList<ValidationFailure> ValidationErrors { get; set; }

    }
}
