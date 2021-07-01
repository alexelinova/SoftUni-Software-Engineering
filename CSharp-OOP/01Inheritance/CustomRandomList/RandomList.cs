using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        Random rnd;
        public RandomList()
        {
            rnd = new Random();
        }
        public string RandomString()
        {
            int index = rnd.Next(0, Count);
            string str = this[index];
            this.RemoveAt(index);

            return str;
        }
    }
}
