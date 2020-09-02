using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModels
{
    public class InvoiceItems
    {
        public int InvoiceItemID { get; set; }
        public int InvoiceID { get; set; }

        public string ItemTitle { get; set; }
        public string ItemDescription { get; set; }
        public string ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }

        public virtual Invoices Invoice { get; set; }
    }
}
