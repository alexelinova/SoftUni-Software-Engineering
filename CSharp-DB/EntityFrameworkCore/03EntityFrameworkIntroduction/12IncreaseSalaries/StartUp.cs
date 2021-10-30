using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12IncreaseSalaries
{
    public class StartUp
    {
        public static int Employees { get; private set; }

        static void Main(string[] args)
        {
            SoftUniContext dbcontext = new SoftUniContext();
            string employeesWithIncreasedSalaries = IncreaseSalaries(dbcontext);
            Console.WriteLine(employeesWithIncreasedSalaries);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            List<Employee> employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary += employee.Salary * 0.12M;
            }

            context.SaveChanges();

            var updatedSalaries = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in updatedSalaries)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
