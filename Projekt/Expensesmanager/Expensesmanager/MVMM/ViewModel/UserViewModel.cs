
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.IO;
using System.Windows;
using System.Security.Cryptography;
using Expensesmanager.Core;
using Expensesmanager.Database;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Expensesmanager.ViewModel;
using Expensesmanager.MVMM.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Expensesmanager.MVMM.ViewModel
{
  public class UserViewModel : INotifyPropertyChanged
  {
    public string UserNameTag { get; set; }
    public string UserLastNameTag { get; set; }
    public string UserEmailTag { get; set; }
    public string UserPasswordTag { get; set; }
    public string UserIncomeTag { get; set; }

    public UserViewModel()
    {
      LoadUserData();
    }

    //public void LoadUserData()
    //{
    //  var db = DB_Services.Instance;
    //private string connectionString = App.ConnectionString;

    private int userId = LoginViewModel.CurrentUserId.Value;


    //
    private readonly DB_Services _services = DB_Services.Instance;

    public void LoadUserData()
    {

      DataTable dataTable = new DataTable();
      var parameters = new Dictionary<string, object>
              {
                { "@UserID", userId }
              };
      string query = @"SELECT FirstName, LastName, Email, Password, MonthlyIncome FROM Account WHERE AccountID = @UserID";

      dataTable = _services.ExecuteQuery(query, parameters);
      foreach (DataRow row in dataTable.Rows)
      {
        UserNameTag = row["FirstName"].ToString();
        UserLastNameTag = row["LastName"].ToString();
        UserEmailTag = row["Email"].ToString();
        UserPasswordTag = row["Password"].ToString();
        UserIncomeTag = row["MonthlyIncome"].ToString();
      }
    }

    public void ChangeData()
    {
      try
      {
        if (userId == null)
        {
          MessageBox.Show("Fehler: Keine gültige User-ID.");
          return;
        }

        if (!decimal.TryParse(UserIncomeTag, out decimal income))
        {
          MessageBox.Show("Ungültiges Einkommen.");
          return;
        }

        var parameters = new Dictionary<string, object>
    {
        { "@UserID", userId },
        { "@FirstName", UserNameTag },
        { "@LastName", UserLastNameTag },
        { "@Email", UserEmailTag },
        { "@Password", UserPasswordTag },
        { "@MonthlyIncome", income }
    };

        string query = @"
      UPDATE Account 
      SET FirstName = @FirstName, 
          LastName = @LastName, 
          Email = @Email, 
          Password = @Password, 
          MonthlyIncome = @MonthlyIncome 
      WHERE AccountID = @UserID";

        _services.ExecuteNonQuery(query, parameters);

        MessageBox.Show("Daten erfolgreich gespeichert! ✅");
      }
      catch (Exception ex)
      {
        MessageBox.Show("Fehler beim Speichern: " + ex.Message);
      }
    }


    public event PropertyChangedEventHandler PropertyChanged;
  }


}
