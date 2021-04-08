using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_StoreBoxes
{
    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {

        public Box()
        {
            Item = new Item();
        }
        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public decimal PriceBox { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }


                string[] parts = input.Split();

                string serialNumber = parts[0];
                string itemName = parts[1];
                int itemQuantity = int.Parse(parts[2]);
                double itemPrice = double.Parse(parts[3]);

                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    Item = { Name = itemName, Price = itemPrice},
                    Quantity = itemQuantity,
                    PriceBox = itemQuantity * (decimal)itemPrice
                };

                boxes.Add(box);

            }

            List<Box> orderedBoxes = boxes
                  .OrderByDescending(s => s.PriceBox)
                  .ToList();

            foreach (Box box in orderedBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceBox:f2}");
            }
        }
    }

}



