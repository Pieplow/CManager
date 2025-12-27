using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Core.Models
{
    public class Customers
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public  Guid Id { get; set; } = string.Empty;

    }
}
