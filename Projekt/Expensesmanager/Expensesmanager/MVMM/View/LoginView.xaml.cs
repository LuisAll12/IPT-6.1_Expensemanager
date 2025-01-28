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
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (loginViewModel.AuthenticateUser(email, password))
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
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            EmailTextBox.Text = string.Empty;
            PasswordBox.Password = string.Empty;
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // Maximize/Restore Button
        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        // Close Button
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ShowRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Show Register Field
        }

        private void NoAccountAvailable_Click(object sender, RoutedEventArgs e)
        {
            // Open the register window
            RegisterView registerWindow = new RegisterView();
            registerWindow.Show();

            // Close the login window
            this.Close();
        }
    }
}
