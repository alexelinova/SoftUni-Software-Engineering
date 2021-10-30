using System;
using System.Linq;
using System.Text;
using SoftUni.Data;

namespace _04EmployeesWithSalaryOver50000
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbcontext = new SoftUniContext();

            string employeeDetails = GetEmployeesWithSalaryOver50000(dbcontext);
            Console.WriteLine(employeeDetails);
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary,
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
