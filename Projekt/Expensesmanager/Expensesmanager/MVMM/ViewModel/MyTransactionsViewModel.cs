using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.IO;
using System.Windows;
using System.Security.Cryptography;
using Expensesmanager.Core;
using Expensesmanager.ViewModel;
using System.Windows.Documents;
using System.Collections.Generic;
using Expensesmanager.MVMM.View;
using System.Collections.ObjectModel;

namespace Expensesmanager.MVMM.ViewModel
{
    internal class MyTransactionsViewModel
    {
        public ObservableCollection<Record> Records { get; set; }

        public MyTransactionsViewModel()
        {
            Records = new ObservableCollection<Record>();
            GenerateTestData();
        }

        private void GenerateTestData()
        {
            var kategorien = new[] { "Lebensmittel", "Miete", "Freizeit", "Transport", "Versicherung", "Gesundheit", "Sonstiges" };
            var random = new Random();
            var startDatum = new DateTime(2024, 1, 1);

            for (int i = 0; i < 50; i++)
            {
                var record = new Record
                {
                    Betrag = Math.Round(random.NextDouble() * 500, 2), // Zufälliger Betrag von 0 bis 500 CHF
                    Datum = startDatum.AddDays(random.Next(0, 365)), // Zufälliges Datum im Jahr 2024
                    Kategorie = kategorien[random.Next(kategorien.Length)]
                };
                Records.Add(record);
            }
        }
    }   
}
