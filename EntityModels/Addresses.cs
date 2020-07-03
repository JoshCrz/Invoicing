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
        public string Country { get; set; }

        // many to many relation between addresses and customers
        public virtual ICollection<CustomersAddresses> CustomersAddresses { get; set; }

        // many to many relation between addresses and contacts
        public virtual ICollection<ContactsAddresses> ContactsAddresses { get; set; }


    }
}
