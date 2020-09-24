using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Service.Commands;

namespace Service.CustomerStatuses.Validators
{
    public class UpdateCustomerStatusCommandValidator : AbstractValidator<UpdateCustomerStatusCommand>
    {
        public UpdateCustomerStatusCommandValidator()
        {

        }
    }
}
