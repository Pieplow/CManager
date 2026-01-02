using CManager.Core.Models;

namespace CManager.Infrastructure.Interfaces
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Attempts to add a new customer to the data store if a customer with the same email does not already exist.
        /// </summary>
        /// <remarks>If a customer with the same email address already exists, the method does not add the
        /// new customer and returns false.</remarks>
        /// <param name="customer">The customer to add. Cannot be null. The customer's email must be unique among all existing customers.</param>
        /// <returns>true if the customer was successfully added; otherwise, false.</returns>
        bool CreateCustomer(Customer customer);

        /// <summary>
        /// Retrieves a customer by their email address.
        /// </summary>
        /// <param name="email">Email to find a single customer</param>
        /// <returns>Single customer</returns>
        Customer? GetCustomerByEmail(string email);

        /// <summary>
        /// Retrieves a list of all customers from the data source.
        /// </summary>
        /// <returns>A list of <see cref="Customer"/> objects representing all customers. The list will be empty if no customers
        /// are found.</returns>
        List<Customer> GetAllCustomers();

        /// <summary>
        /// Updates the information of an existing customer based on the customer's email address.
        /// </summary>
        /// <remarks>If no customer with the specified email exists, no update is performed and the method
        /// returns false. The update operation replaces the existing customer data with the provided
        /// information.</remarks>
        /// <param name="customer">The customer object containing the updated information. The customer's email is used to identify which
        /// customer to update. Cannot be null.</param>
        /// <returns>true if the customer was found and updated successfully; otherwise, false.</returns>
        bool UpdateCustomer(Customer customer);

        /// <summary>
        /// Deletes the customer with the specified email address from the data store.
        /// </summary>
        /// <param name="email">The email address of the customer to delete. Cannot be null or empty.</param>
        /// <returns>true if the customer was found and deleted successfully; otherwise, false.</returns>
        bool DeleteCustomer(string email);
    }
}


