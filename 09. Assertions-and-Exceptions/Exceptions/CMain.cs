namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;

    public class CMain
    {
        private static void Main()
        {
            var substr = Exceptions.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Exceptions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Exceptions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = Exceptions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));

            Console.WriteLine(Exceptions.ExtractEnding("I love C#", 2));
            Console.WriteLine(Exceptions.ExtractEnding("Nakov", 4));
            Console.WriteLine(Exceptions.ExtractEnding("beer", 4));
            //// Console.WriteLine(ExtractEnding("Hi", 100));

            Console.WriteLine("23 is {0}.", Exceptions.CheckPrime(23) ? "prime" : "not prime");
            Console.WriteLine("33 is {0}.", Exceptions.CheckPrime(23) ? "prime" : "not prime");

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
