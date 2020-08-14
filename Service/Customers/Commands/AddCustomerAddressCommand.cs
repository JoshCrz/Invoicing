using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Commands
{
    public class AddCustomerAddressCommand : ICqrsRequestWrapper<AddressDetailsDTO>
    {
       
       public int CustomerID { get; set; }
       public AddressDetailsDTO CustomerAddress { get; set; }

    }

    public class AddCustomerAddressCommandHandler : ICqrsRequestHandlerWrapper<AddCustomerAddressCommand, AddressDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public AddCustomerAddressCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<CqrsResponse<AddressDetailsDTO>> Handle(AddCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            // find customer
            var customer = _context.Customers
                                .FirstOrDefault(x => x.CustomerID == request.CustomerID);

            // find address or new() if null
            var existing = _context.Addresses
                                .FirstOrDefault(x => x.AddressID == request.CustomerAddress.AddressID) ?? new EntityModels.Addresses();


            // PS: not sure how if address exists and we are only updating it
            // the below mapping is enough for ef update the address. 
            // map address
            _mapper.Map(request.CustomerAddress, existing);

            // add new address to the customer
            if (existing.AddressID == 0)
            {
                customer.CustomerAddresses.Add(new EntityModels.CustomersAddresses()
                {
                    Address = existing,
                    Customer = customer
                });
            }

            // save changes to db
            _context.SaveChanges();

            // new address as DTO
            var dto = _mapper.Map<AddressDetailsDTO>(existing);

            return Task.FromResult(CqrsResponse.QuerySuccess(dto));
        }
    }
}
