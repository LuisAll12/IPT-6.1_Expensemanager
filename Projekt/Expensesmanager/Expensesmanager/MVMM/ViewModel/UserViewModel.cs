
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
    private static int? accountID { get; set; }
    public ObservableCollection<UserViewModel> Users { get; set; } = new ObservableCollection<UserViewModel>();

    public void LoadUserData()
    {
      IsLoading = true;
      accountID = LoginViewModel.CurrentUserId;

      try
      {
        string query = @"
    SELECT FirstName, LastName, Email, Password, Income 
    FROM Account WHERE AccountID = @AccountId;";

        var parameters = new Dictionary<string, object>
    {
      { "@AccountId", accountID }
    };

        var result = DB_Services.Instance.ExecuteQuery(query, parameters);

        if (result.Rows.Count > 0)
        {
          DataRow row = result.Rows[0];
          // Nur ein User wird geladen
          var record = new UserViewModel
          {
            UserNameTag = row["FirstName"].ToString(),
            UserLastNameTag = row["LastName"].ToString(),
            UserEmailTag = row["Email"].ToString(),
            UserPasswordTag = row["Password"].ToString(),
            UserIncomeTag = row["Income"].ToString()
          };

          // Setze den User, anstatt die Liste zu füllen
          Users.Clear(); // Optional, um sicherzustellen, dass keine alten Daten bleiben
          Users.Add(record);  // Der eingeloggte Benutzer wird zur Liste hinzugefügt
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Fehler beim Laden", MessageBoxButton.OK, MessageBoxImage.Error);
      }
      finally
      {
        IsLoading = false;
      }
    }





    //  var dbServices = DB_Services.Instance;


    //  string query = @"SELECT FirstName, LastName, Email, Password, Income FROM Account WHERE AccountID = @AccountId";

    //  var parameters = new Dictionary<string, object>
    //  {
    //    { "@AccountId", userId }
    //  };

    //  var result = DB_Services.Instance.ExecuteQuery(query, parameters);

    //  if (result.Rows.Count > 0)
    //  {
    //    DataRow row = result.Rows[0];
    //    UserNameTag = row["FirstName"].ToString();
    //    UserLastNameTag = row["LastName"].ToString();
    //    UserEmailTag = row["Email"].ToString();
    //    UserPasswordTag = row["Password"].ToString();
    //    UserIncomeTag = row["Income"].ToString();
    //  }
    //  else
    //  {
    //    UserNameTag = "Nicht gefunden"; // Optionales Fallback
    //  }
    //}

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
  }
}
