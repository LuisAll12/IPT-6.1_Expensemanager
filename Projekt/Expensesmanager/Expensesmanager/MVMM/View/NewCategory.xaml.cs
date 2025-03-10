using Expensesmanager.MVMM.ViewModel;
using Expensesmanager.View;
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
  /// Interaktionslogik für NewCategory.xaml
  /// </summary>
  public partial class NewCategory : UserControl
  {
    private NewCategoryViewModel nc_viewmodel;
    public NewCategory()
    {
      InitializeComponent();
      nc_viewmodel = new NewCategoryViewModel();
    }
    // Event-Handler für TextChanged von txtDescription
    private void categorytxtDescription_TextChanged(object sender, TextChangedEventArgs e)
    {
      // Deine Logik hier
      string input = categorytxtDescription.Text;
      // Beispiel: Aktualisiere eine Zeichenanzahl, wenn gewünscht
      categorycharCount.Text = input.Length.ToString() + "/255";
    }

    // Event-Handler für den ResetButton_Click
    private void ResetButton_Click(object sender, RoutedEventArgs e)
    {
      // Setze alle Felder zurück
      categorytxtDescription.Text = string.Empty;
      // Weitere Rücksetzlogik hier
    }

    // Event-Handler für den SubmitButton_Click
    private void SubmitButton_Click(object sender, RoutedEventArgs e)
    {
      // Deine Logik für den Submit Button
      // Beispiel: Validierungen und Speichern der Daten
      if (CheckInputs())
      {
        // Weitere Logik für das Absenden
      }
    }

    // Optional: Methode zur Validierung der Eingaben
    private bool CheckInputs()
    {
      // Deine Validierungslogik hier
      return true;
    }
  }
}
