using Expensesmanager.Core;
using System;

namespace Expensesmanager.MVMM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand NewTransactionCommand { get; set; }

        public RelayCommand MyTransactionsCommand { get; set; }

        public HomeViewModel HomeViewModel { get; set; }
        public NewTransactionViewModel NewTransactionVM { get; set; }
        public MyTransactionsViewModel MyTransactionsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public MainViewModel()
        {
            HomeViewModel = new HomeViewModel();
            NewTransactionVM = new NewTransactionViewModel();
            MyTransactionsVM = new MyTransactionsViewModel();

            CurrentView = HomeViewModel;

            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeViewModel;
            });
            NewTransactionCommand = new RelayCommand(o =>
            {
                CurrentView = NewTransactionVM;
            });
            MyTransactionsCommand = new RelayCommand(o =>
            {
                CurrentView = MyTransactionsVM;
            });
        }
    }
}
