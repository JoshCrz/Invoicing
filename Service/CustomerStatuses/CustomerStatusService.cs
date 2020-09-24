using MediatR;
using Repository;
using Service.Commands;
using Service.Queries;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.CustomerStatuses
{
    public class CustomerStatusService
    {

        InvoicingContext db;
        IMediator _mediator;
        public CustomerStatusService(InvoicingContext context, IMediator mediator)
        {
            db = context;
            _mediator = mediator;
        }

        public IServiceResponse<GetCustomerStatusListQuery, List<CustomerStatusListDTO>> GetAll(GetCustomerStatusListQuery query)
        {
            var queryResult = _mediator
                                .Send(query).Result;

            return ServiceResponse.Success(query, queryResult);
        }
        public IServiceResponse<GetCustomerStatusDetailsQuery, CustomerStatusDetailsDTO> GetSingle(GetCustomerStatusDetailsQuery query)
        {
            var cresult = _mediator
                            .Send(query).Result;

            return ServiceResponse.Success(query, cresult);

        }

        public IServiceResponse<CreateCustomerStatusCommand, CustomerStatusDetailsDTO> CreateStatus(CreateCustomerStatusCommand command)
        {
            var cresult = _mediator
                            .Send(command).Result;

            return ServiceResponse.Success(command, cresult);
        }
        public IServiceResponse<UpdateCustomerStatusCommand, CustomerStatusDetailsDTO> UpdateStatus(UpdateCustomerStatusCommand command)
        {
            var cresult = _mediator
                            .Send(command).Result;

            return ServiceResponse.Success(command, cresult);

        }
        public IServiceResponse<DeleteCustomerStatusCommand, CustomerStatusDetailsDTO> DeleteStatus(DeleteCustomerStatusCommand command)
        {
            var cresult = _mediator
                            .Send(command).Result;

            return ServiceResponse.Success(command, cresult);

        }

    }
}
