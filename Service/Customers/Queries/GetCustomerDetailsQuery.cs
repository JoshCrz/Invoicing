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
    public class GetCustomerDetailsQuery : ICqrsRequestWrapper<CustomerDetailsDTO>
    {
        public GetCustomerDetailsQuery(int customerID)
        {
            CustomerID = customerID;
        }
       public int CustomerID { get; set; }


    }

    public class GetCustomerDetailsQueryHandler : ICqrsRequestHandlerWrapper<GetCustomerDetailsQuery, CustomerDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public GetCustomerDetailsQueryHandler(InvoicingContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public Task<CqrsResponse<CustomerDetailsDTO>> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            var item = _context.Customers
                                .Include(x=> x.CustomerStatus)
                                .Include(x=> x.CustomerType)
                                .Include(x=> x.CustomerAddresses).ThenInclude(xx=> xx.Address)
                                .FirstOrDefault(x => x.CustomerID == request.CustomerID);

            if (item == null)
                throw ServiceExceptions.CqrsNotFountException();

            var mapped = _mapper.Map<CustomerDetailsDTO>(item);

            return Task.FromResult(CqrsResponse.QuerySuccess(mapped));
        }
    }
}
