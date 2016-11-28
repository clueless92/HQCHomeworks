namespace ACTS
{
    using ACTS.Core;
    using ACTS.Core.UI;
    using ACTS.Interfaces;

    public class Program
    {
        public static void Main()
        {
            IUserInterface userInterface = new ConsoleUserInterface();
            DataBase dataBase = new DataBase(); // TODO: extract interface

            var engine = new Engine(userInterface, dataBase);
            engine.Run();
        }
    }
}
