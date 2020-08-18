using FluentValidation;
using Service.Commands;

namespace Service.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty();
            RuleFor(x => x.NatureOfBusiness).NotEmpty();
        }
    }
}
