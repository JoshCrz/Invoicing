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
using Microsoft.EntityFrameworkCore;

namespace Service.Queries
{
    public class GetCustomerDetailsQuery : IServiceRequestWrapper<CustomerDetailsDTO>
    {
       public int CustomerID { get; set; }


    }

    public class GetCustomerDetailsQueryHandler : IServiceRequestHandlerWrapper<GetCustomerDetailsQuery, CustomerDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public GetCustomerDetailsQueryHandler(InvoicingContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public Task<ServiceResponse<CustomerDetailsDTO>> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            var item = _context.Customers
                                .Include(x=> x.CustomerStatus)
                                .Include(x=> x.CustomerType)
                                .FirstOrDefault(x => x.CustomerID == request.CustomerID);

            var mapped = _mapper.Map<CustomerDetailsDTO>(item);

            return Task.FromResult(ServiceResponse.Ok(mapped));
        }
    }
}
