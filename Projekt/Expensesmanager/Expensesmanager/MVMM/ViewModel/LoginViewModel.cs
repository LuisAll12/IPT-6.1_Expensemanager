using System.Windows;

namespace Expensesmanager.ViewModel
{
    public class LoginViewModel
    {
        public bool AuthenticateUser(string email, string password)
        {
            // Mock authentication logic (replace with actual authentication logic later)
            if (email == "admin" && password == "password")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
