using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace DepartmentsWithMoreThan5Employees
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbcontext = new SoftUniContext();
            string departments = GetDepartmentsWithMoreThan5Employees(dbcontext);
            Console.WriteLine(departments);
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFullName = d.Manager.FirstName + " " + d.Manager.LastName,
                    EmployeesInfo = d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName).Select(e => new
                    {
                        EmployeeFullName = e.FirstName + " " + e.LastName,
                        Jobtitle = e.JobTitle,
                    })
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFullName}");

                foreach (var employee in department.EmployeesInfo)
                {
                    sb.AppendLine($"{employee.EmployeeFullName} - {employee.Jobtitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
