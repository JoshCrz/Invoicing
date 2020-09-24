using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Service.Commands;

namespace Service.Validators
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator()
        {
            RuleFor(x => x.AddressLine1).NotEmpty();
            RuleFor(x => x.AddressLine2).NotEmpty();
            RuleFor(x => x.PostCode).NotEmpty();
            RuleFor(x => x.Town).NotEmpty();
        }

    }
}
