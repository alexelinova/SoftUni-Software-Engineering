using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace _14DeleteProjectById
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbcontext = new SoftUniContext();
            string projectNames = DeleteProjectById(dbcontext);
            Console.WriteLine(projectNames);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToRemove = context.Projects.Find(2);

            var employeeProjects = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            foreach (var project in employeeProjects)
            {
                context.EmployeesProjects.Remove(project);
            }

            context.Projects.Remove(projectToRemove);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => p.Name)
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var name in projects)
            {
                sb.AppendLine(name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
