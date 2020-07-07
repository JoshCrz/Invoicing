using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Service.ViewModels;
using System.Threading.Tasks;
using System.Threading;
using Repository;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Service.Queries
{
    public class GetCustomerListQuery : IServiceRequestWrapper<List<CustomerListDTO>>
    {


    }

    public class GetCustomerListQueryHandler : IServiceRequestHandlerWrapper<GetCustomerListQuery, List<CustomerListDTO>>
    {

        InvoicingContext _context;
        IMapper _mapper;
        public GetCustomerListQueryHandler(InvoicingContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public Task<ServiceResponse<List<CustomerListDTO>>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var list  = _context.Customers.ProjectTo<CustomerListDTO>(_mapper.ConfigurationProvider).ToList();

            return Task.FromResult(ServiceResponse.Ok(list));
        }
    }
}
