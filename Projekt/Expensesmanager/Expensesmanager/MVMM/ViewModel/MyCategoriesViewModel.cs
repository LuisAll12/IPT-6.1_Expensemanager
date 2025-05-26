using Expensesmanager.ViewModel;
using Expensesmanager.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using Expensesmanager.Core;
using static Expensesmanager.MVMM.View.MyCategoriesView;

namespace Expensesmanager.MVMM.ViewModel
{
  internal class MyCategoriesViewModel : INotifyPropertyChanged
  {
    private int userId = LoginViewModel.CurrentUserId ?? 0; // default 0 falls null
    private readonly DB_Services _services = DB_Services.Instance;

    public ObservableCollection<Category> Categories { get; set; }

    private bool _isLoading;
    public bool IsLoading
    {
      get => _isLoading;
      set
      {
        _isLoading = value;
        OnPropertyChanged(nameof(IsLoading));
      }
    }

    public MyCategoriesViewModel()
    {
      Categories = new ObservableCollection<Category>();
      GetCategories();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public void GetCategories()
    {
      if (userId == 0)
      {
        MessageBox.Show("Kein eingeloggter User gefunden!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
        return;
      }

      IsLoading = true;

      string query = @"
                SELECT c.Budget, c.Name, COALESCE(SUM(t.Amount), 0) AS SumTransactions
                FROM Category c
                LEFT JOIN Transactions t ON c.CategoryID = t.CategoryID
                WHERE c.AccountID = @UserID
                GROUP BY c.CategoryID, c.Budget, c.Name;
            ";

      var parameters = new Dictionary<string, object>
            {
                { "@UserID", userId }
            };

      try
      {
        Categories.Clear();

        DataTable dt = _services.ExecuteQuery(query, parameters);

        foreach (DataRow row in dt.Rows)
        {
          Categories.Add(new Category
          {
            Budget = Convert.ToDouble(row["Budget"]),
            Name = row["Name"].ToString(),
            SumTransactions = Convert.ToDouble(row["SumTransactions"])
          });
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Fehler beim Laden der Kategorien", MessageBoxButton.OK, MessageBoxImage.Error);
      }
      finally
      {
        IsLoading = false;
      }
    }
  }
}
