﻿using EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ViewModels
{
    public class CustomerDetailsDTO : CustomerListDTO
    {
       
        public ICollection<AddressDetailsDTO> CustomerAddresses { get; set; }
    }
}
