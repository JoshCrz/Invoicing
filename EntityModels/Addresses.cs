using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModels
{
    public class Addresses
    {

        public int AddressID { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        public string PostCode { get; set; }
        public string Town { get; set; }
        public string County { get; set; }

        public ICollection<Customers> Customers { get; set; }
        public ICollection<Contacts> Contacts { get; set; }


    }
}
