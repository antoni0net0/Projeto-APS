using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace aps.src
{
    public class DatabaseService
    {
        private SqliteConnection sqlite;

        public DatabaseService()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dbPath = System.IO.Path.Combine(appDataPath, "aps", "database.db");

            // Ensure directory exists
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(dbPath));

            sqlite = new SqliteConnection($"Data Source={dbPath}");
            CreateTables();
        }

        private void CreateTables()
        {
            try
            {
                sqlite.Open();
                string sql = @"
                CREATE TABLE IF NOT EXISTS users(
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    username TEXT NOT NULL,
                    hashed_password TEXT NOT NULL
            );";

                using (SqliteCommand command = new SqliteCommand(sql, sqlite))
                {
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Table created");
            }
            catch (SqliteException e)
            {
                Console.WriteLine($"sqlite expection: {e.Message}");
            }
            finally
            {
                sqlite.Close();
            }
        }
        public void InsertData(string table, Dictionary<string, object> values)
        {
            try
            {
                sqlite.Open();

                string columns = string.Join(", ", values.Keys);
                string placeholders = string.Join(", ", values.Keys.Select(k => $"@{k}"));

                string sql = $"INSERT INTO {table} ({columns}) VALUES ({placeholders});";

                using (SqliteCommand command = new SqliteCommand(sql, sqlite))
                {
                    // Add each parameter with its corresponding value.
                    foreach (var pair in values)
                    {
                        command.Parameters.AddWithValue("@" + pair.Key, pair.Value);
                    }

                    // Execute the query.
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Data inserted successfully");
            }
            catch (SqliteException e)
            {
                Console.WriteLine($"Error inserting data: {e.Message}");
            }
            finally
            {
                sqlite.Close();
            }
        }

        public DataTable GetUsers()
        {
            DataTable dt = new DataTable(); // Initialize DataTable

            try
            {
                sqlite.Open();
                string sql = "SELECT * FROM users"; // Match table name case (users vs Users)

                using (SqliteCommand command = new SqliteCommand(sql, sqlite))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader); // Load data directly into DataTable
                    }
                }
                return dt;
            }
            catch (SqliteException ex)
            {
                Console.WriteLine("Error selecting users: " + ex.Message);
                return dt; // Return empty DataTable on error
            }
            finally
            {
                sqlite.Close();
            }
        }

        public void InsertUser(string username, string hashedPassword)
        {
            // Modified to use parameters
            using (var cmd = new SqliteCommand(
                "INSERT INTO users (name, hashed_password) VALUES (@name, @password)",
                sqlite))
            {
                cmd.Parameters.AddWithValue("@name", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                ExecuteNonQuery(cmd);
            }
        }

        private void ExecuteNonQuery(SqliteCommand command)
        {
            try
            {
                sqlite.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                sqlite.Close();
            }
        }
    }
}
