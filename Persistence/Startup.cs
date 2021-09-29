using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Persistence
{
    static class Startup
    {
        static async Task Main(string[] args)
        {
            try 
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "localhost",
                    UserID = "SA",
                    Password = "yourStrong(!)Password",
                    InitialCatalog = "Test"
                };
            
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    
                    // Creating DB
                    // var sql = "CREATE DATABASE Test;";
                    // var command = new SqlCommand(sql, connection);
                    // command.ExecuteNonQuery();
                    
                    // Run SQL
                    var script = await File.ReadAllTextAsync(@"D:\Skole\7. semester\Bachelor\Testprojects\MicroserviceExample\Persistence\SQL\001CreateTableTest.sql");
                    var createTables = new SqlCommand(script, connection);
                    await createTables.ExecuteNonQueryAsync();
                    
                    Console.WriteLine("Success");
                    
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }

        public static async Task Insert(SqlCommand sqlCommand)
        {
            try 
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "localhost",
                    UserID = "SA",
                    Password = "yourStrong(!)Password",
                    InitialCatalog = "Test"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    sqlCommand.Connection = connection;
                    
                    await sqlCommand.ExecuteNonQueryAsync();
                    
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
        public static async Task<string> Query(SqlCommand sqlCommand)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "localhost",
                    UserID = "SA",
                    Password = "yourStrong(!)Password",
                    InitialCatalog = "Test"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    sqlCommand.Connection = connection;

                    var reader = await sqlCommand.ExecuteReaderAsync();
                    
                    while (await reader.ReadAsync())
                    {
                        return reader.GetValue(2).ToString();
                    }
                    
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }
    }
}