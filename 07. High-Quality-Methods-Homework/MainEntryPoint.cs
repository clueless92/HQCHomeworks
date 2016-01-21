namespace Methods
{
    using System;

    class MainEntryPoint
    {
        private static void Main()
        {
            Console.WriteLine(CalculationUtils.CalculateTriangleArea(3d, 4d, 5d));

            Console.WriteLine(FormatUtils.DigitToText('5'));

            Console.WriteLine(CalculationUtils.FindMax(-1, 3, 2, 14, 2, 3));

            Console.WriteLine(FormatUtils.FormatNumber((object) 1.3, "f"));
            Console.WriteLine(FormatUtils.FormatNumber((object) 0.75, "%"));
            Console.WriteLine(FormatUtils.FormatNumber((object) 2.30, "r"));

            Console.WriteLine(CalculationUtils.CalculateDistance(3d, -1d, 3d, 2.5d));
            Console.WriteLine("Horizontal? " + CalculationUtils.IsHorizontal(-1d, 2.5d));
            Console.WriteLine("Vertical? " + CalculationUtils.IsVertical(3d, 3d));

            Student peter = new Student("Peter", "Ivanov", "17.03.1992", "Sofia");

            Student stella = new Student("Stella", "Markova", "03.11.1993", "Vidin", "Gamer", "High");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
