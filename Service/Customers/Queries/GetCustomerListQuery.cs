using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Service.ViewModels;
using System.Threading.Tasks;
using System.Threading;
using Repository;
using System.Linq;

namespace Service.Queries
{
    public class GetCustomerListQuery : IRequest<List<CustomerListVM>>
    {


    }

    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerListVM>>
    {

        InvoicingContext _context;
        public Task<List<CustomerListVM>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var list  = _context.Customers.Select(entity =>
                new CustomerListVM()
                {
                    CompanyName = entity.CompanyName,
                    NatureOfBusiness = entity.NatureOfBusiness,
                    CompanyStatus = "hard-coded status",
                    CompanyType = "hard-coded type"
                }
            ).ToList();

            return  Task.FromResult(list);
        }
    }
}
