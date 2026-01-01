using CManager.Core.Interfaces;
using CManager.Core.Models;

namespace CManager.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository) => _repository = repository;

        public Customer GetCustomerByEmail(string email)
        {
            var customer = _repository.GetCustomerByEmail(email);

            return customer ?? new Customer();
        }

        public IEnumerable<Customer> GetAllCustomers(out bool hasError)
        {
            try
            {
                hasError = false;
                return _repository.GetAll();
            }
            catch
            {
                hasError = true;
                return [];
            }
        }

        public bool AddCustomer(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string streetAddress,
            string postalCode,
            string city)
        {
            try
            {
                var customers = _repository.GetAll();

                var newCustomer = new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Address = new Address
                    {
                        Street = streetAddress,
                        PostalCode = postalCode,
                        City = city
                    }
                };
                // Add the new customer to the list
                customers.Add(newCustomer);
                return _repository.SaveAll(customers);
            }
            catch
            {
                return false;
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

            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.PhoneNumber = phoneNumber;
            customer.Address.Street = streetAddress;
            customer.Address.PostalCode = postalCode;
            customer.Address.City = city;

            return _repository.UpdateCustomer(customer);
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



