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
    public class DeleteCustomerStatusCommand : ICqrsRequestWrapper<CustomerStatusDetailsDTO>
    {
        public int CustomerStatusID { get; set; }
    }

    public class DeleteCustomerStatusCommandHandler : ICqrsRequestHandlerWrapper<DeleteCustomerStatusCommand, CustomerStatusDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public DeleteCustomerStatusCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CqrsResponse<CustomerStatusDetailsDTO>> Handle(DeleteCustomerStatusCommand request, CancellationToken cancellationToken)
        {

            var status = _context.CustomerStatuses.FirstOrDefault(x => x.CustomerStatusID == request.CustomerStatusID);
            if (status == null)
                throw ServiceExceptions.CqrsNotFountException();

            _context.CustomerStatuses.Remove(status);
            _context.SaveChanges();

            var dto = _mapper.Map<CustomerStatusDetailsDTO>(status);

            return Task.FromResult(CqrsResponse.QuerySuccess(dto));
        }
    }

}
