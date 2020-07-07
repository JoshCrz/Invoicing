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


namespace Service.Commands
{
    public class DeleteCustomerCommand : IServiceRequestWrapper<CustomerDetailsDTO>
    {
        public int CustomerID { get; set; }
    }

    public class DeleteCustomerCommandHandler : IServiceRequestHandlerWrapper<DeleteCustomerCommand, CustomerDetailsDTO>
    {

        InvoicingContext _context;
        IMapper _mapper;
        public DeleteCustomerCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ServiceResponse<CustomerDetailsDTO>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Customers
                                    .FirstOrDefault(x => x.CustomerID == request.CustomerID);
          
            _context.Customers.Remove(entity);
            _context.SaveChanges();

            var mapped = _mapper.Map<CustomerDetailsDTO>(entity);

            return Task.FromResult(ServiceResponse.Ok(mapped));

        }
    }
}
