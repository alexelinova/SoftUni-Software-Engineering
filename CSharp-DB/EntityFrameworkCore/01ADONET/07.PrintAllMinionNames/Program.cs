using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _07.PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string minionNamesQuery = @"SELECT Name FROM Minions";

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                List<string> minionNames = GeMinionNames(minionNamesQuery, connection);

                PrintMinionNames(minionNames);
            }
        }

        private static void PrintMinionNames(List<string> minionNames)
        {
            for (int i = 0; i < minionNames.Count / 2; i++)
            {
                Console.WriteLine(minionNames[i]);
                Console.WriteLine(minionNames[minionNames.Count - 1 - i]);
            }

            if (minionNames.Count % 2 != 0)
            {
                Console.WriteLine(minionNames[minionNames.Count / 2]);
            }
        }

        private static List<string> GeMinionNames(string minionNamesQuery, SqlConnection connection)
        {
            List<string> minionNames = new List<string>();

            using (SqlCommand command = new SqlCommand(minionNamesQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        minionNames.Add((string)reader["Name"]);
                    }

                    return minionNames;
                }
            }
        }
    }
}
