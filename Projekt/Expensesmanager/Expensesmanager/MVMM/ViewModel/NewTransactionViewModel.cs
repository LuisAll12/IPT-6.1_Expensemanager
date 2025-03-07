using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.IO;
using System.Windows;
using System.Security.Cryptography;
using Expensesmanager.Core;
using Expensesmanager.ViewModel;

namespace Expensesmanager.MVMM.ViewModel
{
    internal class NewTransactionViewModel
    {
        private static int? accountID { get; set; }

        public bool RegisterNewTransaction(double amount, string date, string description, string category)
        {
            bool rntResult = false;

            // CategoryID
            int categoryID = GetCategoryIDbyName(category);

            // Set AccountID
            accountID = LoginViewModel.CurrentUserId;

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
                    string query = @"INSERT INTO Transactions (AccountID, Amount, Date, Description)
                                                       VALUES (@AccountID, @Amount, @Date, @Description)";

                    using (var command = new SqliteCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@AccountID", accountID);
                        //command.Parameters.AddWithValue("@CategoryID", categoryID);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@Description", description);

                        int rowsAffected = command.ExecuteNonQuery();
                        rntResult = rowsAffected > 0;
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

            return rntResult;
        }

        private int GetCategoryIDbyName(string category)
        {
            return 0;
        }
    }
}
