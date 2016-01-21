namespace Methods
{
    using System;

    public class CalculationUtils
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0d || b <= 0d || c <= 0d)
            {
                throw new ArgumentException("Sides cannot be negative.");
            }

            double perimeterHalf = (a + b + c) / 2;
            double area = 
                Math.Sqrt(perimeterHalf * (perimeterHalf - a) * (perimeterHalf - b) * (perimeterHalf - c));
            return area;
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("No arguments have been entered.");
            }

            int maxElement = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }
            
            return maxElement;
        }


        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static bool IsVertical(double x1, double x2)
        {
            bool isVertical = Equals(x1, x2);
            return isVertical;
        }

        public static bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = Equals(y1, y2);
            return isHorizontal;
        }
    }
}
