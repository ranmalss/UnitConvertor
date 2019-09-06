using MathNet.Spatial.Euclidean;

namespace MathFunctions
{
    public partial class CommonMathFunctions
    {
        public static double IsLeft(Point2D V0, Point2D V1, Point2D V2)
        {
            //Returns >0 if V2 is left of line passing through V0 and V1
            //Returns 0 if V2 is on the line
            //Returns <0 if V2 is right of the line passing through V0 and V1

            return (V1.X - V0.X) * (V2.Y - V0.Y) - (V2.X - V0.X) * (V1.Y - V0.Y);
        }
    }
}
