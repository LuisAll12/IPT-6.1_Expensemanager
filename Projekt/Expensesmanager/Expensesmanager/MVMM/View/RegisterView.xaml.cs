using Expensesmanager.MVMM.ViewModel;
using Expensesmanager.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;

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

            ErrorTextBlock.Text = string.Empty;
            bool checkinput = true;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastname))
            {
              checkinput = false;
              ErrorTextBlock.Text = "Füllen Sie alle Felder aus!";
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
              checkinput = false;
              ErrorTextBlock.Text = "Geben Sie eine gültige Email an!";
            }

            try
            {
              monthlyincome = double.Parse(MonthlyIncomeTextBox.Text);
            }
            catch (FormatException)
            {
              checkinput = false;
              ErrorTextBlock.Text = "Geben Sie ein gültiges Monatseinkommen an!";
            }

            if (checkinput)
            {
                try
                {
                    if (registerviewmodel.RegisterUser(email, password, firstname, lastname, monthlyincome))
                    {
                        // Registrierung erfolgreich
                        LoginView loginview = new LoginView();
                        loginview.Show();
                        this.Close();
                    }
                    else
                    {
                        ErrorTextBlock.Text = "Registrierung fehlgeschlagen!";
                        ErrorTextBlock.Visibility = Visibility.Visible;
                    }
                }
                catch (Exception ex)
                {
                    // Hier wird die genaue Fehlermeldung angezeigt
                    MessageBox.Show("Registrierung fehlgeschlagen: " + ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                ErrorTextBlock.Visibility = Visibility.Visible;
            }
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
        //private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this.WindowState == WindowState.Maximized)
        //    {
        //        this.WindowState = WindowState.Normal;
        //    }
        //    else
        //    {
        //        this.WindowState = WindowState.Maximized;
        //    }
        //}

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
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove(); // Verschiebt das Fenster, wenn die linke Maustaste gedrückt wird
            }
        }

    }
}
