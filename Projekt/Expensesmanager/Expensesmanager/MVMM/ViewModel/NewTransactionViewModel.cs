using Expensesmanager.ViewModel;
using Expensesmanager.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace Expensesmanager.MVMM.ViewModel
{
  internal class NewTransactionViewModel
  {
    private static int? accountID => LoginViewModel.CurrentUserId;
    private readonly DB_Services _services = DB_Services.Instance; 

    public bool RegisterNewTransaction(double amount, string date, string description, string category)
    {
      bool rntResult = false;

      int categoryID = GetCategoryIDbyName(category);

      if (accountID == null)
      {
        MessageBox.Show("Kein Benutzer eingeloggt!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
        return false;
      }

      string query = @"
                INSERT INTO Transactions (AccountID, CategoryID, Amount, Date, Description)
                VALUES (@AccountID, @CategoryID, @Amount, @Date, @Description);
            ";

      var parameters = new Dictionary<string, object>
            {
                { "@AccountID", accountID },
                { "@CategoryID", categoryID },
                { "@Amount", amount },
                { "@Date", date },
                { "@Description", description }
            };

      try
      {
        _services.ExecuteNonQuery(query, parameters);
        rntResult = true;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Fehler beim Speichern der Transaktion", MessageBoxButton.OK, MessageBoxImage.Error);
      }

      return rntResult;
    }

    private int GetCategoryIDbyName(string category)
    {
      if (accountID == null)
      {
        MessageBox.Show("Kein Benutzer eingeloggt!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
        return -1;
      }

      string query = @"
                SELECT CategoryID 
                FROM Category 
                WHERE AccountID = @AccountID AND Name = @CategoryName;
            ";

      var parameters = new Dictionary<string, object>
            {
                { "@AccountID", accountID },
                { "@CategoryName", category }
            };

      try
      {
        DataTable dt = _services.ExecuteQuery(query, parameters);
        if (dt.Rows.Count > 0)
        {
          return Convert.ToInt32(dt.Rows[0]["CategoryID"]);
        }
        else
        {
          MessageBox.Show("Kategorie nicht gefunden.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
          return -1;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Fehler beim Abrufen der Kategorie", MessageBoxButton.OK, MessageBoxImage.Error);
        return -1;
      }
    }

    public List<string> GetAccountCategory()
    {
      var categoryList = new List<string>();

      if (accountID == null)
      {
        MessageBox.Show("Kein Benutzer eingeloggt!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
        return categoryList;
      }

      string query = "SELECT Name FROM Category WHERE AccountID = @AccountID";

      var parameters = new Dictionary<string, object>
            {
                { "@AccountID", accountID }
            };

      try
      {
        DataTable dt = _services.ExecuteQuery(query, parameters);
        foreach (DataRow row in dt.Rows)
        {
          categoryList.Add(row["Name"].ToString());
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Fehler beim Laden der Kategorien", MessageBoxButton.OK, MessageBoxImage.Error);
      }

      return categoryList;
    }
  }
}
