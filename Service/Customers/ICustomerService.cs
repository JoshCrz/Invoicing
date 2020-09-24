using Service.Queries;
using Service.Commands;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface ICustomerService
    {
        IServiceResponse<GetCustomerListQuery, List<CustomerListDTO>> GetAll(GetCustomerListQuery query);
        IServiceResponse<GetCustomerDetailsQuery, CustomerDetailsDTO> GetSingle(GetCustomerDetailsQuery query);
        IServiceResponse<CreateCustomerCommand, CustomerDetailsDTO> CreateCustomer(CreateCustomerCommand command);
        IServiceResponse<UpdateCustomerCommand, CustomerDetailsDTO> UpdateCustomer(int customerID, UpdateCustomerCommand command);
        IServiceResponse<DeleteCustomerCommand, CustomerDetailsDTO> DeleteCustomer(int customerID, DeleteCustomerCommand command);
        //IServiceResponse<CreateAddressCommand, AddressDetailsDTO> AddCustomerAddress(int customerID, CreateAddressCommand command);
        //IServiceResponse<UpdateAddressCommand, AddressDetailsDTO> UpdateCustomerAddress(int customerID, UpdateAddressCommand command);
        //IServiceResponse<DeleteAddressCommand, AddressDetailsDTO> RemoveCustomerAddress(int customerID, DeleteAddressCommand command);


        //IServiceResponse<CreateCustomerStatusCommand, CustomerStatusDetailsDTO> AddCustomerStatus(int customerID, CreateCustomerStatusCommand command);
        //IServiceResponse<UpdateCustomerStatusCommand, CustomerStatusDetailsDTO> UpdateCustomerStatus(int customerID, UpdateCustomerStatusCommand command);
        //IServiceResponse<DeleteCustomerStatusCommand, CustomerStatusDetailsDTO> RemoveCustomerStatus(int customerID, DeleteCustomerStatusCommand command);

    }
}
