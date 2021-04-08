using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {

            SortedDictionary<string, List<string>> employeeIDByCompany = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] parts = input.Split(" -> ");

                string company = parts[0];

                string employeeID = parts[1];


                if (!employeeIDByCompany.ContainsKey(company))
                {
                    employeeIDByCompany.Add(company, new List<string>());
                }

                employeeIDByCompany[company].Add(employeeID);

               
            }


            foreach (var company in employeeIDByCompany)
            {
                Console.WriteLine(company.Key);

                List<string> uniqueEmployees =
                    company.Value.Distinct()
                    .ToList();

                foreach (var employee in uniqueEmployees)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
