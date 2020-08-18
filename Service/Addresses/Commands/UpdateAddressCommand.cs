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
    public class UpdateAddressCommand : ICqrsRequestWrapper<AddressDetailsDTO>
    {

    }

    public class UpdateAddressCommandHandler : ICqrsRequestHandlerWrapper<UpdateAddressCommand, AddressDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public UpdateAddressCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CqrsResponse<AddressDetailsDTO>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {

            return Task.FromResult(CqrsResponse.QuerySuccess(new AddressDetailsDTO()));
        }
    }

}
