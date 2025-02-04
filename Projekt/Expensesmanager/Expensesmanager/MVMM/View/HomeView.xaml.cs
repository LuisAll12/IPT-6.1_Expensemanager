using Expensesmanager.MVMM.ViewModel;
using Expensesmanager.ViewModel;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Expensesmanager.MVMM.View
{
    /// <summary>
    /// Interaktionslogik für HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private HomeViewModel _homeViewModel;

        public HomeView()
        {
            InitializeComponent();
            _homeViewModel = new HomeViewModel();
            _homeViewModel.GetUser();  
            GetSetUserData(); 
        }

        public void GetSetUserData()
        {

            string firstName = _homeViewModel.FirstName;
            string lastName = _homeViewModel.LastName;
            double monthlyIncome = _homeViewModel.MonthlyIncome;

            Greet_TextBlock.Text = $"Hallo {firstName} {lastName}";
            IncomeTextBlock.Text = monthlyIncome.ToString();
    }
  }
}
