using CManager.Infrastructure;
using CManager.Infrastructure.Interfaces;
using CManager.Presentation.ConsoleApp;
using CManager.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = Host.CreateApplicationBuilder();

builder.Services.AddSingleton<MenuController>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<IJsonFormatter, JsonFormatter>();
builder.Services.AddSingleton<IViewModel, ViewModel>();

using var host = builder.Build();

var menu = host.Services.GetRequiredService<MenuController>();
menu.ShowMainMenu();
