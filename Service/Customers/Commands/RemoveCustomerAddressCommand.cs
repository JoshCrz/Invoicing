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

    public class RemoveCustomerAddressCommand : ICqrsRequestWrapper<AddressDetailsDTO>
    {

        public int CustomerID { get; set; }
        public int AddressID { get; set; }

    }

    public class RemoveCustomerAddressCommandHandler : ICqrsRequestHandlerWrapper<RemoveCustomerAddressCommand, AddressDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public RemoveCustomerAddressCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<CqrsResponse<AddressDetailsDTO>> Handle(RemoveCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            // find customer
            var customer = _context.Customers
                                .Include(x => x.CustomerAddresses).ThenInclude(x=> x.Address)
                                .FirstOrDefault(x => x.CustomerID == request.CustomerID);

            var address = customer.CustomerAddresses.FirstOrDefault(x => x.AddressID == request.AddressID)?.Address;

            var addressLink = customer.CustomerAddresses.FirstOrDefault(x => x.AddressID == request.AddressID);
            if (addressLink != null)
            {
                _context.CustomerAddresses.Remove(addressLink);
            }

            // save changes to db
            _context.SaveChanges();

            // new address as DTO
            var dto = _mapper.Map<AddressDetailsDTO>(address);

            return Task.FromResult(CqrsResponse.QuerySuccess(dto));
        }
    }


}
