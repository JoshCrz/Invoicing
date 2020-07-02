using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModels
{
    public class Invoices 
    {
        public int InvoiceID { get; set; }

        public string ReferenceNumber { get; set; }

        // many to one relation between invoices and customer
        public virtual Customers Customer { get; set; }

    }
}
