using _01.InitialSetup;
using System;
using Microsoft.Data.SqlClient;

namespace _02.VillainNames
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string command = @"  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                       FROM Villains AS v 
                                       JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                   GROUP BY v.Id, v.Name 
                                     HAVING COUNT(mv.VillainId) > 3 
                                   ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand cmd = new SqlCommand(command, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                        }
                    }
                }
            }
        }
    }
}
