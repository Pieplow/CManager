using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Core.Models
{
    public class Address
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
}
