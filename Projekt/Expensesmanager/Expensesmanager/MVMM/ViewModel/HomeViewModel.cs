using Expensesmanager.Database;
using Expensesmanager.ViewModel;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Expensesmanager.MVMM.ViewModel
{
    class HomeViewModel : INotifyPropertyChanged
    {
        private int userId = LoginViewModel.CurrentUserId.Value;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public double MonthlyIncome { get; private set; }
        public string Expenses { get; private set; }

        private SeriesCollection _lineSeriesCollection;
        private List<string> _dateLabels;

        public SeriesCollection LineSeriesCollection
        {
            get => _lineSeriesCollection;
            set
            {
                _lineSeriesCollection = value;
                OnPropertyChanged();
            }
        }

        public List<string> DateLabels
        {
            get => _dateLabels;
            set
            {
                _dateLabels = value;
                OnPropertyChanged();
            }
        }
        private static readonly Random _random = new Random();

        private Brush GetRandomColorBrush()
        {
            return new SolidColorBrush(Color.FromRgb(
                (byte)_random.Next(150, 255),
                (byte)_random.Next(150, 255),
                (byte)_random.Next(150, 255)));
        }
        public Func<double, string> YFormatter { get; }

        public HomeViewModel()
        {
            YFormatter = value => $"{Math.Abs(value):0.00} €";
        }

        private readonly DB_Services _services = DB_Services.Instance;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
            try
            {
                Console.WriteLine($"Starte Balkendiagramm-Datenladen für UserID: {userId}");

                string query = @"
                    SELECT c.Name AS CategoryName, strftime('%Y-%m', Date) AS Month, SUM(Amount) AS TotalAmount
                    FROM Transactions t
                    JOIN Category c ON t.CategoryID = c.CategoryID
                    WHERE t.AccountID = @UserID
                    GROUP BY c.CategoryID, Month
                    ORDER BY Month;";

                var parameters = new Dictionary<string, object> { { "@UserID", userId } };
                DataTable dataTable = _services.ExecuteQuery(query, parameters);

                if (dataTable.Rows.Count == 0)
                {
                    Console.WriteLine("Keine Daten gefunden - leeres Diagramm");
                    LineSeriesCollection = new SeriesCollection();
                    DateLabels = new List<string> { "Keine Daten" };
                    return;
                }

                var allMonths = dataTable.AsEnumerable()
                    .Select(r => r["Month"].ToString())
                    .Distinct()
                    .OrderBy(m => m)
                    .ToList();

                var allCategories = dataTable.AsEnumerable()
                    .Select(r => r["CategoryName"].ToString())
                    .Distinct()
                    .ToList();

                var newSeriesCollection = new SeriesCollection();

                foreach (var category in allCategories)
                {
                    var monthlyAmounts = new List<double>();

                    foreach (var month in allMonths)
                    {
                        var rows = dataTable.AsEnumerable()
                            .Where(r => r["CategoryName"].ToString() == category &&
                                        r["Month"].ToString() == month)
                            .ToList();

                        double sum = rows.Any() ? rows.Sum(r => Convert.ToDouble(r["TotalAmount"])) : 0;
                        monthlyAmounts.Add(sum);
                    }

                    var randomColor = new SolidColorBrush(Color.FromRgb(
                        (byte)_random.Next(100, 255),
                        (byte)_random.Next(100, 255),
                        (byte)_random.Next(100, 255)));

                    var columnSeries = new ColumnSeries
                    {
                        Title = category,
                        Values = new ChartValues<double>(monthlyAmounts),
                        Fill = randomColor
                    };

                    newSeriesCollection.Add(columnSeries);
                }

                LineSeriesCollection = newSeriesCollection;
                DateLabels = allMonths;

                Console.WriteLine($"Balkendiagramm erfolgreich geladen. Kategorien: {allCategories.Count}, Monate: {allMonths.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FEHLER: {ex.Message}");
                Console.WriteLine(ex.StackTrace);

                // Fallback-Testdaten
                DateLabels = new List<string> { "2025-01", "2025-02", "2025-03" };
                LineSeriesCollection = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Testdaten",
                        Values = new ChartValues<double> { 150, 300, 450 },
                        Fill = Brushes.Gray
                    }
                };
            }
        }
    }
}