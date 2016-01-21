namespace CohesionAndCoupling.Models
{
    using Interfaces;

    public class Parallelepiped : IFigure3D
    {
        public Parallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width { get; set; }

        public double Height { get; set; }
               
        public double Depth { get; set; }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }
    }
}
