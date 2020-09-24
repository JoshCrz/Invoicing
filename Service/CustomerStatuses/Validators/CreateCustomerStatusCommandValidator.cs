using FluentValidation;
using Service.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Validators
{
    public class CreateCustomerStatusCommandValidator : AbstractValidator<CreateCustomerStatusCommand>
    {
        public CreateCustomerStatusCommandValidator()
        {

        }
    }
}
