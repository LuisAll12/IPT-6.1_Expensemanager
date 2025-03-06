using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace Expensesmanager.MVMM.View
{
    /// <summary>
    /// Interaktionslogik für NewTransaction.xaml
    /// </summary>
    public partial class NewTransaction : UserControl
    {
        public NewTransaction()
        {
            InitializeComponent();
        }

        private void txtDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = txtDescription.Text;
            charCount.Text = input.Length.ToString() + "/255";
            
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Check Amount
            if (!Check_UserInput_Date())
            {
                lblError.Focus();
                lblError.Text = "Datum hat falsches format";
                lblError.Visibility = Visibility.Visible;
            }
            // Check Date


        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            lblError.Visibility = Visibility.Hidden;
        }

        // Check Amount Func
        private bool Check_UserInput_Date()
        {
            string input = txtdateTransaction.Text;
            return DateTime.TryParseExact(input, "dd.MM.yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
        // Check Date Func


    }

}
