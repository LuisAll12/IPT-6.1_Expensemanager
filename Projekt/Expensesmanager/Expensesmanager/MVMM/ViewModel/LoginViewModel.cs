using Microsoft.Data.Sqlite;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows;
using Expensesmanager.Core;
using System.Security.Principal;
using System.Windows.Controls.Primitives;

namespace Expensesmanager.ViewModel
{
  public class LoginViewModel
  {
    private static int? currentUserId;

    public static int? CurrentUserId { get => currentUserId; }

    public bool AuthenticateUser(string email, string password)
    {
      bool LoginResult = false;

      //Databasepath
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
          string query = @"SELECT AccountID, Password FROM Account WHERE Email = @Email";
          using (var command = new SqliteCommand(query, connection))
          {
            command.Parameters.AddWithValue("@Email", email);

            using (var reader = command.ExecuteReader())
            {
              if (reader.Read())
              {
                string StoredHash = reader.GetString(1);
                int userID = reader.GetInt32(0);

                if (PasswordHasher.VerifyPassword(password, StoredHash))
                {
                  currentUserId = userID;
                  LoginResult = true;
                }
              }
            }
          }
        }
      }
      catch (SqliteException sqlEx)
      {

        MessageBox.Show(sqlEx.Message, "SQL Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.Message, "Login Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
      }

      // Return Result
      return LoginResult;
    }
    public static void Logout() 
    {
      currentUserId = null;
    }
  }
}



