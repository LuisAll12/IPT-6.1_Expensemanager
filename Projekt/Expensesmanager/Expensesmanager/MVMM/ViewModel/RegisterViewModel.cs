using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.IO;
using System.Windows;

namespace Expensesmanager.MVMM.ViewModel
{
  internal class RegisterViewModel
  {
    public bool RegisterUser(string email, string password, string firstname, string lastname, double monthlyincome)
    {
      bool registerResult = false;

      // Validate input lengths
      if (email.Length > 255)
        throw new ArgumentException("Email must be 255 characters or less.");
      if (password.Length > 255)
        throw new ArgumentException("Password must be 255 characters or less.");
      if (firstname.Length > 50)
        throw new ArgumentException("First name must be 100 characters or less.");
      if (lastname.Length > 50)
        throw new ArgumentException("Last name must be 100 characters or less.");

      // Resolve the database path
      string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
      string dbPath = System.IO.Path.Combine(baseDirectory, "Database", "ExpensesManagerDB.db");
      string connectionString = $"Data Source={dbPath}";

      if (!System.IO.File.Exists(dbPath))
      {
        throw new FileNotFoundException("Database file not found.", dbPath);
      }
      try
      {
        using (var connection = new SqliteConnection(connectionString))
        {
          connection.Open();
          string query = @"INSERT INTO Account (Email, Password, FirstName, LastName, MonthlyIncome)
                           VALUES (@Email, @Password, @FirstName, @LastName, @MonthlyIncome)";
          using (var command = new SqliteCommand(query, connection))
          {
            // Hash the password before storing it
            /*tring hashedPassword = HashPassword(password);*/

            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@FirstName", firstname);
            command.Parameters.AddWithValue("@LastName", lastname);
            command.Parameters.AddWithValue("@MonthlyIncome", monthlyincome);

            int rowsAffected = command.ExecuteNonQuery();
            registerResult = rowsAffected > 0;
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Registrierungsfehler", MessageBoxButton.OK, MessageBoxImage.Error);
      }

      return registerResult;
    }
  }
}
