using CManager.Infrastructure.Interfaces;



namespace CManager.Presentation.ConsoleApp
{
    public class MenuController
    {
        private readonly ICustomerService _customerService;

        public MenuController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Customer Management System");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. View All Customers");
                Console.WriteLine("3. Exit");
                Console.WriteLine("4. Delete Customer");
                Console.Write("Please select an option: ");
                var input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        ViewAllCustomers();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    case "4":
                        DeleteCustomer();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }
            }
        }

        private void AddCustomer()
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
        }

        private void ViewAllCustomers()
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

        private void DeleteCustomer()
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
