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
using Expensesmanager;
using Expensesmanager.MVMM.ViewModel;
using Expensesmanager.ViewModel;
using Expensesmanager.View;
using Expensesmanager.MVMM.Help;

namespace Expensesmanager
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this.WindowState == WindowState.Maximized)
        //    {
        //        this.WindowState = WindowState.Normal;
        //    }
        //    else
        //    {
        //        this.WindowState = WindowState.Maximized;
        //    }
        //}

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove(); // Verschiebt das Fenster, wenn die linke Maustaste gedrückt wird
            }
        }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {

        }

    private void LogoutButton_Click(object sender, RoutedEventArgs e)
    {
      LoginViewModel.Logout();
      LoginView loginviewmodel = new LoginView();
      loginviewmodel.Show();

      this.Close();
    }


        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpView helpviewmodel = new HelpView();
            helpviewmodel.Show();
        }
    }
}
