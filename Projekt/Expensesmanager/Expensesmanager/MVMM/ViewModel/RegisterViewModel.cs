﻿using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.IO;
using System.Windows;
using System.Security.Cryptography;
using Expensesmanager.Core;

namespace Expensesmanager.MVMM.ViewModel
{
  internal class RegisterViewModel
  {
    // Variables
    private string connectionString = App.ConnectionString;

    // Functions
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

      try
      {
        using (var connection = new SqliteConnection(connectionString))
        {
          connection.Open();
          string query = @"INSERT INTO Account (Email, Password, FirstName, LastName, MonthlyIncome)
                           VALUES (@Email, @Password, @FirstName, @LastName, @MonthlyIncome)";
          using (var command = new SqliteCommand(query, connection))
          {
            // Hash the password
            string hashedPassword = PasswordHasher.HashPassword(password);

            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", hashedPassword);
            command.Parameters.AddWithValue("@FirstName", firstname);
            command.Parameters.AddWithValue("@LastName", lastname);
            command.Parameters.AddWithValue("@MonthlyIncome", monthlyincome);

            int rowsAffected = command.ExecuteNonQuery();
            registerResult = rowsAffected > 0;
          }
        }
      }
      catch (SqliteException sqlEx)
      {
        MessageBox.Show(sqlEx.Message, "SQL Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Registrierungsfehler", MessageBoxButton.OK, MessageBoxImage.Error);
      }

      return registerResult;
    }
  }
}
