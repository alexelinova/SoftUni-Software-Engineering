namespace _09.IncreaseAgeStoredProcedure
{
    public static class Queries
    {
        public const string CreateGetOlderProcedure = @"CREATE PROC usp_GetOlder @id INT
                                                        AS
                                                        UPDATE Minions
                                                           SET Age += 1
                                                         WHERE Id = @id";

        public const string ExecuteProcedure = @"EXEC usp_GetOlder @id";

        public const string MinionNameAndAgeById = @"SELECT Name, Age FROM Minions WHERE Id = @Id";
    }
}
