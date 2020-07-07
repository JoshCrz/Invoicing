using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Repository;
using Service.ViewModels;
using AutoMapper;

namespace Service.Commands
{
    public class CreateCustomerCommand : IServiceRequestWrapper<CustomerDetailsDTO>
    {
        public string CompanyName { get; set; }
        public string NatureOfBusiness { get; set; }

        public int? CustomerStatusID { get; set; }
        public int? CustomerTypeID { get; set; }
        public string WebsiteUrl { get; set; }
        public string RegistrationNumber { get; set; }
        public string VatNumber { get; set; }
    }

    public class CreateCustomerCommandHandler : IServiceRequestHandlerWrapper<CreateCustomerCommand, CustomerDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public CreateCustomerCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<ServiceResponse<CustomerDetailsDTO>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EntityModels.Customers>(request);

            _context.Customers.Add(entity);
            _context.SaveChanges();

            var dto = _mapper.Map<CustomerDetailsDTO>(entity);

            return Task.FromResult(ServiceResponse.Ok<CustomerDetailsDTO>(dto));
        }
    }
}
