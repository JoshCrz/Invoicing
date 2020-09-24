using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Repository;
using Service;
using Service.ViewModels;

namespace Service.Queries
{
    public class GetCustomerStatusListQuery : ICqrsRequestWrapper<List<CustomerStatusListDTO>>
    {

    }

    public class GetCustomerStatusListQueryHandler : ICqrsRequestHandlerWrapper<GetCustomerStatusListQuery, List<CustomerStatusListDTO>>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public GetCustomerStatusListQueryHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CqrsResponse<List<CustomerStatusListDTO>>> Handle(GetCustomerStatusListQuery request, CancellationToken cancellationToken)
        {

            var list = _context.CustomerStatuses
                        .ProjectTo<CustomerStatusListDTO>(_mapper.ConfigurationProvider)
                        .ToList();


            return Task.FromResult(CqrsResponse.QuerySuccess(list));
        }
    }

}
