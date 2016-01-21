namespace CohesionAndCoupling.Utils
{
    using System;
    using Interfaces;

    public static class Geometry2DUtils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double deltaX = x2 - x1;
            double deltaY = y2 - y1;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            return distance;
        }

        public static double CalcDiagonalXY(double width, double height)
        {
            double distance = CalcDistance2D(0, 0, width, height);
            return distance;
        }
    }
}
