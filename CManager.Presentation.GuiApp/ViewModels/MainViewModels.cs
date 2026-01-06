using CManager.Core.Models;
using CManager.Infrastructure.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace CManager.Presentation.GuiApp.ViewModels
{
    public partial class MainViewModels : ObservableObject
    {
        [ObservableProperty] 
        private ObservableObject _currentViewModel;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICustomerService _service;

        public ObservableCollection<Customer> Customers { get; set; }

        public MainViewModels(IServiceProvider serviceProvider, ICustomerService service)
        {
            _serviceProvider = serviceProvider;
            _currentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();
            _service = service;

            Customers = new ObservableCollection<Customer>(_service.GetAllCustomers());
        }
    }
}
