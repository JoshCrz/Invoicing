using AutoMapper;
using Repository;
using Service;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Commands
{
    public class CreateAddressCommand : ICqrsRequestWrapper<AddressDetailsDTO>
    {
        public int? CustomerID { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        public string PostCode { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }

    }

    public class CreateAddressCommandHandler : ICqrsRequestHandlerWrapper<CreateAddressCommand, AddressDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public CreateAddressCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CqrsResponse<AddressDetailsDTO>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {

            // find customer
            var customer = _context.Customers
                                .FirstOrDefault(x => x.CustomerID == request.CustomerID);

            var newaddress = _mapper.Map<EntityModels.Addresses>(request);

            customer.CustomerAddresses.Add(new EntityModels.CustomersAddresses()
            {
                Customer = customer,
                Address = newaddress
            });
            _context.SaveChanges();

            var addressDto = _mapper.Map<AddressDetailsDTO>(newaddress);

            return Task.FromResult(CqrsResponse.QuerySuccess(addressDto));
        }
    }

}
