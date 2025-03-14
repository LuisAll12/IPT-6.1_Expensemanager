﻿using Expensesmanager.MVMM.ViewModel;
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
    /// Interaktionslogik für EditTransactionView.xaml
    /// </summary>
    public partial class EditTransactionView : Window
    {
        private NewTransactionViewModel nta_viewmodel;
        public EditTransactionView()
        {
            InitializeComponent();
            nta_viewmodel = new NewTransactionViewModel();
        }

        private string DateToSQLiteDate(string inputdate)
        {
            return DateTime.ParseExact(inputdate, "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString();
        }
        private bool CheckInputs()
        {
            bool res = true;
            lblError.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF5F56"));
            // Check Amount
            if (Check_UserInput_Date() != "")
            {
                lblError.Text = Check_UserInput_Date();

                lblError.Visibility = Visibility.Visible;
                res = false;
            }

            // Check Date
            if (Check_UserInput_Amount() != "")
            {
                lblError.Text = Check_UserInput_Amount();

                lblError.Visibility = Visibility.Visible;
                res = false;
            }

            // Check Category
            if (Check_UserInput_Category() != "")
            {
                lblError.Text = Check_UserInput_Category();

                lblError.Visibility = Visibility.Visible;
                res = false;
            }
            return res;
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            txtAmount.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtdateTransaction.Text = String.Empty;
            cmbCategory.SelectedItem = null;
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



        // Load All Categorys
        private void cmbCategory_DropDownOpened(object sender, EventArgs e)
        {
            cmbCategory.ItemsSource = null;
            List<string> options = nta_viewmodel.GetAccountCategory();
            if (options.Count == 0)
            {
                options.Add("Sie haben noch keine Kategorien");
            }
            cmbCategory.ItemsSource = options;
        }

        // Check Category Func

        private string Check_UserInput_Category()
        {
            string input = cmbCategory.SelectedItem?.ToString();
            string res = "";

            if (string.IsNullOrEmpty(input)) res = "Nicht alle Felder ausgefüllt!";
            if (input == "Sie haben noch keine Kategorien")
            {
                res = "Sie müssen zuerst eine Kategorie erstellen";
            }

            return res;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Check User Inputs
            if (CheckInputs())
            {
                // Inputs
                double amount = double.Parse(txtAmount.Text);
                DateTime date = DateTime.ParseExact(txtdateTransaction.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string description = txtDescription.Text;
                string category = cmbCategory.SelectedItem?.ToString() ?? "";

                // Set the DialogResult to true and close the window
                DialogResult = true;
                Close();
            }
        }
    }
}
