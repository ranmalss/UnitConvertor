using System;

namespace MathFunctions
{
    public static partial class CommonMathFunctions
    {
        public static double RoundToSignificantDigits(this double d, int digits)
        {
            if(Math.Abs(d) < 1e-10) return 0d;

            var scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);
            return scale * Math.Round(d / scale, digits);
        }
    }
}