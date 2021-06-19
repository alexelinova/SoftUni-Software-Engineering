using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethod
{
    public class Box<T>
    {

        public Box()
        {
            Elements = new List<T>();
        }

        public List<T> Elements { get; set; }


        public void Swap(int indexOne, int indexTwo)
        {
            T temp = this.Elements[indexOne];
            this.Elements[indexOne] = this.Elements[indexTwo];
            this.Elements[indexTwo] = temp;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.Elements)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
