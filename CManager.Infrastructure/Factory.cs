using CManager.Core.Models;

namespace CManager.Infrastructure
{
    public class Factory
    {
        public static Customer Create(Customer customer)
        {
            return new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = new Address
                {
                    Street = customer.Address.Street,
                    PostalCode = customer.Address.PostalCode,
                    City = customer.Address.City
                }
            };
        }

        public static Customer Update(
           Customer existingCustomer,
           string firstName,
           string lastName,
           string email,
           string phoneNumber,
           string streetAddress,
           string postalCode,
           string city)
        {
            return new Customer
            {
                Id = existingCustomer.Id,
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
        }
    }
}
