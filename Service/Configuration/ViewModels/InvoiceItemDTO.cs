using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ViewModels
{
   public class InvoiceItemDTO
    {
        public string ItemTitle { get; set; }
        public string ItemDescription { get; set; }
        public string ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }

    }
}
