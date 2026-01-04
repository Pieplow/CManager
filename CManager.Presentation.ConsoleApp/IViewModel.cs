namespace CManager.Presentation.ConsoleApp
{
    public interface IViewModel
    {
        void AddCustomer();
        void GetCustomerByEmail();
        void ViewAllCustomers();
        void UpdateCustomer();
        void DeleteCustomer();
        void DeleteAllCustomers();
    }
}