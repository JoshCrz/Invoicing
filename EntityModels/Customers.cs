using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public int? CustomerStatusID { get; set; }
        public int? CustomerTypeID { get; set; }
        public string WebsiteUrl { get; set; }
        public string RegistrationNumber { get; set; }
        public string VatNumber { get; set; }



        // one to many relation between customers and contacts
        public virtual ICollection<Contacts> Contacts { get; set; }

        // one to many relation between customers and invoices
        public virtual ICollection<Invoices> Invoices { get; set; }

        public virtual CustomerStatuses CustomerStatus { get; set; }
        public virtual CustomerTypes CustomerType { get; set; }

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

    public class CustomerStatuses
    {
        [Key]
        public int CustomerStatusID { get; set; }
        public string CustomerStatus { get; set; }

        public ICollection<Customers> Customers { get; set; }

    }

    public class CustomerTypes
    {
        [Key]
        public int CustomerTypeID { get; set; }
        public string CustomerType { get; set; }
        public ICollection<Customers> Customers { get; set; }

    }
}
