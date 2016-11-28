namespace ACTS.Core
{
    using System;
    using ACTS.Interfaces;

    public class Engine
    {
        private readonly CommandExecutor commandExecutor;

        private readonly IUserInterface userUnterface;

        public Engine(IUserInterface userInterface, DataBase dataBase)
        {
            this.commandExecutor = new CommandExecutor(this);
            this.userUnterface = userInterface;
            this.DataBase = dataBase;
        }

        public DataBase DataBase { get; set; }

        public Command Command { get; set; }

        public void Run()
        {
            while (true)
            {
                string line = this.userUnterface.ReadLine();
                string output;
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    this.Command = new Command(line);
                    output = this.commandExecutor.ExecuteCommand();
                }
                catch (Exception ex)
                {
                    output = ex.Message;
                }

                this.userUnterface.WriteLine(output);
            }
        }
    }
}
