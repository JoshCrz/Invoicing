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
using FluentValidation;

namespace Service.Commands
{
    public class DeleteCustomerCommand : ICqrsRequestWrapper<CustomerDetailsDTO>
    {
        public int CustomerID { get; set; }
    }

    public class DeleteCustomerCommandHandler : ICqrsRequestHandlerWrapper<DeleteCustomerCommand, CustomerDetailsDTO>
    {

        InvoicingContext _context;
        IMapper _mapper;
        public DeleteCustomerCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<CqrsResponse<CustomerDetailsDTO>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.Customers
                                    .FirstOrDefault(x => x.CustomerID == request.CustomerID);

            if (entity == null)
                return Task.FromResult(CqrsResponse.NotFound<CustomerDetailsDTO>());

            _context.Customers.Remove(entity);
            _context.SaveChanges();

            var mapped = _mapper.Map<CustomerDetailsDTO>(entity);

            return Task.FromResult(CqrsResponse.QuerySuccess(mapped));

        }
    }

    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x => x.CustomerID).NotEmpty();

        }
    }
}
