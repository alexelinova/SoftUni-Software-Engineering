namespace _04.AddMinion
{
    public static class Queries
    {
        public const string villainId = "SELECT Id FROM Villains WHERE Name = @Name";

        public const string minionId = "SELECT Id FROM Minions WHERE Name = @Name";

        public const string insertMinionsVillains = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

        public const string insertVillain = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public const string insertMinion = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

        public const string insertTown = "INSERT INTO Towns (Name) VALUES (@townName)";

        public const string townId = "SELECT Id FROM Towns WHERE Name = @townName";
    }
}
