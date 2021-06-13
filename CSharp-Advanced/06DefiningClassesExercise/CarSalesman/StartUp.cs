using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] enginesData = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                engines.Add(CreateEngine(enginesData));
            }

            int m = int.Parse(Console.ReadLine());

            for (int j = 0; j < m; j++)
            {
                string[] carData = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                cars.Add(CreateCar(carData, engines));
    
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static Engine CreateEngine(string[] enginesData)
        {
            string model = enginesData[0];
            int power = int.Parse(enginesData[1]);
            string displacement = "n/a";
            string efficiency = "n/a";

            Engine engine = new Engine(model, power);

            if (enginesData.Length == 3)
            {
                if (char.IsDigit(enginesData[2][0]))
                {
                    displacement = enginesData[2];
                }
                else
                {
                    efficiency = enginesData[2];
                }
            }
            else if (enginesData.Length == 4)
            {
                displacement = enginesData[2];
                efficiency = enginesData[3];
            }
            engine.Displacement = displacement;
            engine.Efficiency = efficiency;

            return engine;
        }

        private static Car CreateCar(string[] carData, List<Engine> engines)
        {
            string carModel = carData[0];
            string engineModel = carData[1];
            Engine carEngine = engines.Find(engine => engine.Model == engineModel);
            string weight = "n/a";
            string colour = "n/a";

            if (carData.Length == 3)
            {

                if (char.IsDigit(carData[2][0]))
                {
                    weight = carData[2];
                }
                else
                {
                    colour = carData[2];
                }
            }
            else if (carData.Length == 4)
            {
                weight = carData[2];
                colour = carData[3];
            }

            Car currCar = new Car(carModel, carEngine)
            {
                Weight = weight,
                Color = colour
            };

            return currCar;
        }
     
    }
}
