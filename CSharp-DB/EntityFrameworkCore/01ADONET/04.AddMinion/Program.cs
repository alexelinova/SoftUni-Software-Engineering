using _01.InitialSetup;
using Microsoft.Data.SqlClient;
using System;

namespace _04.AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split();
            string[] villainInfo = Console.ReadLine().Split();

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];
            string villainName = villainInfo[1];

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                int? townId = GetTownIdByName(townName, connection);

                if (townId == null)
                {
                    InsertRecord(Queries.insertTown, "@townName", townName, connection);
                    Console.WriteLine($"Town {townName} was added to the database.");
                    townId = GetTownIdByName(townName, connection);
                }

                InsertMinion(minionName, minionAge, townId, connection);

                int? villainId = GetVillainId(villainName, connection);

                if (villainId == null)
                {
                    InsertRecord(Queries.insertVillain, "@villainName", villainName, connection);
                    Console.WriteLine($"Villain {villainName} was added to the database");
                    villainId = GetVillainId(villainName, connection);
                }

                int minionId = GetMinionIdByName(minionName, connection);

                InsertMinionVillain(villainId, minionId, connection);

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}");
            }
        }

        private static void InsertMinionVillain(int? villainId, int minionId, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.insertMinionsVillains, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.Parameters.AddWithValue("@minionId", minionId);

                command.ExecuteNonQuery();
            }
        }

        private static int GetMinionIdByName(string minionName, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.minionId, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);

                return (int)command.ExecuteScalar();
            }
        }

        private static int? GetVillainId(string villainName, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.villainId, connection))
            {
                command.Parameters.AddWithValue("@name", villainName);

                return (int?)command.ExecuteScalar();
            }
        }

        private static void InsertMinion(string minionName, int minionAge, int? townId, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(Queries.insertMinion, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                command.Parameters.AddWithValue("@age", minionAge);
                command.Parameters.AddWithValue("@townId", townId);

                command.ExecuteNonQuery();
            }
        }

        public static void InsertRecord(string insertQuery, string paramName, string paramValue, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue(paramName, paramValue);
                command.ExecuteNonQuery();
            }
        }
        public static int? GetTownIdByName(string townName, SqlConnection connection)
        {
            using (SqlCommand townIdCmd = new SqlCommand(Queries.townId, connection))
            {
                townIdCmd.Parameters.AddWithValue("@townName", townName);
                int? townId = townIdCmd.ExecuteScalar() as int?;

                return townId;
            }
        }
    }
}
