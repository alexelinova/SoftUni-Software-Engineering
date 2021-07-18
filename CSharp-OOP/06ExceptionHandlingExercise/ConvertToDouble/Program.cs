using System;

namespace ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = { "0x1F4", "999.99", "-3746431.03", "673849289039264.99", "1.8E308" };

            double result;

            for (int i = 0; i < values.Length; i++)
            {
                try
                {
                    result = Convert.ToDouble(values[i]);
                    Console.WriteLine("Converted {0} to {1}", values[i], result);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to convert {0} to a double", values[i]);
                    throw;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("{0} is outside the range of a double", values[i]);
                    throw;  
                }
            }
        }
    }
}
