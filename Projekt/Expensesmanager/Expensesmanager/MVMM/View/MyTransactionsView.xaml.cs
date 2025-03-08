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
    /// Interaktionslogik für MyTransactionsView.xaml
    /// </summary>
    public partial class MyTransactionsView: UserControl
    {
        public MyTransactionsView()
        {
            InitializeComponent();
            //Records.Add(new Record { Betrag = 243, Datum = new DateTime(2025, 1, 1), Kategorie = "Kategorie1" });
            //Records.Add(new Record { Betrag = 23, Datum = new DateTime(2025, 1, 1), Kategorie = "Kategorie1" });
            //Records.Add(new Record { Betrag = 23, Datum = new DateTime(2025, 1, 3), Kategorie = "Kategorie3" });
            //Records.Add(new Record { Betrag = 65, Datum = new DateTime(2025, 1, 4), Kategorie = "Kategorie2" });
            //Records.Add(new Record { Betrag = 123, Datum = new DateTime(2025, 1, 6), Kategorie = "Kategorie4" });

            //// Setzen Sie den DataContext des Fensters auf sich selbst
            //DataContext = this;
        }
        // public ObservableCollection<Record> Records { get; set; } = new ObservableCollection<Record>();
    }
    //public class Record
    //{
    //    public double Betrag { get; set; }
    //    public DateTime Datum { get; set; }
    //    public string Kategorie { get; set; }
    //}
}
    
