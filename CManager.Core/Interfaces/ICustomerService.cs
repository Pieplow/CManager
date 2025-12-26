using System;
using System.Collections.Generic;
using System.Text;
using CManager.Core.Models;

namespace CManager.Core.Interfaces
{
    public interface ICustomerService
    {
        bool RegisterCustomer(string firstName, string lastName, string email, string phoneNumber, string streetAddress, string postalCode, string city);
        
        IEnumerable<CustomerModel> GetAllCustomers(out bool hasError);

        bool DeleteCustomer(Guid id);
    }
}
