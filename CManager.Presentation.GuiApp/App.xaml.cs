using Microsoft.Extensions.Hosting;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using CManager.Presentation.GuiApp.ViewModels;
using CManager.Infrastructure.Interfaces;
using CManager.Services;
using CManager.Infrastructure;

namespace CManager.Presentation.GuiApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<ICustomerRepository, CustomerRepository>();
                services.AddSingleton<CustomerService>();
                services.AddSingleton<IJsonFormatter, JsonFormatter>();

                services.AddSingleton<MainViewModels>();
                services.AddSingleton<GetCustomersViewModel>();
                services.AddTransient<AddCustomersViewModel>();

                services.AddSingleton<MainWindow>();

            })
            .Build();
    }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }
}
