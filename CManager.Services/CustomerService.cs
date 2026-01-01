using CManager.Core.Interfaces;
using CManager.Core.Models;
using System.Linq.Expressions;

namespace CManager.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _Repository;
        public CustomerService(ICustomerRepository repository) => _Repository = repository;

        public bool DeleteCustomer(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAllCustomers(out bool hasError)
        {
            try              {
                hasError = false;
                return _Repository.GetAll();
            }
            catch
            {
                hasError = true;
                return [];
            }
        }

        public bool RegisterCustomer(
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
                var customers = _Repository.GetAll();

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
                /*spara listan i minnet */
                customers.Add(newCustomer);
                return _Repository.SaveAll(customers);
            }
            catch
            {
                return false;
            }
        }
    }
}



