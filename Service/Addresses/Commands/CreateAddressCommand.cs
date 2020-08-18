using AutoMapper;
using Repository;
using Service;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Commands
{
    public class CreateAddressCommand : ICqrsRequestWrapper<AddressDetailsDTO>
    {

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

            return Task.FromResult(CqrsResponse.QuerySuccess(new AddressDetailsDTO()));
        }
    }

}
