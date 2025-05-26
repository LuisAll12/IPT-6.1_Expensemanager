using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using Expensesmanager.Database;
using Expensesmanager.ViewModel;

namespace Expensesmanager.MVMM.ViewModel
{
  public class NewCategoryViewModel
  {
    private static int? accountID => LoginViewModel.CurrentUserId;

    // Singleton Instance von DB_Services
    private readonly DB_Services _services = DB_Services.Instance;

    public bool NewCategory(string name, string description, double budget)
    {
      if (accountID == null)
      {
        MessageBox.Show("Kein Benutzer eingeloggt!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
        return false;
      }

      string query = @"
                INSERT INTO Category (Name, Description, AccountID, Budget) 
                VALUES (@Name, @Description, @AccountID, @Budget);
            ";

      var parameters = new Dictionary<string, object>
            {
                { "@AccountID", accountID },
                { "@Name", name },
                { "@Description", description },
                { "@Budget", budget }
            };

      try
      {
        _services.ExecuteNonQuery(query, parameters);
        return true;
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Fehler beim Speichern: {ex.Message}", "DB Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
        return false;
      }
    }
  }
}
