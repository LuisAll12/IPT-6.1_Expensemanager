using Expensesmanager.ViewModel;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Expensesmanager.MVMM.ViewModel
{
    class HomeViewModel
    {
        private string connectionString = App.ConnectionString;

        private int userId = LoginViewModel.CurrentUserId.Value;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public double MonthlyIncome { get; private set; }
        public string Expenses { get; private set; }
          public void GetUser()
          {

              string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
              string dbPath = System.IO.Path.Combine(baseDirectory, "Database", "ExpensesManagerDB.db");
              string connectionString = $"Data Source={dbPath}";
              string query = @"SELECT FirstName, LastName, MonthlyIncome FROM Account WHERE AccountID = @UserID";

              //Get Account Data
              using (var connection = new SqliteConnection(connectionString))
              {
                  connection.Open();
                  using (var command = new SqliteCommand(query, connection))
                  {
                      command.Parameters.AddWithValue("@UserID", userId);

                      using (var reader = command.ExecuteReader())
                      {
                          if (reader.Read())
                          {
                              FirstName = reader.GetString(0);
                              LastName = reader.GetString(1);
                              MonthlyIncome = reader.GetDouble(2);
                          }
                      }
                  }
              }
          }

        public void GetTotalExpenses()
        {
            double expenses = 0.00;


            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;


            // Get all Transactions
            string query = @"SELECT Amount FROM Transactions WHERE AccountID = @UserID AND strftime('%Y', Date) = @Year AND strftime('%m', Date) = @Month";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqliteCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@Year", currentYear.ToString("D4"));
                    command.Parameters.AddWithValue("@Month", currentMonth.ToString("D2"));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            expenses += reader.GetDouble(0);
                        }
                    }
                }
            }

            // Return
            Expenses = expenses.ToString();
        }

    }
}
