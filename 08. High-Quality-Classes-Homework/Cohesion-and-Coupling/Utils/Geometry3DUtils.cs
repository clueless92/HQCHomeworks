namespace CohesionAndCoupling.Utils
{
    using System;
    using Interfaces;

    public static class Geometry3DUtils
    {
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double deltaX = x2 - x1;
            double deltaY = y2 - y1;
            double deltaZ = z2 - z1;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
            return distance;
        }

        public static double CalcDiagonalXYZ(double width, double height, double depth)
        {
            double distance = CalcDistance3D(0, 0, 0, width, height, depth);
            return distance;
        }

        public static double CalcDiagonalXZ(double width, double depth)
        {
            double distance = Geometry2DUtils.CalcDistance2D(0, 0, width, depth);
            return distance;
        }

        public static double CalcDiagonalYZ(double height, double depth)
        {
            double distance = Geometry2DUtils.CalcDistance2D(0, 0, height, depth);
            return distance;
        }
    }
}
