using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Repository;
using Service;
using Service.ViewModels;

namespace Service.Commands
{
    public class CreateCustomerStatusCommand : ICqrsRequestWrapper<CustomerStatusDetailsDTO>
    {
        public int? CustomerID { get; set; }
        public string CustomerStatus { get; set; }
    }

    public class CreateCustomerStatusCommandHandler : ICqrsRequestHandlerWrapper<CreateCustomerStatusCommand, CustomerStatusDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public CreateCustomerStatusCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CqrsResponse<CustomerStatusDetailsDTO>> Handle(CreateCustomerStatusCommand request, CancellationToken cancellationToken)
        {
            // find customer
            var customer = _context.Customers
                                .FirstOrDefault(x => x.CustomerID == request.CustomerID);

            var newstatus = _mapper.Map<EntityModels.CustomerStatuses>(request);

            //add new status
            _context.CustomerStatuses.Add(newstatus);

            // allocate to customer
            if (customer != null)
                customer.CustomerStatus = newstatus;

            // save
            _context.SaveChanges();

            // return
            var dto = _mapper.Map<CustomerStatusDetailsDTO>(newstatus);

            return Task.FromResult(CqrsResponse.QuerySuccess(dto));
        }
    }

}
