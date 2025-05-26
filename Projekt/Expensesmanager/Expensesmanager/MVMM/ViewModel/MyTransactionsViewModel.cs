using Expensesmanager.MVMM.View;
using Expensesmanager.ViewModel;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using static Expensesmanager.MVMM.View.MyCategoriesView;
using System.Xml.Linq;
using System.Security.Principal;
using System.Linq;
using Expensesmanager.Database;
using System.Data;

namespace Expensesmanager.MVMM.ViewModel
{
    internal class MyTransactionsViewModel : INotifyPropertyChanged
    {
        // Mainclass
        public MyTransactionsViewModel()
        {
            Records = new ObservableCollection<Record>();
            GetTransactions();

            EditCommand = new RelayCommand(EditRecord, CanEditRecord);
            DeleteCommand = new RelayCommand(DeleteRecord, CanDeleteRecord);
        }

        // Variables
        // Database
        private string connectionString = App.ConnectionString;
        private static int? accountID { get; set; }

        // Records
        public ObservableCollection<Record> Records { get; set; }

        // Selected Record
        private Record _selectedRecord;
        public Record SelectedRecord
        {
            get { return _selectedRecord; }
            set
            {
                _selectedRecord = value;
                OnPropertyChanged(nameof(SelectedRecord));
            }
        }

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

        // Commands
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        // PropertyChanged
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
        string query = @"
            SELECT t.Amount, t.Date, c.Name, t.TransactionID
            FROM Transactions t
            JOIN Account a ON t.AccountID = a.AccountID
            JOIN Category c ON t.CategoryID = c.CategoryID
            WHERE a.AccountID = @accountID;";

        // Parameter dictionary vorbereiten
        var parameters = new Dictionary<string, object>
        {
            { "@accountID", accountID }
        };

        // Query über Singleton ausführen
        var result = DB_Services.Instance.ExecuteQuery(query, parameters);

        // Records befüllen
        foreach (DataRow row in result.Rows)
        {
          var record = new Record
          {
            Amount = Convert.ToDouble(row["Amount"]),
            Date = Convert.ToDateTime(row["Date"]),
            Category = row["Name"].ToString(),
            TransactionID = Convert.ToInt32(row["TransactionID"])
          };

          Records.Add(record);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
      }

      // End Loading
      IsLoading = false;
    }


    private bool CanEditRecord(object parameter)
        {
            return SelectedRecord != null;
        }

        // Delete Record
        private void DeleteRecord(object parameter)
        {
            if (SelectedRecord != null)
            {
                // Löschen Sie den Datensatz aus der Datenbank
                DeleteRecordFromDatabase(SelectedRecord);
                Records.Remove(SelectedRecord);
            }
        }

        private bool CanDeleteRecord(object parameter)
        {
            return SelectedRecord != null;
        }

        private void EditRecord(object parameter)
        {
            var ownerWindow = parameter as Window;

            if (SelectedRecord != null)
            {
                var editViewModel = new EditTransactionViewModel
                {
                    Amount = SelectedRecord.Amount,
                    Date = SelectedRecord.Date,
                    Description = SelectedRecord.Description,
                    Category = SelectedRecord.Category,
                    TransactionID = SelectedRecord.TransactionID
                };

                try
                {
                    var editWindow = new EditTransactionView
                    {
                        DataContext = editViewModel
                    };

                    if (ownerWindow != null && ownerWindow != editWindow)
                    {
                        editWindow.Owner = ownerWindow.Owner;
                    }

                    bool? result = editWindow.ShowDialog();

                    if (result == true)
                    {
                        SelectedRecord.Amount = editViewModel.Amount;
                        SelectedRecord.Date = editViewModel.Date;
                        SelectedRecord.Description = editViewModel.Description;
                        SelectedRecord.Category = editViewModel.Category;

                        UpdateRecordInDatabase(SelectedRecord);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler beim Öffnen des Edit-Fensters: " + ex);
                }
            }
        }



          // Update Record in Database
          private void UpdateRecordInDatabase(Record record)
          {
            try
            {
              string query = @"UPDATE Transactions 
                               SET Amount = @amount, Description = @description, Date = @date, CategoryID = (SELECT CategoryID FROM Category WHERE Name = @category AND AccountID = @accountid)
                               WHERE TransactionID = @transactionid;";

              var parameters = new Dictionary<string, object>
              {
                  { "@amount", record.Amount },
                  { "@date", record.Date.ToString("yyyy-MM-dd") },
                  { "@category", record.Category },
                  { "@transactionid", record.TransactionID },
                  { "@accountid", accountID },
                  { "@description", record.Description }
              };

              DB_Services.Instance.ExecuteNonQuery(query, parameters);

              MessageBox.Show(
                  "Der Eintrag wurde erfolgreich geändert.",
                  "Erfolg",
                  MessageBoxButton.OK,
                  MessageBoxImage.Information
              );
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          }

    // Delete Record from Database
    private void DeleteRecordFromDatabase(Record record)
    {
      MessageBoxResult result = MessageBox.Show(
          "Sind Sie sicher, dass Sie diesen Eintrag löschen möchten?",
          "Bestätigung",
          MessageBoxButton.OKCancel,
          MessageBoxImage.Question
      );

      if (result == MessageBoxResult.OK)
      {
        try
        {
          string query = @"DELETE FROM Transactions WHERE TransactionID = @transactionid";

          var parameters = new Dictionary<string, object>
            {
                { "@transactionid", record.TransactionID }
            };

          DB_Services.Instance.ExecuteNonQuery(query, parameters);

          MessageBox.Show(
              "Der Eintrag wurde erfolgreich gelöscht.",
              "Erfolg",
              MessageBoxButton.OK,
              MessageBoxImage.Information
          );

          Records.Remove(record);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }
      }
      else
      {
        MessageBox.Show(
            "Der Löschvorgang wurde abgebrochen.",
            "Abgebrochen",
            MessageBoxButton.OK,
            MessageBoxImage.Information
        );
      }
    }

  }
  // Record Class
  public class Record : INotifyPropertyChanged
    {
        private double _amount;
        private string _description;
        private DateTime _date;
        private string _category;
        private int _transactionid;

        public int TransactionID
        {
            get { return _transactionid; }
            set
            {
                _transactionid = value;
                OnPropertyChanged(nameof(TransactionID));
            }
        }
        public double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // RelayCommand Class
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}