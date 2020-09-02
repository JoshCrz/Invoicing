using EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ViewModels
{
    public class InvoiceDetailsDTO
    {
        public string ReferenceNumber { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string InvoiceStatus { get; set; }

        public ICollection<InvoiceItemDTO> InvoiceItems { get; set; }
    }
}
