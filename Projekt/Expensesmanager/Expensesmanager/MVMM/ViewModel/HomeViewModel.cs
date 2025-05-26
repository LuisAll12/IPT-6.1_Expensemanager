using Expensesmanager.ViewModel;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expensesmanager.Database;

namespace Expensesmanager.MVMM.ViewModel
{
  class HomeViewModel
  {
    private int userId = LoginViewModel.CurrentUserId.Value;
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public double MonthlyIncome { get; private set; }
    public string Expenses { get; private set; }

    private readonly DB_Services _services = DB_Services.Instance;

    // Userdaten
    public void GetUser()
    {
      var parameters = new Dictionary<string, object>
            {
                { "@UserID", userId }
            };

      string query = @"SELECT FirstName, LastName, MonthlyIncome 
                             FROM Account 
                             WHERE AccountID = @UserID";

      DataTable dataTable = _services.ExecuteQuery(query, parameters);
      foreach (DataRow row in dataTable.Rows)
      {
        FirstName = row["FirstName"].ToString();
        LastName = row["LastName"].ToString();
        MonthlyIncome = Convert.ToDouble(row["MonthlyIncome"]);
      }
    }

    // Gesamtausgaben über Singleton
    public void GetTotalExpenses()
    {
      double expenses = 0.00;
      int currentYear = DateTime.Now.Year;
      int currentMonth = DateTime.Now.Month;

      string query = @"
                SELECT Amount 
                FROM Transactions 
                WHERE AccountID = @UserID 
                AND strftime('%Y', Date) = @Year 
                AND strftime('%m', Date) = @Month";

      var parameters = new Dictionary<string, object>
            {
                { "@UserID", userId },
                { "@Year", currentYear.ToString("D4") },
                { "@Month", currentMonth.ToString("D2") }
            };

      DataTable dataTable = _services.ExecuteQuery(query, parameters);

      foreach (DataRow row in dataTable.Rows)
      {
        expenses += Convert.ToDouble(row["Amount"]);
      }

      Expenses = expenses.ToString("F2");
    }
  }
}
