using CManager.Infrastructure.Interfaces;

namespace CManager.Presentation.ConsoleApp
{
    public class MenuController
    {
        private readonly ICustomerService _customerService;
        private readonly IViewModel _viewModel;

        public MenuController(
            ICustomerService customerService,
            IViewModel viewModel)
        {
            _customerService = customerService;
            _viewModel = viewModel;
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                
                Console.WriteLine("Welcome to the Customer Management System");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Get Customer By Email");
                Console.WriteLine("3. View All Customers");
                Console.WriteLine("4. Update Customer");
                Console.WriteLine("5. Delete Customer");
                Console.Write("Please select an option: ");
                var input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        //Console.Clear();
                        _viewModel.AddCustomer();
                        break;
                    
                    case "2":
                        _viewModel.GetCustomerByEmail();
                        break;
                    case "3":
                        _viewModel.ViewAllCustomers();
                        break;
                    case "4":
                        _viewModel.UpdateCustomer();
                        break;
                    case "5":
                        _viewModel.DeleteCustomer();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }
            }
        }
    }

}
