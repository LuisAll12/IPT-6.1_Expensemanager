using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Expensesmanager.View;
using SQLitePCL;
namespace Expensesmanager
{
    public partial class App : Application
    {
        public static string ConnectionString { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            //SQLite startup
            base.OnStartup(e);
            SQLitePCL.Batteries_V2.Init();

            // Database Connection
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = System.IO.Path.Combine(baseDirectory, "Database", "ExpensesManagerDB.db");

            // Set ConnectionString
            ConnectionString = $"Data Source={dbPath}";
        }
    }
}
