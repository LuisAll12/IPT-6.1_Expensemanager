using Expensesmanager.ViewModel;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
 using System.Text;
using System.Threading.Tasks;
using Expensesmanager.Database;
using System.Data;
using System.Security.Cryptography;

namespace Expensesmanager.MVMM.ViewModel
{
    class HomeViewModel
    {
          // Variables
          private string connectionString = App.ConnectionString;
          private int userId = LoginViewModel.CurrentUserId.Value;
          public string FirstName { get; private set; }
          public string LastName { get; private set; }
          public double MonthlyIncome { get; private set; }
          public string Expenses { get; private set; }

        private readonly DB_Services _services = DB_Services.Instance;

        //private readonly DB_Services _services = new DB_Services();
        // Functions
        // User Info
        public void GetUser()
          {

              DataTable dataTable = new DataTable();
              var parameters = new Dictionary<string, object>
              {
                { "@UserID", userId }
              };
              string query = @"SELECT FirstName, LastName, MonthlyIncome FROM Account WHERE AccountID = @UserID";
              dataTable = _services.ExecuteQuery(query, parameters);
              foreach (DataRow row in dataTable.Rows)
              {
                FirstName = row["FirstName"].ToString();
                LastName = row["LastName"].ToString();
                MonthlyIncome = Convert.ToDouble(row["MonthlyIncome"]);
              }
          }

        // Total Expenses
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
