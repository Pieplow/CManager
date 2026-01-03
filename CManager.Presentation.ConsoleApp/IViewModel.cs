namespace CManager.Presentation.ConsoleApp
{
    public interface IViewModel
    {
        void AddCustomer();
        void GetCustomerByEmail();
        void UpdateCustomer();
        void DeleteCustomer();
        void ViewAllCustomers();
    }
}