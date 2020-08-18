using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ViewModels
{
    public class AddressDetailsDTO 
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
}
