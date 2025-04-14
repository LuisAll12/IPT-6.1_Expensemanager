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
            _homeViewModel.GetTotalExpenses();
            GetSetUserData();
        }

        public void GetSetUserData()
        {

            string firstName = _homeViewModel.FirstName;
            string lastName = _homeViewModel.LastName;
            string Expenses = _homeViewModel.Expenses;
            double monthlyIncome = _homeViewModel.MonthlyIncome;
            int RemainingDays = GetRemainingDays();

            Greet_TextBlock.Text = $"Hallo {firstName} {lastName}";
            IncomeTextBlock.Text = monthlyIncome.ToString();
            ExpensesTextBlock.Text = Expenses;
            RemainingDaysTextBlock.Text = RemainingDays.ToString();
            SetTBColores(Expenses, RemainingDays, monthlyIncome);

        }

        public void SetTBColores( string Expenses, int RemainingDays, double monthlyIncome)
        {
            // RemainingDays

            // Orange warning RemainingDaysTextBlock
                if (RemainingDays < 15) { 
                  RemainingDaysBorder.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#FFBD2E");
                  RemainingDaysBorder.BorderThickness = new Thickness(1);
                }

                // Red warning RemainingDaysTextBlock
                if (RemainingDays <= 10) {
                  RemainingDaysBorder.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#FF5F56");
                  RemainingDaysBorder.BorderThickness = new Thickness(1);
                }



            // Expenses

                double expeses = Double.Parse(Expenses);

                double TwentyPercentLess = monthlyIncome - (monthlyIncome / 100 * 20);
                double ThirtyPercentLess = monthlyIncome - (monthlyIncome / 100 * 30);

                // Orange warning ExpensesTextBlock
                if (expeses > ThirtyPercentLess) {
                  ExpensesBorder.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#FFBD2E");
                  ExpensesBorder.BorderThickness = new Thickness(1);
                }


                // Red warning ExpensesTextBlock
                if (expeses > TwentyPercentLess)
                {
                  ExpensesBorder.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#FF5F56");
                  ExpensesBorder.BorderThickness = new Thickness(1);
                }


           // Finish func SetTBColores
        }

    public int GetRemainingDays(){

          // Today
            DateTime Today = DateTime.Today;
          // LastDayOfMonth
            DateTime LastDayOfMonth = new DateTime(Today.Year, Today.Month, DateTime.DaysInMonth(Today.Year, Today.Month));


          // Return
            return (LastDayOfMonth - Today).Days;
        }

    }
}

