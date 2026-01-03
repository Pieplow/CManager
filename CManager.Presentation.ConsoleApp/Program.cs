
using CManager.Core.Interfaces;
using CManager.Infrastructure;
using CManager.Presentation.ConsoleApp;
using CManager.Services;


var repo = new CustomerRepository();
var service = new CManager.Services.CustomerService(repo);


var menu = new MenuController(service);
menu.ShowMainMenu();
