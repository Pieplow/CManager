using CManager.Infrastructure.Interfaces;

namespace CManager.Presentation.ConsoleApp
{
    public class ViewModel : IViewModel
    {
        private readonly ICustomerService _customerService;
        public ViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void AddCustomer()
        {
        
            Console.Write("Enter First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Enter Email: ");
            var email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("First Name and Email cannot be empty.");
                return;
            }
            var customer = new Core.Models.Customer
            {
                FirstName = firstName,
                Email = email
            };
            var success = _customerService.CreateCustomer(customer);
            if (success)
            {
                Console.WriteLine("Customer added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add customer. A customer with the same email may already exist.");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        public void GetCustomerByEmail()
        {
            Console.Write("Enter Email: ");
            var email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty.");
                return;
            }
            var customer = _customerService.GetCustomerByEmail(email);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
            }
            else
            {
                Console.WriteLine($"Customer Found: Name: {customer.FirstName}, Email: {customer.Email}");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        public void ViewAllCustomers()
        {
            var customers = _customerService.GetAllCustomers(out bool hasError);
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found.");
                return;
            }

            Console.WriteLine("Customer List:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Name: {customer.FirstName}, Email: {customer.Email}");

            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        public void UpdateCustomer()
        {
            Console.Write("Enter Email of customer to update: ");
            var email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty.");
                return;
            }
            var existingCustomer = _customerService.GetCustomerByEmail(email);
            if (existingCustomer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }
            Console.Write("Enter new First Name (leave blank to keep current): ");
            var newFirstName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newFirstName))
            {
                existingCustomer.FirstName = newFirstName;
            }
            var success = _customerService.UpdateCustomer(
                existingCustomer.Email, 
                existingCustomer.FirstName, 
                existingCustomer.LastName, 
                existingCustomer.PhoneNumber,
                existingCustomer.Address.Street,
                existingCustomer.Address.City,
                existingCustomer.Address.PostalCode);

            if (success)
            {
                Console.WriteLine("Customer updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update customer.");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
        public void DeleteCustomer()
        {
            Console.Write("Enter Email of customer to delete: ");
            var email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty.");
                return;
            }
            var success = _customerService.DeleteCustomer(email);
            if (success)
            {
                Console.WriteLine("Customer deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete customer. Customer may not exist.");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}
