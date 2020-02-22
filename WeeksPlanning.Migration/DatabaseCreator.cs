using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WeeksPlanning.Migration
{
    public static class DatabaseCreator
    {
        /// <summary>
        /// Automatically creates a database for the template if it doesn't already exists.
        /// You might delete this method to disable auto create functionality.
        /// </summary>
        public static void EnsureDatabase( string dbName = "mydb")
        {
            var path = AppDomain.CurrentDomain.BaseDirectory
                .Split(new[] {@"bin\"}, StringSplitOptions.None)[0];
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("Master");
            
            // Create a connection  
            var conn = new SqlConnection(connectionString);
            
            if (conn.State == ConnectionState.Open)  
                conn.Close();  
            
            // Open the connection  
            if (conn.State != ConnectionState.Open)
                conn.Open();
            
            string sql = $"CREATE DATABASE {dbName}";

            var cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close(); 
            }
        }
    }
}