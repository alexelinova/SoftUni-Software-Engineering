using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _05EmployeesFromResearchAndDevelopment
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbcontext = new SoftUniContext();

            string employeeDetails = GetEmployeesFromResearchAndDevelopment(dbcontext);
            Console.WriteLine(employeeDetails);
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName);

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - {employee.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
