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
  /// Interaktionslogik für UserView.xaml
  /// </summary>
  public partial class UserView : UserControl
  {


    public UserView()
    {
      InitializeComponent();
      //userViewModel = new UserViewModel();
      //this.DataContext = userViewModel; // Bindet das ViewModel an das View
    }


    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
      //this.WindowState = WindowState.Minimized;
    }

    

    // Close Button
    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
    
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
      if (e.LeftButton == MouseButtonState.Pressed)
      {
        //this.DragMove(); // Verschiebt das Fenster, wenn die linke Maustaste gedrückt wird
      }
    }
  }
}
