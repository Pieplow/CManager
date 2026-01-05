using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection; // Fixes CS1061: adds GetRequiredService extension
using CManager.Presentation.GuiApp.ViewModels; // Fixes CS0246: ensures CustomersViewModel is found

namespace CManager.Presentation.GuiApp.ViewModels
{
    public partial class MainViewModels : ObservableObject
    {
        [ObservableProperty] 
        private ObservableObject _currentViewModel;
        private readonly IServiceProvider _serviceProvider;

        public MainViewModels(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _currentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();
        }
    }
}
