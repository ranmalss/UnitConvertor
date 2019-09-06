using static System.Math;

namespace MathFunctions
{
    public static partial class CommonMathFunctions
    {
        public static double MaxAbs(params double[] Values)
        {
            double MaxVal = 0; //Initially set max value to 0
            for (int i = 0; i <= Values.GetUpperBound(0); i++)
            {
                if (Abs(Values[i]) > MaxVal)
                {
                    MaxVal = Abs(Values[i]);
                }
            }
            return MaxVal;
        }

        public static double MaxAbs(params int[] Values)
        {
            double MaxVal = 0; //Initially set max value to 0
            for (int i = 0; i <= Values.GetUpperBound(0); i++)
            {
                if (Abs(Values[i]) > MaxVal)
                {
                    MaxVal = Abs(Values[i]);
                }
            }
            return MaxVal;
        }

        public static double MaxAbs(params long[] Values)
        {
            double MaxVal = 0; //Initially set max value to 0
            for (int i = 0; i <= Values.GetUpperBound(0); i++)
            {
                if (Abs(Values[i]) > MaxVal)
                {
                    MaxVal = Abs(Values[i]);
                }
            }
            return MaxVal;
        }
    }
}
