using CManager.Core.Models;

namespace CManager.Infrastructure.Interfaces
{
    public interface ICustomerService
    {
        bool CreateCustomer(Customer customer);

        List<Customer> GetAllCustomers();
        
        Customer GetCustomerByEmail(string email);

        bool UpdateCustomer(Customer updateCustomer, string? currentUserEmail = null);
        
        bool DeleteCustomer(string email);

        bool DeleteAllCustomers();
    }
}
