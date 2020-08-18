using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class GetAddressListQuery : ICqrsRequestWrapper<List<AddressListDTO>>
    {

    }

    public class GetAddressListQueryHandler : ICqrsRequestHandlerWrapper<GetAddressListQuery, List<AddressListDTO>>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public GetAddressListQueryHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CqrsResponse<List<AddressListDTO>>> Handle(GetAddressListQuery request, CancellationToken cancellationToken)
        {
            var list = _context.Addresses.ProjectTo<AddressListDTO>(_mapper.ConfigurationProvider).ToList();
            return Task.FromResult(CqrsResponse.QuerySuccess(list));
        }
    }

}
