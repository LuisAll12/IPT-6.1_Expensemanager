using Expensesmanager.Core;
using Expensesmanager.Database;
using Expensesmanager.MVMM.ViewModel;
using Expensesmanager.ViewModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Expensesmanager.MVMM.View
{
  /// <summary>
  /// Interaktionslogik für UserView.xaml
  /// </summary>
  public partial class UserView : UserControl, INotifyPropertyChanged
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
        OnPropertyChanged(nameof(UserLastNameTag));  // Benachrichtige über die Änderung
      }
    }

    public string UserEmailTag
    {
      get => _userEmailTag;
      set
      {
        _userEmailTag = value;
        OnPropertyChanged(nameof(UserEmailTag));  // Benachrichtige über die Änderung
      }
    }

    public string UserPasswordTag
    {
      get => _userPasswordTag;
      set
      {
        _userPasswordTag = value;
        OnPropertyChanged(nameof(UserPasswordTag));  // Benachrichtige über die Änderung
      }
    }

    public string UserIncomeTag
    {
      get => _userIncomeTag;
      set
      {
        _userIncomeTag = value;
        OnPropertyChanged(nameof(UserIncomeTag));  // Benachrichtige über die Änderung
      }
    }

    public UserView()
    {
      this.DataContext = new UserViewModel();

      InitializeComponent();
      DataContext = this;  // Setze das DataContext auf das UserControl selbst

      var dbServices = DB_Services.Instance;


      string query = "SELECT UserName FROM Users WHERE UserId = @UserId";

      // Parameter für die SQL-Abfrage
      var parameters = new Dictionary<string, object>
        {
            { "@UserId", userId }
        };

      // ExecuteQuery aufrufen, um das Ergebnis zu holen
      DataTable result = dbServices.ExecuteQuery(query, parameters);

      foreach (DataRow row in result.Rows)
      {
        UserNameTag = row["FirstName"].ToString();
        OnPropertyChanged(nameof(UserNameTag));

      }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    public void getUserName()
    {
      var dbServices = DB_Services.Instance;


      string query = @"SELECT UserName FROM Users WHERE UserId = @UserId;";

      
      // Parameter für die SQL-Abfrage
      var parameters = new Dictionary<string, object>
        {
            { "@UserId", userId }
        };

      // ExecuteQuery aufrufen, um das Ergebnis zu holen
      DataTable result = dbServices.ExecuteQuery(query, parameters);

      foreach (DataRow row in result.Rows)
      {
        UserNameTag = row["FirstName"].ToString();
        OnPropertyChanged(nameof(UserNameTag));

      }
    }

    protected void OnPropertyChanged(string name)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    private void change_userName(object sender, TextChangedEventArgs e)
    {
      
    }
  

  private void change_userLastName(object sender, TextChangedEventArgs e)
    {

    }




    private void change_userEmail(object sender, TextChangedEventArgs e)
    {

    }

    private void change_userPassword(object sender, TextChangedEventArgs e)
    {

    }


    private void change_userIncome(object sender, TextChangedEventArgs e)
    {

    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
      //this.WindowState = WindowState.Minimized;
    }

    

    // Close Button
    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
    
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.LeftButton == MouseButtonState.Pressed)
      {
        //this.DragMove(); // Verschiebt das Fenster, wenn die linke Maustaste gedrückt wird
      }
    }
  }
}
