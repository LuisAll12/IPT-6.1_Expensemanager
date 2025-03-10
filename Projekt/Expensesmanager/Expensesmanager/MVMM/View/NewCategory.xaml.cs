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
  }
}
