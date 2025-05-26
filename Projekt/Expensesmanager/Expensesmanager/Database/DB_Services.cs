using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;

namespace Expensesmanager.Database
{
  public class DB_Services
  {
    private static DB_Services _instance;
    private static readonly object _lock = new object();

    
    public static DB_Services Instance
    {
      get
      {
        if (_instance == null)
        {
          lock (_lock)
          {
            if (_instance == null)
            {
              _instance = new DB_Services();
            }
          }
        }
        return _instance;
      }
    }

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
        Console.WriteLine($"[Fehler bei ExecuteQuery] {ex.Message}");
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
            command.ExecuteNonQuery();
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"[Fehler bei ExecuteNonQuery] {ex.Message}");
        Console.WriteLine($"[SQL] {query}");
      }
    }
  }
}
