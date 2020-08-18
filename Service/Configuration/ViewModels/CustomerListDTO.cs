using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ViewModels
{
    public class CustomerListDTO
    {
        public CustomerListDTO()
        {
           
        }
        public int CustomerID { get; set; }

        public string CompanyName { get; set; }
        public string NatureOfBusiness { get; set; }

        public string CompanyStatus { get; set; }
        public string CompanyType { get; set; }
        public string WebsiteUrl { get; set; }
        public string RegistrationNumber { get; set; }
        public string VatNumber { get; set; }
    }
}
