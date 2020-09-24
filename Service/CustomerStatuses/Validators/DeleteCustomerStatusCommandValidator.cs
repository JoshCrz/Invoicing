using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Service.Commands;

namespace Service.CustomerStatuses.Validators
{
    public class DeleteCustomerStatusCommandValidator : AbstractValidator<DeleteCustomerStatusCommand>
    {
        public DeleteCustomerStatusCommandValidator()
        {

        }
    }
}