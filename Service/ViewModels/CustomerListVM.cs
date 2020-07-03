using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ViewModels
{
    public class CustomerListVM
    {
        public CustomerListVM()
        {
            CompanyStatus = "Hard-coded Status";
            CompanyType = "Hard-coded Type";
        }

        public string CompanyName { get; set; }
        public string NatureOfBusiness { get; set; }

        public string CompanyStatus { get; set; }
        public string CompanyType { get; set; }
    }
}
