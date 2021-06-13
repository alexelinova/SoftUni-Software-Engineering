using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
     public class Cargo
    {

        public Cargo( int weight, string type)
        {
            Weigth = weight;
            Type = type;
        }
        public int Weigth { get; set; }
        public string Type { get; set; }

        
    }
}
