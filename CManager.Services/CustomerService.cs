using CManager.Core.Models;
using CManager.Infrastructure;
using CManager.Infrastructure.Interfaces;

namespace CManager.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public bool CreateCustomer(Customer customer)
        {
            try
            {
                if (CustomerExists(customer.Email)) 
                { 
                    return false;
                }

                Customer newCustomer = Factory.Create(customer);
                return _repository.CreateCustomer(customer);
            }
            catch
            {
                return false;
            }
        }

        public Customer GetCustomerByEmail(string email)
        {
            var customer = _repository.GetCustomerByEmail(email);

            return customer ?? new Customer();
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                return _repository.GetAllCustomers();
            }
            catch
            {
                return [];
            }
        }

        public bool UpdateCustomer(
            string currentUserEmail,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string streetAddress,
            string postalCode,
            string city)
        {
            var customer = _repository.GetCustomerByEmail(currentUserEmail);
            if (customer == null)
            {
                return false;
            }

            Customer updatedCustomer = Factory.Update(customer, firstName, lastName, email, phoneNumber, streetAddress, postalCode, city);

            return _repository.UpdateCustomer(currentUserEmail, updatedCustomer);
        }

        public bool DeleteCustomer(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            return _repository.DeleteCustomer(email);
        }

        public bool CustomerExists(string email)
        {
            var customer = _repository.GetCustomerByEmail(email);
            return customer != null;
        }

        public bool DeleteAllCustomers()
        { 
            return _repository.DeleteAllCustomers();
        }
    }
}



