namespace Abstraction
{
    using System;
    using Models;

    public class FiguresExample
    {
        private static void Main()
        {
            Figure circle = new Circle(5);
            Console.WriteLine(circle);
            Figure rect = new Rectangle(2, 3);
            Console.WriteLine(rect);
        }
    }
}
