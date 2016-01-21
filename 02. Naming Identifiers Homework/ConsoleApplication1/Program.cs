namespace MultiplyMatrixes
{
    using System;

    public class Program
    {
        private const string MultiplyMatrixErrorMessage = 
            "The first matrix's columns must have the same length as the second matrix's rows.";

        static void Main()
        {
            double[,] firstMatrix = { { 1, 3 }, { 5, 7 } };
            double[,] secondMatrix = { { 4, 2 }, { 1, 5 } };
            double[,] result = MultiplyMatrixes(firstMatrix, secondMatrix);

            PrintMatrix(result);
        }

        private static void PrintMatrix(double[,] matrix)
        {
            int rowsCount = matrix.GetLength(0);
            int colsCount = matrix.GetLength(1);
            for (int row = 0; row < rowsCount; row++)
            {
                if (colsCount < 1)
                {
                    continue;
                }
                Console.Write(matrix[row, 0]);
                for (int col = 1; col < colsCount; col++)
                {
                    Console.Write(" " + matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static double[,] MultiplyMatrixes(double[,] firstMatrix, double[,] secondMatrix)
        {
            int firstMatrixColsCount = firstMatrix.GetLength(1);
            int secondMatrixRowsCount = secondMatrix.GetLength(0);
            if (firstMatrixColsCount != secondMatrixRowsCount)
            {
                throw new ArgumentException(MultiplyMatrixErrorMessage);
            }
            int firstMatrixRowsCount = firstMatrix.GetLength(0);
            int secondMatrixColsCount = secondMatrix.GetLength(1);
            double[,] result = new double[firstMatrixRowsCount, secondMatrixColsCount];
            for (int row = 0; row < firstMatrixRowsCount; row++)
            {
                for (int col = 0; col < secondMatrixColsCount; col++)
                {
                    for (int i = 0; i < firstMatrixColsCount; i++)
                    {
                        result[row, col] += firstMatrix[row, i] * secondMatrix[i, col];
                    }
                }
            }
            return result;
        }
    }
}
