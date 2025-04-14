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
    /// Interaktionslogik für MyCategoriesView.xaml
    /// </summary>
    public partial class MyCategoriesView : UserControl
    {
        public MyCategoriesView()
        {
            InitializeComponent();
            this.DataContext = new MyCategoriesViewModel();
        }

        public ObservableCollection<Record> Categories { get; set; } = new ObservableCollection<Record>();

        public class Category
        {
            public double Budget { get; set; }
            public string Name { get; set; }
            public double SumTransactions { get; set; }
        }

    }
}
