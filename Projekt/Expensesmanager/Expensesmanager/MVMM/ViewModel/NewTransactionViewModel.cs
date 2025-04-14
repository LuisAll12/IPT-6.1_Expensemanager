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
    internal class NewTransactionViewModel
    {
        // Variables
        private static int? accountID { get; set; }
        private string connectionString = App.ConnectionString;

        // Functions

        // New Transaction
        public bool RegisterNewTransaction(double amount, string date, string description, string category)
        {
            bool rntResult = false;

            // CategoryID
            int categoryID = GetCategoryIDbyName(category);

            // Set AccountID
            accountID = LoginViewModel.CurrentUserId;

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Transactions (AccountID, CategoryID, Amount, Date, Description)
                                                       VALUES (@AccountID, @CategoryID, @Amount, @Date, @Description)";

                    using (var command = new SqliteCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@AccountID", accountID);
                        command.Parameters.AddWithValue("@CategoryID", categoryID);
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

        // Get CategoryID by Name
        private int GetCategoryIDbyName(string category)
        {
            int categoryId = -1; 

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                                    SELECT t.CategoryID
                                    FROM Category t
                                    JOIN Account a ON t.AccountID = a.AccountID
                                    JOIN Category c ON t.CategoryID = c.CategoryID
                                    WHERE a.AccountID = @accountID AND c.Name = @categoryname;
                                ";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@accountID", accountID);
                        command.Parameters.AddWithValue("@categoryname", category);

                        // Execute the query
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            categoryId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Error in SQL");
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
                MessageBox.Show(ex.Message, "Registrierungsfehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return categoryId;
        }

        // Account Category
        public List<string> GetAccountCategory()
        {
            List<string> categoryList = new List<string>();
            accountID = LoginViewModel.CurrentUserId;

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT Name FROM Category WHERE AccountID = @accountID";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@accountID", accountID); // Parameter setzen

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categoryList.Add(reader.GetString(0)); // Holt den Namen der Kategorie
                            }
                        }
                    }
                }

            }
            catch (SqliteException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "SQL Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            catch (Exception ex)
            {
                string errorMessage = $"Error: {ex.Message}\nType: {ex.GetType().Name}\nStack Trace: {ex.StackTrace}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\nInner Exception: {ex.InnerException.Message}";
                }
                MessageBox.Show(errorMessage, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return categoryList;
        }

    }
}
