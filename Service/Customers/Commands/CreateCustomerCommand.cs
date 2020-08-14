using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Repository;
using Service.ViewModels;
using AutoMapper;
using FluentValidation;
using EntityModels;

namespace Service.Commands
{
    public class CreateCustomerCommand : ICqrsRequestWrapper<CustomerDetailsDTO>
    {
        public string CompanyName { get; set; }
        public string NatureOfBusiness { get; set; }

        public int? CustomerStatusID { get; set; }
        public int? CustomerTypeID { get; set; }
        public string WebsiteUrl { get; set; }
        public string RegistrationNumber { get; set; }
        public string VatNumber { get; set; }

        public AddressDetailsDTO CustomerAddress { get; set; }
    }

    public class CreateCustomerCommandHandler : ICqrsRequestHandlerWrapper<CreateCustomerCommand, CustomerDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public CreateCustomerCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CqrsResponse<CustomerDetailsDTO>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EntityModels.Customers>(request);

            // add address 
            if(request.CustomerAddress != null)
            {
                var address = new Addresses();
                _mapper.Map(request.CustomerAddress, address);

                entity.CustomerAddresses.Add(new CustomersAddresses()
                {
                    Address = address,
                    Customer = entity
                });
            }

            _context.Customers.Add(entity);
            _context.SaveChanges();

            var dto = _mapper.Map<CustomerDetailsDTO>(entity);

            return Task.FromResult(CqrsResponse.QuerySuccess(dto));
        }
    }

    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty();
            RuleFor(x => x.NatureOfBusiness).NotEmpty();
        }
    }
}
