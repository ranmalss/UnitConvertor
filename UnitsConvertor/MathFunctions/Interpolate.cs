namespace MathFunctions
{
    public static partial class CommonMathFunctions
    {
        public static double Interpolate(double x1, double y1, double x2, double y2, double x)
        {
            return (y1 - y2) / (x1 - x2) * (x - x2) + y2;
        }
    }
}