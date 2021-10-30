using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _13FindEmployeesByFirstNameStartingWithSa
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbcontext = new SoftUniContext();
            string employeeDetails = GetEmployeesByFirstNameStartingWithSa(dbcontext);
            Console.WriteLine(employeeDetails);
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
