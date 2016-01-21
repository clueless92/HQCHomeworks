namespace MyOOPExam20Dec2015.InputOutput
{
    using System;
    using Interfaces;
    public class ConsoleInput : IInputReader
    {
        public string ReadLine()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
