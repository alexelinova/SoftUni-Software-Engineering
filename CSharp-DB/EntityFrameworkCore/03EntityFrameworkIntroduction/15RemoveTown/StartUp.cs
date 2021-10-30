using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;

namespace _15RemoveTown
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbcontext = new SoftUniContext();
            string projectNames = RemoveTown(dbcontext);
            Console.WriteLine(projectNames);
        }

        public static string RemoveTown(SoftUniContext context)
        {

            var employeesInSeattle = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList();

            foreach (var employee in employeesInSeattle)
            {
                employee.AddressId = null;
            }

            var addresses = context.Addresses.
                Where(a => a.Town.Name == "Seattle")
                .ToList();

            int count = addresses.Count;

            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
            }

            Town townToRemove = context.Towns
                .FirstOrDefault(t => t.Name == "Seattle");

            context.Towns.Remove(townToRemove);

            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";
        }
    }
}
