using System.Text.Json;
using CManager.Core.Interfaces;
using CManager.Core.Models;

namespace CManager.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string FilePath = "Data/customers.json";
        public CustomerRepository() { }

        /// <summary>
        /// Retrieves a customer by their email address.
        /// </summary>
        /// <param name="email">Email to find a single customer</param>
        /// <returns>Single customer</returns>
        public Customer? GetCustomerByEmail(string email)
        {
            var customers = GetAll();
            return customers.Find(c => c.Email == email);
        }

        /// <summary>
        /// Retrieves all customers stored in the data file.
        /// </summary>
        /// <returns>A list of <see cref="Customer"/> objects representing all customers. Returns an empty list if no customers
        /// are found or if the data file does not exist.</returns>
        public List<Customer> GetAll()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Customer>();
            }

            var json = File.ReadAllText(FilePath);
            var customers = System.Text.Json.JsonSerializer.Deserialize<List<Customer>>(json);

            return customers ?? new List<Customer>();
        }

        
        public bool SaveAll(List<Customer> customers)
        {
            if (customers == null)
            {
                return false;
            }

            string directory = Path.GetDirectoryName(FilePath)!;


            if (string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var json = JsonSerializer.Serialize(customers, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FilePath, json);
            return true;
        }

        public bool UpdateCustomer(Customer customer)
        {
            var customers = GetAll();
            var customerToUpdate = customers.Find(c => c.Email == customer.Email );
            if (customerToUpdate == null)
            {
                return false;
            }

            customerToUpdate = customer;
            return SaveAll(customers);

        }
 
        public bool DeleteCustomer(string email)
        {
            var customers = GetAll();
            var customerToRemove = customers.Find(c => c.Email == email);
            if (customerToRemove == null)
            {
                return false;
            }

            customers.Remove(customerToRemove);
            return SaveAll(customers);
        }
    }
}
