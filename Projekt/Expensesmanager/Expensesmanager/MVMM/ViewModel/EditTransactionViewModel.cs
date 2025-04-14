using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace Expensesmanager.MVMM.ViewModel
{
    public class EditTransactionViewModel : INotifyPropertyChanged
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int TransactionID { get; set; }

        public List<string> Categories { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}