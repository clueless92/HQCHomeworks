namespace Abstraction.Models
{
    using Interfaces;

    public abstract class Figure : IFigure
    {
        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

        public override string ToString()
        {
            string output = string.Format(
                "I am a {0}. My perimeter is {1:f2}. My surface is {2:f2}.",
                this.GetType().Name,
                this.CalcPerimeter(),
                this.CalcSurface());

            return output;
        }
    }
}
