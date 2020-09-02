using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using Repository;
using Service;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Commands
{
    public class DeleteAddressCommand : ICqrsRequestWrapper<AddressDetailsDTO>
    {
        public int AddressID { get; set; }
    }

    public class DeleteAddressCommandHandler : ICqrsRequestHandlerWrapper<DeleteAddressCommand, AddressDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public DeleteAddressCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CqrsResponse<AddressDetailsDTO>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.AddressID == request.AddressID);
            if (address == null)
                throw ServiceExceptions.CqrsNotFountException();

            _context.Addresses.Remove(address);
            _context.SaveChanges();

            var addressDto = _mapper.Map<AddressDetailsDTO>(address);

            return Task.FromResult(CqrsResponse.QuerySuccess(addressDto));
        }
    }

}
