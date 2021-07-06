using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
     public static class Validator
    {
        public static void ThrowIfStringIsNullOrEmpty(string str, string message)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfOutSideRange(int value, int minValue, int maxValue, string message)
        {
            if (value < minValue || value > maxValue)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
