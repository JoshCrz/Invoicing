using MediatR;
using Repository;
using Service.Commands;
using Service.Queries;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Addresses
{
    public class AddressesService
    {
        InvoicingContext db;
        IMediator _mediator;
        public AddressesService(InvoicingContext context, IMediator mediator)
        {
            db = context;
            _mediator = mediator;
        }

        public IServiceResponse<GetAddressListQuery, List<AddressListDTO>> GetAll(GetAddressListQuery query)
        {
            var queryResult = _mediator
                                .Send(query).Result;

            return ServiceResponse.Success(query, queryResult);
        }
        public IServiceResponse<GetAddressDetailsQuery, AddressDetailsDTO> GetSingle(GetAddressDetailsQuery query)
        {
            var cresult = _mediator
                            .Send(query).Result;

            return ServiceResponse.Success(query, cresult);

        }

        public IServiceResponse<CreateAddressCommand, AddressDetailsDTO> CreateStatus(CreateAddressCommand command)
        {
            var cresult = _mediator
                            .Send(command).Result;

            return ServiceResponse.Success(command, cresult);
        }
        public IServiceResponse<UpdateAddressCommand, AddressDetailsDTO> UpdateStatus(UpdateAddressCommand command)
        {
            var cresult = _mediator
                            .Send(command).Result;

            return ServiceResponse.Success(command, cresult);

        }
        public IServiceResponse<DeleteAddressCommand, AddressDetailsDTO> DeleteStatus(DeleteAddressCommand command)
        {
            var cresult = _mediator
                            .Send(command).Result;

            return ServiceResponse.Success(command, cresult);

        }


    }
}
