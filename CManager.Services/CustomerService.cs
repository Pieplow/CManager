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

        public List<Customer> GetAllCustomers(out bool hasError)
        {
            try
            {
                hasError = false;
                return _repository.GetAllCustomers();
            }
            catch
            {
                hasError = true;
                return [];
            }
        }

        public bool UpdateCustomer(
            string email,
            string firstName,
            string lastName,
            string phoneNumber,
            string streetAddress,
            string postalCode,
            string city)
        {
            var customer = _repository.GetCustomerByEmail(email);
            if (customer == null)
            {
                return false;
            }

            Customer updatedCustomer = Factory.Update(customer, firstName, lastName, email, phoneNumber, streetAddress, postalCode, city);

            return _repository.UpdateCustomer(updatedCustomer);
        }

        public bool DeleteCustomer(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            return _repository.DeleteCustomer(email);
        }
    }
}



