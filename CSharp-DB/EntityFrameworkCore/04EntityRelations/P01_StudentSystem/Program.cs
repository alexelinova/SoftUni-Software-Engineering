using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StudentSystemContext dbcontext = new StudentSystemContext();
            dbcontext.Database.EnsureDeleted();
            dbcontext.Database.EnsureCreated();
        }
    }
}
