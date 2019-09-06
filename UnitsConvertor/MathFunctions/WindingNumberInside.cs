using static System.Math;
using MathNet.Spatial.Euclidean;
using System.Collections.Generic;
using System.Linq;

namespace MathFunctions
{
    public partial class CommonMathFunctions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public static int WindingNumberInside(Point2D p, Polygon2D polygon)
        {
            //V = vertex
            //Vertices is list of polygon vertices
            //Returns winding number, which is == 0 only when V is outside of the polygon
            //Credit for this code goes to: http://geomalgorithms.com/a03-_inclusion.html
            List<Point2D> Vertices = polygon.Vertices.ToList();

            int wn = 0;

            int lastIndex = Vertices.Count;

            if (Vertices[0].X == Vertices[Vertices.Count - 1].X && Vertices[0].Y == Vertices[Vertices.Count - 1].Y)
            {
                lastIndex = Vertices.Count - 1;
            }

            //Loop through all edges of the polygon
            for (int i = 0; i < lastIndex; i++)
            {
                Point2D nextPoint;

                if (i == lastIndex - 1)
                {
                    if (lastIndex == Vertices.Count)
                    {
                        nextPoint = Vertices[0];
                    }
                    else
                    {
                        nextPoint = Vertices[i + 1];
                    }
                }
                else
                {
                    nextPoint = Vertices[i + 1];
                }

                if (Vertices[i].Y <= p.Y) //If the start point 'y' value is less than the point's 'y' value
                {
                    if (nextPoint.Y > p.Y) //An upward crossing
                    {
                        if (IsLeft(Vertices[i], nextPoint, p) > 0) //V is left of the dge
                        {
                            wn += 1;
                        }
                    }
                }
                else
                {
                    if (nextPoint.Y <= p.Y) //A downward crossing
                    {
                        if (IsLeft(Vertices[i], nextPoint, p) < 0) //V is right of the edge
                        {
                            wn -= 1;
                        }
                    }
                }
            }

            return wn;
        }
    }
}
