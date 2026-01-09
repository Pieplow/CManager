using CManager.Core.Models;
using CManager.Infrastructure.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace CManager.Presentation.GuiApp.ViewModels
{
    public partial class GetCustomersViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Customer> _customerList;

        private readonly ICustomerService _service;
        private readonly Action _backToMenu;
        private readonly Action<Customer> _onUpdate;

        public GetCustomersViewModel(ICustomerService service, ObservableCollection<Customer> sharedList, Action backToMenu, Action<Customer> onUpdate)
        {
            _service = service;
            CustomerList = sharedList;
            _backToMenu = backToMenu;
            _onUpdate = onUpdate;
        }


        public void LoadCustomers()
        {
            CustomerList.Clear();
            foreach (var customer in _service.GetAllCustomers())
            {
                CustomerList.Add(customer);
            }
        }

       

        [RelayCommand]
        public void UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                _onUpdate?.Invoke(customer);
            }
        }

        [RelayCommand]
        public void DeleteCustomer(Customer customer)
        {
            if (customer == null)
            {
                return;
            }

            bool success = _service.DeleteCustomer(customer.Email);
            if (success)
            {
                MessageBox.Show($"Customer {customer.FirstName} deleted successfully.");
                RefreshCustomers();
            }
            else
            {
                MessageBox.Show($"Failed to delete customer {customer.FirstName}.");
            }
        }

        [RelayCommand]
        public void BackToMenu()
        {
            _backToMenu();
        }

        private void RefreshCustomers()
        {
            CustomerList.Clear();
            foreach (var customer in _service.GetAllCustomers())
            {
                CustomerList.Add(customer);
            }
        }
    }
}
