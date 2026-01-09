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
            Console.WriteLine("Press 0 and Enter to go back to menu");
            Console.WriteLine("------------------------------------");
            Console.Write("Enter First Name: ");
            var firstName = Console.ReadLine();
            if (CheckInput(firstName)) return;
            Console.Write("Enter Last Name: ");
            var lastName = Console.ReadLine();
            if (CheckInput(lastName)) return;
            Console.Write("Enter Email: ");
            var email = Console.ReadLine();
            if (CheckInput(email)) return;
            Console.Write("Enter Phone Number: ");
            var phoneNumber = Console.ReadLine();
            if (CheckInput(phoneNumber)) return;
            Console.Write("Enter Street Address: ");
            var street = Console.ReadLine();
            if (CheckInput(street)) return;
            Console.Write("Enter City: ");
            var city = Console.ReadLine();
            if (CheckInput(city)) return;
            Console.Write("Enter Postal Code: ");
            var postalCode = Console.ReadLine();
            if (CheckInput(postalCode)) return;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("First Name and Email cannot be empty.");
                return;
            }
            var customer = new Core.Models.Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = new Core.Models.Address
                {
                    Street = street,
                    City = city,
                    PostalCode = postalCode
                }
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
            var customers = _customerService.GetAllCustomers();
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found.");
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Customer List:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"\n* First name: {customer.FirstName}\n* Last name: {customer.LastName}\n* Email: {customer.Email}\n* Phone number: {customer.PhoneNumber}\n* Street: {customer.Address.Street}\n* Postal code: {customer.Address.PostalCode}\n* City: {customer.Address.City}\n");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        public void UpdateCustomer()
        {
            Console.Write("Enter Email of customer to update: ");
            var emailToUpdate = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(emailToUpdate))
            {
                Console.WriteLine("Email cannot be empty.");
                return;
            }
            var existingCustomer = _customerService.GetCustomerByEmail(emailToUpdate);
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
            Console.Write("Enter new Last Name (leave blank to keep current): ");
            var newLastName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newLastName))
            {
                existingCustomer.LastName = newLastName;
            }
            Console.Write("Enter new Email (leave blank to keep current): ");
            var newEmail = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newEmail))
            {
                existingCustomer.Email = newEmail;
            }
            Console.Write("Enter new Phonenumber (leave blank to keep current): ");
            var newPhoneNumber = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPhoneNumber))
            {
                existingCustomer.PhoneNumber = newPhoneNumber;
            }
            Console.Write("Enter new Street (leave blank to keep current): ");
            var newStreet = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newStreet))
            {
                existingCustomer.Address.Street = newStreet;
            }
            Console.Write("Enter new City (leave blank to keep current): ");
            var newCity = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newCity))
            {
                existingCustomer.Address.City = newCity;
            }
            Console.Write("Enter new Postal code (leave blank to keep current): ");
            var newPostalCode = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPostalCode))
            {
                existingCustomer.Address.PostalCode = newPostalCode;
            }

            var success = _customerService.UpdateCustomer(existingCustomer);

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

        public void DeleteAllCustomers()
        {
            Console.Write("Are you sure you want to delete all customers? (y/n): ");
            var confirmation = Console.ReadLine();
            if (confirmation?.ToLower() == "y")
            {
                var success = _customerService.DeleteAllCustomers();
                if (success)
                {
                    Console.WriteLine("All customers deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to delete all customers.");
                }
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        private bool CheckInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty.");
                return true;
            }

            if (input == "0")
            {
                Console.WriteLine("Operation cancelled by user");
                return true;
            }
            return false;
        }
    }
}
