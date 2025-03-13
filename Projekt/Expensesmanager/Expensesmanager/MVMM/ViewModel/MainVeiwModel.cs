using Expensesmanager.Core;
using System;

namespace Expensesmanager.MVMM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        // Variables
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand NewTransactionCommand { get; set; }

        public RelayCommand MyTransactionsCommand { get; set; }
        public RelayCommand NewCategoryCommand { get; set; }
        public RelayCommand MyCategoriesCommand { get; set; }

        public HomeViewModel HomeViewModel { get; set; }
        public NewTransactionViewModel NewTransactionVM { get; set; }
        public MyTransactionsViewModel MyTransactionsVM { get; set; }
        public NewCategoryViewModel NewCategoryVM { get; set; }
        public MyCategoriesViewModel MyCategoriesVM { get; set; }

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

        // Mainclass
        public MainViewModel()
        {
            // Set Values
            HomeViewModel = new HomeViewModel();
            NewTransactionVM = new NewTransactionViewModel();
            MyTransactionsVM = new MyTransactionsViewModel();
            NewCategoryVM = new NewCategoryViewModel();
            MyCategoriesVM = new MyCategoriesViewModel();

            CurrentView = HomeViewModel;

            // HomeView
            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeViewModel;
            });
            // New Transaction
            NewTransactionCommand = new RelayCommand(o =>
            {
                CurrentView = NewTransactionVM;
            });
            // My Transactions
            MyTransactionsCommand = new RelayCommand(o =>
            {
                CurrentView = MyTransactionsVM;
            });
            // New Category
            NewCategoryCommand = new RelayCommand(o =>
            {
              CurrentView = NewCategoryVM;
            });
            // My Categories
            MyCategoriesCommand = new RelayCommand(o =>
            {
                CurrentView = MyCategoriesVM;
            });
        }
    }
}
