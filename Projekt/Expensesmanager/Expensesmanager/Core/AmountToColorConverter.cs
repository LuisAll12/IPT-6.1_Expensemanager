using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;


namespace Expensesmanager.Core
{
    public class AmountToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double amount)
            {
                return amount < 0
                    ? (Brush)new BrushConverter().ConvertFromString("#FF5F56") // Red
                    : (Brush)new BrushConverter().ConvertFromString("#28C940"); // Green
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
