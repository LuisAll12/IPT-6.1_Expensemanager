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

        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
