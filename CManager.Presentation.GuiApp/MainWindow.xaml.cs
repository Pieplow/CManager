using CManager.Presentation.GuiApp.ViewModels;
using System.Windows;


namespace CManager.Presentation.GuiApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly MainViewModels _viewModel;

        public MainWindow(MainViewModels viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonShowUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleteUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}