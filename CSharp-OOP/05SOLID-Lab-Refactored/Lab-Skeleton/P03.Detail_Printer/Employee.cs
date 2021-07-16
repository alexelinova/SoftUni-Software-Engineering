using P03.Detail_Printer.Contracts;

namespace P03.DetailPrinter
{
    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public virtual string EmployeeInfo()
        {
            return $"{this.Name}";
        }
    }
}
