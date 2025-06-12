using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace SonarDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 🔐 Hardcoded credentials
            string username = "admin";
            string password = "admin123"; // hardcoded password

            // 2. ⚠️ SQL Injection via dynamic query
            Console.Write("Enter user ID: ");
            string userInput = Console.ReadLine();
            string query = "SELECT * FROM Users WHERE UserId = '" + userInput + "'";

            string connStr = $"Server=localhost;Database=TestDb;User Id={username};Password={password};";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Username"]);
                }
            }

            // 3. ❌ Writing logs to console without restrictions (bad practice for security logs)
            Console.WriteLine($"User login attempt: {username}");

            // 4. 🌐 Hardcoded IP address (security-sensitive usage)
            WebClient client = new WebClient();
            string result = client.DownloadString("http://192.168.0.10/api/data");
            Console.WriteLine(result);
        }
    }
}
