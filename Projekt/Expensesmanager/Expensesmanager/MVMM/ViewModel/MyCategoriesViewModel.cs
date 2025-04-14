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
using Expensesmanager.MVMM.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using static Expensesmanager.MVMM.View.MyCategoriesView;


namespace Expensesmanager.MVMM.ViewModel
{
    internal class MyCategoriesViewModel : INotifyPropertyChanged
    {
        // MainClass
        public MyCategoriesViewModel()
        {
            Categories = new ObservableCollection<Category>();
            GetCategories();
        }

        // Variables
            // Database
            private string connectionString = App.ConnectionString;
            private static int? accountID { get; set; }
            
            // Categories Collection
            public ObservableCollection<Category> Categories { get; set; }

            // Loader
            public event PropertyChangedEventHandler PropertyChanged;
            private bool _isLoading;
            public bool IsLoading
            {
                get { return _isLoading; }
                set
                {
                    _isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Functions
        private void GetCategories()
        {
            // Start Loading
            IsLoading = true;
            // Set AccountID
            accountID = LoginViewModel.CurrentUserId;


            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT c.Budget, c.Name, COALESCE(SUM(t.Amount), 0) AS SumTransactions
                                    FROM Category c
                                    LEFT JOIN Transactions t ON c.CategoryID = t.CategoryID
                                    WHERE c.AccountID = @accountID
                                    GROUP BY c.CategoryID, c.Budget, c.Name;";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@accountID", accountID);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var record = new Category
                                {
                                    Budget = reader.GetDouble(0),
                                    Name = reader.GetString(1),
                                    SumTransactions = reader.GetDouble(2)
                                };
                                Categories.Add(record);
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
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // End Loading
            IsLoading = false;
        }
    }
}
