namespace CohesionAndCoupling.Interfaces
{
    public interface IFigure3D : IFigure2D
    {
        double Depth { get; set; }

        double CalcVolume();
    }
}
