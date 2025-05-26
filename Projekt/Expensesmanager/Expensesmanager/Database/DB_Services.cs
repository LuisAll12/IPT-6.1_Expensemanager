//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Security.RightsManagement;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Data.Sqlite;

//namespace Expensesmanager.Database
//{
//  public class DB_Services
//  {
//    private string connectionString = App.ConnectionString;


//    public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
//    {
//      DataTable resultTable = new DataTable();

//      try
//      {
//        using (var connection = new SqliteConnection(connectionString))
//        {
//          using (var command = new SqliteCommand(query, connection))
//          {
//            if(parameters != null)
//            {
//              foreach (var param in parameters) 
//              {
//                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
//              }
//            }

//              connection.Open();

//              using (SqliteDataReader reader = command.ExecuteReader()) 
//              {
//                resultTable.Load(reader);
//              }
//            }
//          }
//        } catch (Exception ex) 
//      {
//        Console.WriteLine(ex.ToString());
//      }

//      return resultTable;
//    }
//  }
//}

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
    // Private statische Instanz, die den Singleton repräsentiert
    private static DB_Services _instance;

    // Private Konstruktor, um zu verhindern, dass von außen Instanzen erstellt werden
    private DB_Services()
    {
      // Initialisierung
    }

    // Öffentliche statische Eigenschaft, die den Zugriff auf die Instanz ermöglicht
    public static DB_Services Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new DB_Services();
        }
        return _instance;
      }
    }

    private string connectionString = App.ConnectionString;

    public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
    {
      DataTable resultTable = new DataTable();
      string connStr = connectionString;
      try
      {
        using (var connection = new SqliteConnection(connStr))
        {
          using (var command = new SqliteCommand(query, connection))
          {
            if (parameters != null)
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
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }



      return resultTable;
    }

    public void ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
    {
      try
      {
        using (var connection = new SqliteConnection(connectionString))
        {
          using (var command = new SqliteCommand(query, connection))
          {
            if (parameters != null)
            {
              foreach (var param in parameters)
              {
                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
              }
            }

            connection.Open();
            command.ExecuteNonQuery(); // führt INSERT, UPDATE oder DELETE aus
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

  }
}
