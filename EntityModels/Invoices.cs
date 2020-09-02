using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModels
{
    public class Invoices 
    {
        public int InvoiceID { get; set; }

        public string ReferenceNumber { get; set; }

        public DateTime? IssuedDate { get; set; }
        public DateTime? DueDate { get; set; }

        public int? InvoiceStatusID { get; set; }

        // many to one relation between invoices and customer
        public virtual Customers Customer { get; set; }
        public virtual ICollection<InvoiceItems> InvoiceItems { get; set; }

    }
}
