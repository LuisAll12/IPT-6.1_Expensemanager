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


namespace Expensesmanager.MVMM.ViewModel
{
    internal class MyTransactionsViewModel : INotifyPropertyChanged
    {        
        // Mainclass
        public MyTransactionsViewModel()
        {
            Records = new ObservableCollection<Record>();
            GetTransactions();
        }

        // Variables
            // Database
            private string connectionString = App.ConnectionString;
            private static int? accountID { get; set; }

            // Records
            public ObservableCollection<Record> Records { get; set; }

            // Loader
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
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        // Functions
        private void GetTransactions()
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

                  string query = @"SELECT t.Amount, t.Date, c.Name
                                   FROM Transactions t
                                   JOIN Account a ON t.AccountID = a.AccountID
                                   JOIN Category c ON t.CategoryID = c.CategoryID
                                   WHERE a.AccountID = @accountID;";

                  using (var command = new SqliteCommand(query, connection))
                  {
                    command.Parameters.AddWithValue("@accountID", accountID);

                    using (var reader = command.ExecuteReader())
                    {
                      while (reader.Read())
                      {
                          var record = new Record
                          {
                              Amount = reader.GetDouble(0),
                              Date = DateTime.Parse(reader.GetString(1)),
                              Category = reader.GetString(2)
                          };
                          Records.Add(record);
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
