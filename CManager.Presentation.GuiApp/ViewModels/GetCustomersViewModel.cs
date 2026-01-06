using CManager.Core.Models;
using CManager.Infrastructure.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

namespace CManager.Presentation.GuiApp.ViewModels
{
    public partial class GetCustomersViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Customer>? _customerList;
        private readonly ICustomerService _service;

        public GetCustomersViewModel(ICustomerService service)
        {
            _service = service;
            LoadCustomers();
        }

        public void LoadCustomers()
        {
            var customers = _service.GetAllCustomers();
            CustomerList = new ObservableCollection<Customer>(customers);
        }

        public void UpdateCustomer(Customer customer)
        {// Lägg till logik för att uppdatera med modellen istället för att skicka in varje fält separat.
            _service.UpdateCustomer(customer);
        }
    }
}
