using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Station.DB
{
    public static class Geometry
    {
        public static double DistanceTo(this RailConnectionPoint Start ,RailConnectionPoint End) {
            double distance = 0;
            double X = End.X - Start.X;
            double Y = End.Y - Start.Y;

            distance= Math.Sqrt(Y * Y + X * X);

            return distance;
        }
    }
}
