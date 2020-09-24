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

namespace Service.Commands
{
    public class UpdateCustomerStatusCommand : ICqrsRequestWrapper<CustomerStatusDetailsDTO>
    {
        public int CustomerStatusID { get; set; }
        public string CustomerStatus { get; set; }
    }

    public class UpdateCustomerStatusCommandHandler : ICqrsRequestHandlerWrapper<UpdateCustomerStatusCommand, CustomerStatusDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public UpdateCustomerStatusCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CqrsResponse<CustomerStatusDetailsDTO>> Handle(UpdateCustomerStatusCommand request, CancellationToken cancellationToken)
        {

            var status = _context.CustomerStatuses.FirstOrDefault(x => x.CustomerStatusID == request.CustomerStatusID);
            if (status == null)
                throw ServiceExceptions.CqrsNotFountException();

            status.CustomerStatus = request.CustomerStatus;
            _context.SaveChanges();

            var dto = _mapper.Map<CustomerStatusDetailsDTO>(status);

            return Task.FromResult(CqrsResponse.QuerySuccess(dto));
        }
    }

}
