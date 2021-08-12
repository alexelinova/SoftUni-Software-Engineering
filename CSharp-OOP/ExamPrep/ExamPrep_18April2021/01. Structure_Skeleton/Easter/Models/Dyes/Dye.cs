﻿using Easter.Models.Dyes.Contracts;


namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private const int PowerDrop = 10;

        private int power;
        public Dye(int power)
        {
            this.Power = power;
        }
        public int Power 
        {
            get => this.power;
            private set
            {
                if (value <0)
                {
                    value = 0;
                }

                this.power = value;
            }
        }

        public bool IsFinished() => this.Power == 0;
       

        public void Use()
        {
            this.Power -= PowerDrop;
        }
    }
}
