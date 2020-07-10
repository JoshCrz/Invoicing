using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using System.Linq;

namespace Service
{
    public class RequestModelValidator<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        private readonly IEnumerable<IValidator<TIn>> _validators;
        public RequestModelValidator(IEnumerable<IValidator<TIn>> validators)
        {
            _validators = validators;
        }
        public Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {
            var context = new ValidationContext<TIn>(request);

            var errors = _validators
                            .Select(v => v.Validate(context))
                            .SelectMany(r => r.Errors)
                            .Where(f => f != null)
                            .ToList();

            if(errors.Count > 0) {

                return null;
                throw new ValidationException(errors);
            }

            return next();
        }
    }
}
