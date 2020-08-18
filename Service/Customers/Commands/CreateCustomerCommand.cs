using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Repository;
using Service.ViewModels;
using AutoMapper;
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
            var newcustomer = _mapper.Map<EntityModels.Customers>(request);

            // add address if passed
            if(request.CustomerAddress != null)
            {
                var address = new Addresses();
                _mapper.Map(request.CustomerAddress, address);

                newcustomer.CustomerAddresses.Add(new CustomersAddresses()
                {
                    Address = address,
                    Customer = newcustomer
                });
            }

            _context.Customers.Add(newcustomer);
            _context.SaveChanges();

            var dto = _mapper.Map<CustomerDetailsDTO>(newcustomer);

            return Task.FromResult(CqrsResponse.QuerySuccess(dto));
        }
    }
}
