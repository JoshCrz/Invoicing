using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Repository;
using Service.ViewModels;
using AutoMapper;
using FluentValidation;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Service.Commands
{
    public class UpdateCustomerCommand : ICqrsRequestWrapper<CustomerDetailsDTO>
    {
        public int CustomerID { get; set; }

        public string CompanyName { get; set; }
        public string NatureOfBusiness { get; set; }

        public int? CustomerStatusID { get; set; }
        public int? CustomerTypeID { get; set; }
        public string WebsiteUrl { get; set; }
        public string RegistrationNumber { get; set; }
        public string VatNumber { get; set; }

        public AddressDetailsDTO CustomerAddress { get; set; }
    }

    public class UpdateCustomerCommandHandler : ICqrsRequestHandlerWrapper<UpdateCustomerCommand, CustomerDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public UpdateCustomerCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CqrsResponse<CustomerDetailsDTO>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            
            var customer = _context.Customers
                                    .Include(x=> x.CustomerAddresses)
                                    .FirstOrDefault(x => x.CustomerID == request.CustomerID);


            //var address = customer.CustomersAddresses
            //                         .FirstOrDefault(x=> x.AddressID == request.CustomerAddress.AddressID)?.Address;

            //if(address == null)
            //{

            //    _mapper.Map(request.CustomerAddress, address);
            //    customer.CustomersAddresses.Add(new EntityModels.CustomersAddresses()
            //    {
            //        Address = address,
            //        Customer = customer
            //    });
            //} else
            //{
            //    _mapper.Map(request.CustomerAddress, address);
            //}

            _mapper.Map(request, customer);
            _context.Customers.Update(customer);
            _context.SaveChanges();

            var dto = _mapper.Map<CustomerDetailsDTO>(customer);

            return Task.FromResult(CqrsResponse.QuerySuccess(dto));
        }
    }


    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            
        }
    }

}
