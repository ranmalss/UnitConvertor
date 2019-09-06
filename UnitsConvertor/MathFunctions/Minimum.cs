using System;
using System.Collections.Generic;
using System.Text;

namespace MathFunctions
{
    public static partial class CommonMathFunctions
    {
        public static double Minimum(params double[] Values)
        {
            double MinVal = 0; //Initially set max value to 0
            for (int i = 0; i <= Values.GetUpperBound(0); i++)
            {
                if (i == 0)
                {
                    MinVal = Values[i];
                }
                else if (Values[i] < MinVal)
                {
                    MinVal = Values[i];
                }
            }
            return MinVal;
        }

        public static double Minimum(params int[] Values)
        {
            double MinVal = 0; //Initially set max value to 0
            for (int i = 0; i <= Values.GetUpperBound(0); i++)
            {
                if (i == 0)
                {
                    MinVal = Values[i];
                }
                else if (Values[i] < MinVal)
                {
                    MinVal = Values[i];
                }
            }
            return MinVal;
        }

        public static double Minimum(params long[] Values)
        {
            double MinVal = 0; //Initially set max value to 0
            for (int i = 0; i <= Values.GetUpperBound(0); i++)
            {
                if (i == 0)
                {
                    MinVal = Values[i];
                }
                else if (Values[i] < MinVal)
                {
                    MinVal = Values[i];
                }
            }
            return MinVal;
        }
    }
}
