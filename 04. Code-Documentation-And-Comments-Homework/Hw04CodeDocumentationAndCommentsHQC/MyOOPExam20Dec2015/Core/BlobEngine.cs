using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOOPExam20Dec2015.Interfaces;

namespace MyOOPExam20Dec2015.Core
{
    public class BlobEngine : IRunnable
    {
        private readonly IBlobFactory blobFactory;
        private readonly IAttackFactory attackFactory;
        private readonly IBehaviorFactory behaviorFactory;
        private readonly IData data;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public BlobEngine(IBlobFactory blobFactory, IAttackFactory attackFactory, IBehaviorFactory behaviorFactory,
            IData data, IInputReader reader, IOutputWriter writer)
        {
            this.blobFactory = blobFactory;
            this.attackFactory = attackFactory;
            this.behaviorFactory = behaviorFactory;
            this.data = data;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string[] input = this.reader.ReadLine().Split();
                ProcessCommand(input);
                UpdateBlobs();
            }
        }

        private void UpdateBlobs()
        {
            foreach (IBlob blob in this.data.Blobs.Values)
            {
                blob.Update();
            }
        }

        private void ProcessCommand(string[] input)
        {
            string command = input[0];
            switch (command)
            {
                case "pass":
                    break;
                case "create":
                    ExecuteCreateCommand(input);
                    break;
                case "attack":
                    ExecuteAttackCommand(input);
                    break;
                case "status":
                    ExecuteStatusCommand();
                    break;
                case "drop":
                    Environment.Exit(0);
                    break;
                default:
                    throw new ArgumentException("Unknown command");
            }
        }

        private void ExecuteStatusCommand()
        {
            foreach (IBlob blob in this.data.Blobs.Values)
            {
                this.writer.PrintLine(blob.ToString());
            }
        }

        private void ExecuteAttackCommand(string[] input)
        {
            if (input[1] == input[2])
            {
                throw new ArgumentException("Blobs cannot attack themselves.");
            }
            IBlob attackingBlob = this.data.GetBlob(input[1]);
            IBlob targetBlob = this.data.GetBlob(input[2]);
            int damageDone = attackingBlob.GetAttackDamage();
            targetBlob.RespondToAttack(damageDone);
        }

        private void ExecuteCreateCommand(string[] input)
        {
            string name = input[1];
            if (this.data.Blobs.ContainsKey(name))
            {
                throw new ArgumentException(string.Format("Blob with name {0} already exists.", name));
            }
            int health = int.Parse(input[2]);
            int damage = int.Parse(input[3]);
            string behaviorType = input[4];
            string attackType = input[5];
            IBlob blob = this.blobFactory.CreateBlob(name, health, damage,
                this.attackFactory, this.behaviorFactory, attackType, behaviorType);
            this.data.AddBlob(name, blob);
        }
    }
}
