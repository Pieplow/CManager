using CManager.Core.Models;
using CManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;

namespace CManager.Presentation.GuiApp.ViewModels
{
    public partial class AddCustomersViewModel : ObservableObject
    {
        public readonly CustomerService _customerService;
        [ObservableProperty]
        public Customer _newCustomer;
        private readonly IServiceProvider _serviceProvider;

        public AddCustomersViewModel(CustomerService customerService, IServiceProvider serviceProvider)
        {
            _customerService = customerService;
            _newCustomer = new();
            _serviceProvider = serviceProvider;
        }

        [RelayCommand]
        public void AddCustomer()
        {
            bool success = _customerService.CreateCustomer(NewCustomer);
            MessageBox.Show(success ? "Customer added successfully." : "Failed to add customer. Customer may already exist.");
        }

        [RelayCommand]
        public void BackToMenu()
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModels>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();
        }
    }
}