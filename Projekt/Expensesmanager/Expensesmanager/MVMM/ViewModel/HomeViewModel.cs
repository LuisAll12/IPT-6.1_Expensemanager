using Expensesmanager.Database;
using Expensesmanager.ViewModel;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Expensesmanager.MVMM.ViewModel
{
  class HomeViewModel
  {
    private int userId = LoginViewModel.CurrentUserId.Value;
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public double MonthlyIncome { get; private set; }
    public string Expenses { get; private set; }

    public SeriesCollection LineSeriesCollection { get; private set; }
    public List<string> DateLabels { get; private set; }

    private readonly DB_Services _services = DB_Services.Instance;

    public void GetUser()
    {
      var parameters = new Dictionary<string, object> { { "@UserID", userId } };
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

    public void LoadTransactionChartData()
    {
      string query = @"
                SELECT Date, Amount 
                FROM Transactions 
                WHERE AccountID = @UserID";

      var parameters = new Dictionary<string, object> { { "@UserID", userId } };

      DataTable dataTable = _services.ExecuteQuery(query, parameters);

      var grouped = dataTable.AsEnumerable()
          .Select(row => new
          {
            Date = Convert.ToDateTime(row["Date"]),
            Amount = Convert.ToDouble(row["Amount"])
          })
          .GroupBy(x => x.Date.ToString("yyyy-MM"))
          .OrderBy(g => g.Key)
          .Select(g => new
          {
            Month = g.Key,
            TotalAmount = g.Sum(x => x.Amount)
          })
          .ToList();

      LineSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Transaktionen",
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,
                    Values = new ChartValues<double>(grouped.Select(g => g.TotalAmount))
                }
            };

      DateLabels = grouped.Select(g => g.Month).ToList();
    }
  }
}
