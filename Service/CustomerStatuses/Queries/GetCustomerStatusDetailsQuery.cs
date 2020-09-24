using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Repository;
using Service;
using Service.ViewModels;

namespace Service.Queries
{
    public class GetCustomerStatusDetailsQuery : ICqrsRequestWrapper<CustomerStatusDetailsDTO>
    {
        public GetCustomerStatusDetailsQuery(int customerStatusID)
        {
            CustomerStatusID = customerStatusID;
        }
        public int CustomerStatusID { get; set; }
    }

    public class GetCustomerStatusDetailsQueryHandler : ICqrsRequestHandlerWrapper<GetCustomerStatusDetailsQuery, CustomerStatusDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public GetCustomerStatusDetailsQueryHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CqrsResponse<CustomerStatusDetailsDTO>> Handle(GetCustomerStatusDetailsQuery request, CancellationToken cancellationToken)
        {
            var status = _context.CustomerStatuses.FirstOrDefault(x => x.CustomerStatusID == request.CustomerStatusID);
            if (status == null)
                throw ServiceExceptions.CqrsNotFountException();

            var dto = _mapper.Map<CustomerStatusDetailsDTO>(status);

            return Task.FromResult(CqrsResponse.QuerySuccess(dto));
        }
    }

}
