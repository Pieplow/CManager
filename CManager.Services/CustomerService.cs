using CManager.Core.Interfaces;
using CManager.Core.Models;

namespace CManager.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository) => _repository = repository;

        public bool DeleteCustomer(Guid id)
        {
            throw new NotImplementedException();
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
    }
}



