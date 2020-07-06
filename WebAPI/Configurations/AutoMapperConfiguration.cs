using AutoMapper;
using EntityModels;
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

            // customer to customer details dto
            CreateMap<Customers, CustomerDetailsDTO>()
                .ForMember(x => x.CompanyStatus, x => x.MapFrom(s => s.CustomerStatus.CustomerStatus))
                .ForMember(x => x.CompanyType, x => x.MapFrom(s => s.CustomerType.CustomerType));


            // customer to customer list dto
            CreateMap<Customers, CustomerListDTO>()
                .ForMember(x => x.CompanyStatus, x => x.MapFrom(s => s.CustomerStatus.CustomerStatus))
                .ForMember(x => x.CompanyType, x => x.MapFrom(s => s.CustomerType.CustomerType));
        }
    }
}
