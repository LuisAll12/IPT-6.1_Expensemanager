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
            if (Check_UserInput_Date() != "")
            {
                lblError.Text = Check_UserInput_Date();

                lblError.Visibility = Visibility.Visible;
            }

            // Check Date
            if (Check_UserInput_Amount() != "")
            {
                lblError.Text = Check_UserInput_Amount();

                lblError.Visibility = Visibility.Visible;
            }

            // Check Category



        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            lblError.Visibility = Visibility.Hidden;
        }
        // Check Amount Func
        private string Check_UserInput_Amount()
        {
            string input = txtAmount.Text;
            string res = "";

            if (string.IsNullOrWhiteSpace(input)) res = "Nicht alle Felder ausgefüllt!";

            try
            {
                double amount = 0.0;
                amount = double.Parse(txtAmount.Text);
            }
            catch (FormatException)
            {
                res = "Geben Sie einen gültigen Betrag an!";
            }
            return res;
        }

        // Check Date Func
        private string Check_UserInput_Date()   
        {
            string input = txtdateTransaction.Text;
            string res = "";

            if (string.IsNullOrWhiteSpace(input)) res = "Nicht alle Felder ausgefüllt!";

            if (!DateTime.TryParseExact(input, "dd.MM.yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out _)) res = "Datum hat falsches format!";
            return res;
        }

        private List<string> options = new List<string> { "Option 1", "Option 2", "Option 3" };

        private void cmbCategory_DropDownOpened(object sender, EventArgs e)
        {
            cmbCategory.ItemsSource = null;  // Notwendig, damit Änderungen erkannt werden
            cmbCategory.ItemsSource = options;
        }

        // Check Category Func


    }

}
