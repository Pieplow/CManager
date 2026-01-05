using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Presentation.GuiApp.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;

        public MenuViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [RelayCommand]
        public void NavigateToAddCustomersView()
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModels>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddCustomersViewModel>();
        }

        [RelayCommand]
        public void NavigateToGetCustomersView()
        {

        }

        [RelayCommand]
        public void NavigateToUpdateCustomersView()
        {

        }

        [RelayCommand]
        public void NavigateBackToMenuView()
        {

        }
    }
}
