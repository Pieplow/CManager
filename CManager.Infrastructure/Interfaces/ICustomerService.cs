using CManager.Core.Models;

namespace CManager.Infrastructure.Interfaces
{
    public interface ICustomerService
    {
        bool CreateCustomer(Customer customer);

        List<Customer> GetAllCustomers();
        
        Customer GetCustomerByEmail(string email);

        bool UpdateCustomer(string currentUserEmail, string email, string firstName, string lastName, string phoneNumber, string streetAddress, string postalCode, string city);
        
        bool DeleteCustomer(string email);

        bool DeleteAllCustomers();
    }
}
