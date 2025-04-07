using System.ComponentModel;
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
  public partial class UserView : UserControl, INotifyPropertyChanged
  {
    private string _userNameTag;

    public string UserNameTag
    {
      get => _userNameTag;
      set
      {
        _userNameTag = value;
        OnPropertyChanged(nameof(UserNameTag));  // Benachrichtige über die Änderung
      }
    }

    public UserView()
    {
      InitializeComponent();
      DataContext = this;  // Setze das DataContext auf das UserControl selbst
      UserNameTag = "test";  // Setze einen Initialwert
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    private void change_userName(object sender, TextChangedEventArgs e)
    {
      // Beispiel: Textfeld ändert den Wert in "test"
      UserNameTag = "test";
    }
  

  private void change_userLastName(object sender, TextChangedEventArgs e)
    {
 
    }




    private void change_userEmail(object sender, TextChangedEventArgs e)
    {

    }

    private void change_userPassword(object sender, TextChangedEventArgs e)
    {

    }


    private void change_userIncome(object sender, TextChangedEventArgs e)
    {

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
