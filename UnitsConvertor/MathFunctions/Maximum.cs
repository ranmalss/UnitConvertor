namespace MathFunctions
{
    public static partial class CommonMathFunctions
    {
        public static double Maximum(params double[] Values)
        {
            double MaxVal = 0; //Initially set max value to 0
            for (int i = 0; i <= Values.GetUpperBound(0); i++)
            {
                if (i == 0)
                {
                    MaxVal = Values[i];
                }
                else if (Values[i] > MaxVal)
                {
                    MaxVal = Values[i];
                }
            }
            return MaxVal;
        }

        public static double Maximum(params int[] Values)
        {
            double MaxVal = 0; //Initially set max value to 0
            for (int i = 0; i <= Values.GetUpperBound(0); i++)
            {
                if (i == 0)
                {
                    MaxVal = Values[i];
                }
                else if (Values[i] > MaxVal)
                {
                    MaxVal = Values[i];
                }
            }
            return MaxVal;
        }

        public static double Maximum(params long[] Values)
        {
            double MaxVal = 0; //Initially set max value to 0
            for (int i = 0; i <= Values.GetUpperBound(0); i++)
            {
                if (i == 0)
                {
                    MaxVal = Values[i];
                }
                else if (Values[i] > MaxVal)
                {
                    MaxVal = Values[i];
                }
            }
            return MaxVal;
        }
    }
}
