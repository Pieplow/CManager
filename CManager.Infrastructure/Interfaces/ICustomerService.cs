using System;
using System.Collections.Generic;
using System.Text;
using CManager.Core.Models;

namespace CManager.Core.Interfaces
{
    public interface ICustomerService
    {
        bool CreateCustomer(string firstName, string lastName, string email, string phoneNumber, string streetAddress, string postalCode, string city);
        
        IEnumerable<Customer> GetAllCustomers(out bool hasError);

        bool DeleteCustomer(string email);
    }
}
