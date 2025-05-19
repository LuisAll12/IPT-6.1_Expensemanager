using Expensesmanager.Core;
using Expensesmanager.Database;
using Expensesmanager.MVMM.ViewModel;
using Expensesmanager.ViewModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Expensesmanager.MVMM.View
{

  public partial class UserView : UserControl
  {

    private UserViewModel _userViewModel;

    public UserView()
    {
      InitializeComponent();
      _userViewModel = new UserViewModel();
      Loaded += HomeView_Loaded;
    }
    private void HomeView_Loaded(object sender, RoutedEventArgs e)
    {
      _userViewModel.LoadUserData();
      
      GetSetUserData();
    }

    public void GetSetUserData()
    {

      string firstName = _userViewModel.UserNameTag;
      string lastName = _userViewModel.UserLastNameTag;
      string email = _userViewModel.UserEmailTag;
      string password = _userViewModel.UserPasswordTag;
      string einkommen = _userViewModel.UserIncomeTag;


      //Greet_TextBlock.Text = $"Hallo {firstName} {lastName}";
      userName.Text = firstName.ToString();
      //ExpensesTextBlock.Text = Expenses;
      //RemainingDaysTextBlock.Text = RemainingDays.ToString();
      //SetTBColores(Expenses, RemainingDays, monthlyIncome);

    }
    //public partial class UserView : UserControl, INotifyPropertyChanged
    //{
    //  private int userId = LoginViewModel.CurrentUserId.Value;

    //  private string _userNameTag;
    //  private string _userLastNameTag;
    //  private string _userEmailTag;
    //  private string _userPasswordTag;
    //  private string _userIncomeTag;

    //  public string UserNameTag
    //  {
    //    get => _userNameTag;
    //    set
    //    {
    //      _userNameTag = value;
    //      OnPropertyChanged(nameof(UserNameTag));
    //    }
    //  }

    //  public string UserLastNameTag
    //  {
    //    get => _userLastNameTag;
    //    set
    //    {
    //      _userLastNameTag = value;
    //      OnPropertyChanged(nameof(UserLastNameTag));
    //    }
    //  }

    //  public string UserEmailTag
    //  {
    //    get => _userEmailTag;
    //    set
    //    {
    //      _userEmailTag = value;
    //      OnPropertyChanged(nameof(UserEmailTag));
    //    }
    //  }

    //  public string UserPasswordTag
    //  {
    //    get => _userPasswordTag;
    //    set
    //    {
    //      _userPasswordTag = value;
    //      OnPropertyChanged(nameof(UserPasswordTag));
    //    }
    //  }

    //  public string UserIncomeTag
    //  {
    //    get => _userIncomeTag;
    //    set
    //    {
    //      _userIncomeTag = value;
    //      OnPropertyChanged(nameof(UserIncomeTag));
    //    }
    //  }

    //  public UserView()
    //  {
    //    InitializeComponent();
    //    DataContext = this;
    //    LoadUserData();
    //  }



    //  public event PropertyChangedEventHandler PropertyChanged;
    //  protected void OnPropertyChanged(string name)
    //  {
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    //  }

    //  // PUBLIC Handler für Events aus XAML
    //  public void change_userName(object sender, TextChangedEventArgs e)
    //  {
    //    UserNameTag = (sender as TextBox)?.Text;
    //  }

    //  public void change_userLastName(object sender, TextChangedEventArgs e)
    //  {
    //    UserLastNameTag = (sender as TextBox)?.Text;
    //  }

    //  public void change_userEmail(object sender, TextChangedEventArgs e)
    //  {
    //    UserEmailTag = (sender as TextBox)?.Text;
    //  }

    //  public void change_userPassword(object sender, TextChangedEventArgs e)
    //  {
    //    UserPasswordTag = (sender as TextBox)?.Text;
    //  }

    //  public void change_userIncome(object sender, TextChangedEventArgs e)
    //  {
    //    UserIncomeTag = (sender as TextBox)?.Text;
    //  }

    //  public void CloseButton_Click(object sender, RoutedEventArgs e)
    //  {
    //    Application.Current.Shutdown();
    //  }

    public void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.LeftButton == MouseButtonState.Pressed)
      {
        // DragMove();  // Nur bei echten Fenstern (nicht UserControl)
      }
    }
    //}
  }
}
