using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Expensesmanager.Database
{
  public class DB_Services
  {
    private string connectionString = App.ConnectionString;


    public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
    {
      DataTable resultTable = new DataTable();

      try
      {
        using (var connection = new SqliteConnection(connectionString))
        {
          using (var command = new SqliteCommand(query, connection))
          {
            if(parameters != null)
            {
              foreach (var param in parameters) 
              {
                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
              }
            }

              connection.Open();

              using (SqliteDataReader reader = command.ExecuteReader()) 
              {
                resultTable.Load(reader);
              }
            }
          }
        } catch (Exception ex) 
      {
        Console.WriteLine(ex.ToString());
      }

      return resultTable;
    }
  }
}
