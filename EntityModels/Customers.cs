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

        public string Address { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }

        // one to many relation between customers and contacts
        public virtual ICollection<Contacts> Contacts { get; set; }

        // one to many relation between customers and invoices
        public virtual ICollection<Invoices> Invoices { get; set; }
    }


}
