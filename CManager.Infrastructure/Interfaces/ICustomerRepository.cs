using CManager.Core.Models;

namespace CManager.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Customer? GetCustomerByEmail(string email);
        
        List<Customer> GetAll();
        
        bool SaveAll(List<Customer> customers);
        
        bool UpdateCustomer(Customer customer);

        bool DeleteCustomer(string email);
    }
}


