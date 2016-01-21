//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//
//namespace BigSum
//{
//    // Task:
//    // You are given 2 whole numbers (radix = 10), each one can be from 0 to 10^145.
//    // Print their sum.
//    // Don't use BigInteger.
//
//    class BigSum
//    {
//        static void Main(string[] args)
//        {
//            string shortNum = Console.ReadLine();
//            string longNum = Console.ReadLine();
//            if (shortNum.Length > longNum.Length)
//            {
//                string swap = shortNum;
//                shortNum = longNum;
//                longNum = swap;
//            }
//            int longIndex = longNum.Length - 1;
//            int shortIndex = shortNum.Length - 1;
//            int sumIndex = longNum.Length;
//            int[] sum = new int[sumIndex + 1];
//            int surplus = 0;
//            while (shortIndex >= 0)
//            {
//                int shortDigit = shortNum[shortIndex] - '0';
//                int longDigit = longNum[longIndex] - '0';
//                sum[sumIndex] = shortDigit + longDigit + surplus;
//                surplus = sum[sumIndex] / 10;
//                sum[sumIndex] %= 10;
//                shortIndex--;
//                longIndex--;
//                sumIndex--;
//            }
//            while (longIndex >= 0)
//            {
//                int longDigit = longNum[longIndex] - '0';
//                sum[sumIndex] = longDigit + surplus;
//                surplus = sum[sumIndex] / 10;
//                sum[sumIndex] %= 10;
//                longIndex--;
//                sumIndex--;
//            }
//            sum[0] = surplus;
//            int sumLastIndex = sum.Length - 1;
//            for (; sumIndex < sumLastIndex; sumIndex++)
//            {
//                if (sum[sumIndex] != 0)
//                    break;
//            }
//            for (; sumIndex < sum.Length; sumIndex++)
//            {
//                Console.Write(sum[sumIndex]);
//            }
//            Console.WriteLine();
//        }
//    }
//}
