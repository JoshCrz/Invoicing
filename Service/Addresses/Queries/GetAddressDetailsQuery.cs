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

namespace Service.Queries
{
    public class GetAddressDetailsQuery : ICqrsRequestWrapper<AddressDetailsDTO>
    {
        public int AddressID { get; set; }
    }

    public class GetAddressDetailsQueryHandler : ICqrsRequestHandlerWrapper<GetAddressDetailsQuery, AddressDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public GetAddressDetailsQueryHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CqrsResponse<AddressDetailsDTO>> Handle(GetAddressDetailsQuery request, CancellationToken cancellationToken)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.AddressID == request.AddressID);

            if (address == null)
                throw ServiceExceptions.CqrsNotFountException("Address not found");


            var mapped = _mapper.Map<AddressDetailsDTO>(address);

            return Task.FromResult(CqrsResponse.QuerySuccess(mapped));
        }
    }

}
