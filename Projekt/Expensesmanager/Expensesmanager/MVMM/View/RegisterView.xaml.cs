using Expensesmanager.MVMM.ViewModel;
using Expensesmanager.ViewModel;
using System;
using System.Windows;

namespace Expensesmanager.View
{
    public partial class RegisterView : Window
    {
        private RegisterViewModel registerviewmodel;
        public RegisterView()
        {
            InitializeComponent();
            registerviewmodel = new RegisterViewModel();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Visibility = Visibility.Collapsed;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string firstname = FirstNameTextBox.Text;
            string lastname = LastNameTextBox.Text;
            double monthlyincome = 0.0;

            bool checkinput = true;
            try
            {
              ErrorTextBlock.Text = string.Empty;

                monthlyincome = double.Parse(MonthlyIncomeTextBox.Text);
                if (double.IsNaN(monthlyincome))
                {
                    checkinput = false;
                    ErrorTextBlock.Text = "Geben Sie ein gültiges Monatseinkommen an!";
                    ErrorTextBlock.Visibility = Visibility.Visible;
                }
                else
                {
                    if (email == "" || password == "" || firstname == "" || lastname == "")
                    {
                      checkinput = false;

                        ErrorTextBlock.Text = "Füllen Sie alle Felder aus!";
                        ErrorTextBlock.Visibility = Visibility.Visible;
                    }
                    if (!email.Contains("@"))
                    {
                        checkinput = false;
                        ErrorTextBlock.Text = "Geben Sie eine gültige Email an!";
                        ErrorTextBlock.Visibility = Visibility.Visible;
                     }
                    if (!email.Contains("."))
                    {
                      checkinput = false;
                      ErrorTextBlock.Text = "Geben Sie eine gültige Email an!";
                      ErrorTextBlock.Visibility = Visibility.Visible;
                    }

                        else
                        {
                          if (checkinput == true) 
                          {
                        // Send RegisterInfos
                        if (registerviewmodel.RegisterUser(email, password, firstname, lastname, monthlyincome))
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
                          ErrorTextBlock.Text = "Registrierung fehlgeschlagen!";
                          ErrorTextBlock.Visibility = Visibility.Visible;
                        }
                      }
                        
                    }
                }
            }
            catch (FormatException)
            {
                ErrorTextBlock.Text = "Geben Sie ein gültiges Monatseinkommen an!";
                ErrorTextBlock.Visibility = Visibility.Visible;
            }
            // Check Field 
        }

        // Reset All Fields
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            EmailTextBox.Text = string.Empty;
            PasswordBox.Password = string.Empty;
        }

        // Minimize
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
        private void AccountAvailable_Click(object sender, RoutedEventArgs e)
        {
            // Open the login window
            LoginView loginWindow = new LoginView();
            loginWindow.Show();

            // Close the register window
            this.Close();
        }

    private void LastNameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {

        }

    private void MonthlyIncomeTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {

    }
  }
}
