namespace _06.RemoveVillain
{
    public static class Queries
    {
        public const string GetVillainNameById = @"SELECT Name FROM Villains WHERE Id = @villainId";

        public const string DeleteMinionsFromMappingTable = @"DELETE FROM MinionsVillains 
                                                      WHERE VillainId = @villainId";

        public const string DeleteVillainById = @"DELETE FROM Villains
                                                  WHERE Id = @villainId";
    }
}
