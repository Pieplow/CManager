using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Core.Models
{
    /// <summary>
    /// Represents a customer with identifying and contact information.
    /// </summary>
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Address Address { get; set; } = new Address();
    }
}
