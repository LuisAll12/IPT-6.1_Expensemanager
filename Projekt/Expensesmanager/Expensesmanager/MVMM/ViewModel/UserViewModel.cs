
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

namespace Expensesmanager.MVMM.ViewModel
{
  public class UserViewModel : INotifyPropertyChanged
  {
    private int userId = LoginViewModel.CurrentUserId.Value;

    private string _userNameTag;
    private string _userLastNameTag;
    private string _userEmailTag;
    private string _userPasswordTag;
    private string _userIncomeTag;

    public string UserNameTag
    {
      get => _userNameTag;
      set
      {
        _userNameTag = value;
        OnPropertyChanged(nameof(UserNameTag));
      }
    }

    public string UserLastNameTag
    {
      get => _userLastNameTag;
      set
      {
        _userLastNameTag = value;
        OnPropertyChanged(nameof(UserLastNameTag));
      }
    }

    public string UserEmailTag
    {
      get => _userEmailTag;
      set
      {
        _userEmailTag = value;
        OnPropertyChanged(nameof(UserEmailTag));
      }
    }

    public string UserPasswordTag
    {
      get => _userPasswordTag;
      set
      {
        _userPasswordTag = value;
        OnPropertyChanged(nameof(UserPasswordTag));
      }
    }

    public string UserIncomeTag
    {
      get => _userIncomeTag;
      set
      {
        _userIncomeTag = value;
        OnPropertyChanged(nameof(UserIncomeTag));
      }
    }

    public UserViewModel()
    {
      LoadUserData();
    }

    public void LoadUserData()
    {
      var dbServices = DB_Services.Instance;

      string query = "SELECT FirstName, LastName, Email, Password, Income FROM Users WHERE UserId = @UserId";

      var parameters = new Dictionary<string, object>
            {
                { "@UserId", userId }
            };

      DataTable result = dbServices.ExecuteQuery(query, parameters);

      if (result.Rows.Count > 0)
      {
        DataRow row = result.Rows[0];
        UserNameTag = row["FirstName"].ToString();
        UserLastNameTag = row["LastName"].ToString();
        UserEmailTag = row["Email"].ToString();
        UserPasswordTag = row["Password"].ToString();
        UserIncomeTag = row["Income"].ToString();
      }
      else
      {
        UserNameTag = "Nicht gefunden"; // Optionales Fallback
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
  }
}
