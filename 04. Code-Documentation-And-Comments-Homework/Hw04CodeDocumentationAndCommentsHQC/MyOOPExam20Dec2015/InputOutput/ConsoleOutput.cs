namespace MyOOPExam20Dec2015.InputOutput
{
    using System;
    using Interfaces;
    public class ConsoleOutput : IOutputWriter
    {
        public void PrintLine(string output)
        {
            Console.WriteLine(output);
        }

        public void Print(string output)
        {
            Console.Write(output);
        }
    }
}
