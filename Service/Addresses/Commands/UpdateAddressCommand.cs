using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Commands
{
    public class UpdateAddressCommand : ICqrsRequestWrapper<AddressDetailsDTO>
    {
        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostCode { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }

    }

    public class UpdateAddressCommandHandler : ICqrsRequestHandlerWrapper<UpdateAddressCommand, AddressDetailsDTO>
    {
        InvoicingContext _context;
        IMapper _mapper;
        public UpdateAddressCommandHandler(InvoicingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<CqrsResponse<AddressDetailsDTO>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            // find address
            var address = _context.CustomerAddresses
                                    .FirstOrDefault(x => x.AddressID == request.AddressID).Address;

            _mapper.Map(request, address);
            _context.SaveChanges();

            var dto = _mapper.Map<AddressDetailsDTO>(address);

            return Task.FromResult(CqrsResponse.QuerySuccess(dto));
        }
    }

}
