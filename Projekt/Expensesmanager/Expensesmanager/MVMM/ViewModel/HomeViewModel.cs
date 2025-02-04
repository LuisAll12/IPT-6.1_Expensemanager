using Expensesmanager.ViewModel;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensesmanager.MVMM.ViewModel
{
    class HomeViewModel
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public double MonthlyIncome { get; private set; }
          public void GetUser()
          {

              int userId = LoginViewModel.CurrentUserId.Value;

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

    }
}
