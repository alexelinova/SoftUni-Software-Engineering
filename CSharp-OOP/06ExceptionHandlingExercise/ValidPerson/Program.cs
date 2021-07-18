using System;
using System.Collections.Generic;

namespace ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person noName = new Person("Gin40", "Peshev", 5);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
