using Expensesmanager.ViewModel;
using System.Windows;

namespace Expensesmanager.View
{
    public partial class LoginView : Window
    {
        private LoginViewModel loginViewModel;

        public LoginView()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (loginViewModel.AuthenticateUser(username, password))
            {
                // Open the main window
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                // Close the login window
                this.Close();
            }
            else
            {
                // Show error message
                ErrorTextBlock.Visibility = Visibility.Visible;
            }
        }
    }
}
