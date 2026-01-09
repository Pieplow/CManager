using CManager.Core.Models;
using CManager.Infrastructure.Interfaces;
using CManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace CManager.Presentation.GuiApp.ViewModels
{
    public partial class MainViewModels : ObservableObject
    {
        private readonly CustomerService _service;

        private UserControl _currentView = default!;
        public UserControl CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public ICommand ShowMenuCommand { get; }
        public ICommand ShowCustomersCommand { get; }
        public ICommand ShowAddCustomerCommand { get; }
        public ICommand ShowUpdateCustomerCommand { get; }

        public ObservableCollection<Customer> Customers { get; set; }

        private readonly AddCustomersViewModel _addCustomerViewModel;
        private readonly GetCustomersViewModel _getCustomersViewModel;
        private readonly UpdateCustomerViewModel _updateCustomerViewModel;

        public MainViewModels(CustomerService service)
        {
            _service = service;

            Customers = new ObservableCollection<Customer>(_service.GetAllCustomers());

            _updateCustomerViewModel = new UpdateCustomerViewModel(_service, Customers, ShowMenu);
            _addCustomerViewModel = new AddCustomersViewModel(_service, Customers, ShowMenu);
            _getCustomersViewModel = new GetCustomersViewModel(_service, Customers, ShowMenu, ShowUpdate);
           

            ShowMenuCommand = new RelayCommand(() => ShowMenu());            

            ShowCustomersCommand = new RelayCommand(() => 
                CurrentView = new Views.GetCustomersView { DataContext = _getCustomersViewModel });

            ShowAddCustomerCommand = new RelayCommand(() =>
                CurrentView = new Views.AddCustomerView { DataContext = _addCustomerViewModel });

            ShowUpdateCustomerCommand = new RelayCommand(() =>
                CurrentView = new Views.UpdateCustomerView { DataContext = _updateCustomerViewModel });

            CurrentView = new Views.MenuView { DataContext = this };
        }

        public void ShowUpdate(Customer customer) { 

            if (customer != null)
            {
            _updateCustomerViewModel.SelectedCustomer = customer;
            CurrentView = new Views.UpdateCustomerView { DataContext = _updateCustomerViewModel };
            }

        }

        public void ShowMenu()
        {
            CurrentView = new Views.MenuView { DataContext = this };
        }

        public void RefreshCustomers()
        {
            Customers.Clear();
            foreach (var customer in _service.GetAllCustomers())
            {
                Customers.Add(customer);
            }
        }
    }
}
