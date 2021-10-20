namespace _08.IncreaseMinionAge
{
    public static class Queries
    {
        public const string UpdateMinionsAgeAndCase = @"UPDATE Minions
                                                           SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                                         WHERE Id = @Id";

        public const string MinionNameAndAge = @"SELECT Name, Age FROM Minions";
    }
}
