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


      userName.Text = firstName.ToString();

    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      _userViewModel.ChangeData();
    }

    public void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.LeftButton == MouseButtonState.Pressed)
      {
        // DragMove();  // Nur bei echten Fenstern (nicht UserControl)
      }
    }
    
  }
}
