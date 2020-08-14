using AutoMapper;
using EntityModels;
using Service.Commands;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Configurations
{
    public class AutoMapperConfiguration : Profile
    {

        public AutoMapperConfiguration()
        {
            AddCustomersConfiguration();
        }

        private void AddCustomersConfiguration()
        {
            // customer to customer details dto
            CreateMap<Customers, CustomerDetailsDTO>()
                .ForMember(x => x.CompanyStatus, x => x.MapFrom(s => s.CustomerStatus.CustomerStatus))
                .ForMember(x => x.CompanyType, x => x.MapFrom(s => s.CustomerType.CustomerType))
                .ForMember(x=> x.CustomerAddresses, x=> x.MapFrom(s=> s.CustomerAddresses.Select(a=> a.Address).ToList()));


            // customer to customer list dto
            CreateMap<Customers, CustomerListDTO>()
                .ForMember(x => x.CompanyStatus, x => x.MapFrom(s => s.CustomerStatus.CustomerStatus))
                .ForMember(x => x.CompanyType, x => x.MapFrom(s => s.CustomerType.CustomerType));

            // address to address details dto
            CreateMap<Addresses, AddressDetailsDTO>();
            CreateMap<AddressDetailsDTO, Addresses>();

            // commands and queries
            CreateMap<CreateCustomerCommand, Customers>();
            CreateMap<UpdateCustomerCommand, Customers>();

            
        }
    }
}
