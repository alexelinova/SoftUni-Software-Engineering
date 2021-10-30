using SoftUni.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _07EmployeesAndProjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbcontext = new SoftUniContext();

            string employeeDetails = GetEmployeesInPeriod(dbcontext);
            Console.WriteLine(employeeDetails);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employeesInfo = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(ep => ep.Project)
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeesInfo)
            {
               sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerName}");

                foreach (var project in employee.Projects)
                {
                    string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    string endDate = project.EndDate == null ? "not finished" : project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
