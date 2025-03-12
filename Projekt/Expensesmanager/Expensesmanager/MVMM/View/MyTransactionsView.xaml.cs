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
using System.Collections.ObjectModel;


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
            this.DataContext = new MyTransactionsViewModel();
    }
        public ObservableCollection<Record> Records { get; set; } = new ObservableCollection<Record>();

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit Button wurde geklickt!");
        }
    }
    public class Record
    {
        public int TransactionID { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }
}
    
