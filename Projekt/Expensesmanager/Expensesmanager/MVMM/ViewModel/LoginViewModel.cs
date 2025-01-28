using System.Windows;

namespace Expensesmanager.ViewModel
{
    public class LoginViewModel
    {
        public bool AuthenticateUser(string username, string password)
        {
            // Mock authentication logic (replace with actual authentication logic later)
            if (username == "admin" && password == "password")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
