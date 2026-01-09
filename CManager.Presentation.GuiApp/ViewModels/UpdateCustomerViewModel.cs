using CManager.Core.Models;
using CManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace CManager.Presentation.GuiApp.ViewModels
{
    public partial class UpdateCustomerViewModel : ObservableObject
    {
        private readonly CustomerService _customerService;
        private readonly Action _backToMenu;

        [ObservableProperty]
        public Customer _selectedCustomer = new();

        private readonly ObservableCollection<Customer> _customerList;

        public UpdateCustomerViewModel(CustomerService customerService, ObservableCollection<Customer> sharedList, Action backToMenu)
        {
            _customerService = customerService;
            _customerList = sharedList;
            _backToMenu = backToMenu;
        }

        [RelayCommand]
        public void UpdateCustomer()
        {
            bool success = _customerService.UpdateCustomer(SelectedCustomer);

            if (success)
            {
                MessageBox.Show("Customer updated successfully.");
                _backToMenu();
            }
         }

        [RelayCommand]
        public void BackToMenu()
        {
            _backToMenu();
        }
    }
}
