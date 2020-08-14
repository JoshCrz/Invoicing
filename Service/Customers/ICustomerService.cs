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
        IServiceResponse<AddCustomerAddressCommand, AddressDetailsDTO> AddAddress(int customerID, AddCustomerAddressCommand command);
        IServiceResponse<RemoveCustomerAddressCommand, AddressDetailsDTO> RemoveAddress(int customerID, RemoveCustomerAddressCommand command);

    }
}
