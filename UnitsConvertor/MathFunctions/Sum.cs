using System;
using System.Collections.Generic;
using System.Text;

namespace MathFunctions
{
    public static partial class CommonMathFunctions
    {
        public static double Sum(double[] arr)
        {
            double sum = 0;

            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        public static double Sum(double[,] arr)
        {
            double sum = 0;

            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    sum += arr[i, j];
                }
                
            }

            return sum;
        }

        public static double Sum(params object[] arr)
        {
            double sum = 0;

            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                if (double.TryParse(Convert.ToString(arr[i]), out double res) == true)
                {
                    sum += res;
                }
            }

            return sum;
        }
    }
}
