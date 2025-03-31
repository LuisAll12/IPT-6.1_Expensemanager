using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Expensesmanager.Database
{
  public class DB_Services
  {
    private string connection_string = App.ConnectionString;


    public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
    {
      DataTable resultTable = new DataTable();

      try
      {

      } catch (Exception ex) 
      {
      
      }

      return resultTable;
    }
  }
}
