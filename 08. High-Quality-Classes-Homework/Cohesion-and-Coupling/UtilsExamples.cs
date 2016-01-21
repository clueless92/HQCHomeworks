namespace CohesionAndCoupling
{
    using System;
    using Interfaces;
    using Models;
    using Utils;

    public class UtilsExamples
    {
        private static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                Geometry2DUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                Geometry3DUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            IFigure3D figure3D = new Parallelepiped(3d, 4d, 5d);
            Console.WriteLine("Volume = {0:f2}", figure3D.CalcVolume());
            Console.WriteLine(
                "Diagonal XYZ = {0:f2}",
                Geometry3DUtils.CalcDiagonalXYZ(figure3D.Width, figure3D.Height, figure3D.Depth));
            Console.WriteLine(
                "Diagonal XY = {0:f2}",
                Geometry2DUtils.CalcDiagonalXY(figure3D.Width, figure3D.Height));
            Console.WriteLine(
                "Diagonal XZ = {0:f2}",
                Geometry3DUtils.CalcDiagonalXZ(figure3D.Width, figure3D.Depth));
            Console.WriteLine(
                "Diagonal YZ = {0:f2}",
                Geometry3DUtils.CalcDiagonalYZ(figure3D.Height, figure3D.Depth));
        }
    }
}
