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
            Loaded += HomeView_Loaded; 
        }
        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
            _homeViewModel.GetUser(); 
            GetSetUserData();
        }

        public void GetSetUserData()
        {

            string firstName = _homeViewModel.FirstName;
            string lastName = _homeViewModel.LastName;
            double monthlyIncome = _homeViewModel.MonthlyIncome;
            int RemainingDays = 9;

            Greet_TextBlock.Text = $"Hallo {firstName} {lastName}";
            IncomeTextBlock.Text = monthlyIncome.ToString();

            // Orange warning RemainingDaysTextBlock
            if (RemainingDays < 15) RemainingDaysTextBlock.Foreground = (Brush)new BrushConverter().ConvertFromString("#FFBD2E");
            // Red warning RemainingDaysTextBlock
            if (RemainingDays <= 10) RemainingDaysTextBlock.Foreground = (Brush)new BrushConverter().ConvertFromString("#FF5F56");
        }
    }
}

