using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.IO;
using System.Windows;
using System.Security.Cryptography;
using Expensesmanager.Core;
using Expensesmanager.ViewModel;
using System.Windows.Documents;
using System.Collections.Generic;

namespace Expensesmanager.MVMM.ViewModel
{
  internal class NewCategoryViewModel
  {
        // Variables
        private string connectionString = App.ConnectionString;
        private static int? accountID { get; set; }

        // Functions
        public bool NewCategory(string name, string description, double budget)
        {
            bool res = false;

            accountID = LoginViewModel.CurrentUserId;

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Category (Name, Description, AccountID, Budget) 
                                    VALUES (@Name, @Description, @AccountID, @Budget);";

                    using (var command = new SqliteCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@AccountID", accountID);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@Budget", budget);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0) { res = true; }
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

            return res;
        }
    }
}
