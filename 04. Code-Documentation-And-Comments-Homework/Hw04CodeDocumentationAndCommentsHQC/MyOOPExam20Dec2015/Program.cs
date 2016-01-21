using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOOPExam20Dec2015.Core;
using MyOOPExam20Dec2015.Core.Factories;
using MyOOPExam20Dec2015.InputOutput;
using MyOOPExam20Dec2015.Interfaces;

namespace MyOOPExam20Dec2015
{
    class Program
    {
        static void Main(string[] args)
        {
            IBlobFactory blobFactory = new BlobFactory();
            IAttackFactory attackFactory = new AttackFactory();
            IBehaviorFactory behaviorFactory = new BehaviorFactory();
            IData blobData = new BlobData();
            IInputReader scanner = new ConsoleInput();
            IOutputWriter printer = new ConsoleOutput();
            IRunnable blobEngine = new BlobEngine(blobFactory, attackFactory, behaviorFactory, blobData, scanner, printer);
            blobEngine.Run();
        }
    }
}
