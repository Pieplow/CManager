using CManager.Core.Models;

namespace CManager.Infrastructure
{
    public class Factory
    {
        public static Customer Create(
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
