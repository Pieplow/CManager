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
            Customer updateCustomer,
            //Inparameter is optional
            string? currentUserEmail = null)
        {
            var identifierEmail = currentUserEmail ?? updateCustomer.Email;

            var customer = _repository.GetCustomerByEmail(identifierEmail);
            if (customer == null)
            {
                return false;
            }

            Customer updatedCustomer = Factory.Update(
                customer,
                updateCustomer.FirstName,
                updateCustomer.LastName,
                updateCustomer.Email,
                updateCustomer.PhoneNumber,
                updateCustomer.Address.Street,
                updateCustomer.Address.PostalCode,
                updateCustomer.Address.City);

            return _repository.UpdateCustomer(identifierEmail, updatedCustomer);
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



