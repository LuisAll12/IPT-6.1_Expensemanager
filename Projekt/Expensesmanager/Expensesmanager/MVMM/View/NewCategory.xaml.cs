using Expensesmanager.MVMM.ViewModel;
using Expensesmanager.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
  /// Interaktionslogik für NewCategory.xaml
  /// </summary>
  public partial class NewCategory : UserControl
  {
        private NewCategoryViewModel nc_viewmodel;

        private double amount = double.NaN;
        public NewCategory()
        {
          InitializeComponent();
          nc_viewmodel = new NewCategoryViewModel();
        }
        // Event-Handler für TextChanged von txtDescription
        private void categorytxtDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
           string input = categorytxtDescription.Text;
           categorycharCount.Text = input.Length.ToString() + "/255";
        }

        // Event-Handler für den ResetButton_Click
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetFields();
        }

        // Event-Handler für den SubmitButton_Click
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            categorylblError.Visibility = Visibility.Hidden;

            string validationMessage = CheckInputs();
            if (string.IsNullOrEmpty(validationMessage))
            {
                string name =           categoryName.Text;
                string description =    categorytxtDescription.Text;
                double budget = double.Parse(txtBudget.Text);

                // Alles OK → Absenden
                if (nc_viewmodel.NewCategory(name, description, budget)) 
                {
                    // Beispiel: Daten speichern etc.
                    categorylblError.Text = "Erfolgreich gespeichert";
                    categorylblError.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#28C940"));
                    categorylblError.Visibility = Visibility.Visible;

                    ResetFields();
                }
            }
            else
            {
                // Fehleranzeige
                categorylblError.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF5F56"));
                categorylblError.Text = validationMessage;
                categorylblError.Visibility = Visibility.Visible;
            }
        }

        // Optional: Methode zur Validierung der Eingaben
        private string CheckInputs()
        {
            // Check Name
            if (string.IsNullOrWhiteSpace(categoryName.Text))
            {
                return "Nicht alle Felder ausgefüllt!";
            }
            if (categoryName.Text.Length > 25)
            {
                return "Der Name ist zu lang. Bitte ändern!";
            }

            // Check Budget
            string budgetCheck = CheckBudget();
            if (!string.IsNullOrEmpty(budgetCheck))
            {
                return budgetCheck;
            }

            return string.Empty; // Kein Fehler → leere Rückgabe
        }

        private string CheckBudget()
        {
            string res = String.Empty;
            if (string.IsNullOrWhiteSpace(txtBudget.Text)) return "Nicht alle Felder ausgefüllt!";
            try
            {
                amount = double.Parse(txtBudget.Text);
            }
            catch (FormatException)
            {
                res = "Geben Sie einen gültigen Betrag an!";
            }
            return res;
        }

        private void ResetFields()
        {
            categoryName.Text = String.Empty;
            categorytxtDescription.Text = String.Empty;
            txtBudget.Text = String.Empty;
        }
  }
}
