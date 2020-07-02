using System;
using System.Collections.Generic;

namespace EntityModels
{
    public class Customers 
    {
        public Customers()
        {
            Contacts = new HashSet<Contacts>();
            Invoices = new HashSet<Invoices>();
        }

        public int CustomerID { get; set; }

        public string CompanyName { get; set; }


        // one to many relation between customers and contacts
        public virtual ICollection<Contacts> Contacts { get; set; }

        // one to many relation between customers and invoices
        public virtual ICollection<Invoices> Invoices { get; set; }

        // many to many relation between customers and addresses 
        public virtual ICollection<CustomersAddresses> CustomersAddresses { get; set; }
    }

    public class CustomersAddresses
    {
        public int CustomerID { get; set; }
        public int AddressID { get; set; }
        public Customers Customer { get; set; }
        public Addresses Addresse { get; set; }

    }
}
