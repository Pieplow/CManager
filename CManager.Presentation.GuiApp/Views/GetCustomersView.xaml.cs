using CManager.Core.Models;
using CManager.Infrastructure.Interfaces;
using CManager.Presentation.GuiApp.ViewModels;
using CManager.Services;
using System.Windows;
using System.Windows.Controls;

namespace CManager.Presentation.GuiApp.Views
{
    /// <summary>
    /// Interaction logic for GetCustomersView.xaml
    /// </summary>
    public partial class GetCustomersView : UserControl
    {
        public GetCustomersView()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Customer customer)
            {
                if (DataContext is GetCustomersViewModel viewModel)
                {
                    viewModel.UpdateCustomer(customer);
                }
                MessageBox.Show($"Customer {customer.FirstName} updated!");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Customer customer)
            {
                if (DataContext is GetCustomersViewModel viewModel)
                {
                    viewModel.CustomerList?.Remove(customer);
                }
            }
        }
    }
}
