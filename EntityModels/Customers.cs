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
            CustomersAddresses = new HashSet<CustomersAddresses>();
        }

        public int CustomerID { get; set; }

        public string CompanyName { get; set; }
        public string NatureOfBusiness { get; set; }
        public int? CompanyStatusID { get; set; }
        public int? CompanyTypeID { get; set; }
        public string WebsiteUrl { get; set; }
        public string RegistrationNumber { get; set; }
        public string VatNumber { get; set; }



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
        public Addresses Address { get; set; }

    }
}
