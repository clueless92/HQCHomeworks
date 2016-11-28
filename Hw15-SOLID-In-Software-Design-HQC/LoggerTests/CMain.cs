namespace EndUserProject
{
    using Layouts;
    using Pr01Logger.Appenders;
    using Pr01Logger.Enums;
    using Pr01Logger.Interfaces;
    using Pr01Logger.Layouts;
    using Pr01Logger.Loggers;

    public class CMain
    {
        private static void Main()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportTreshold = ReportLevel.Error;
            ILayout xmlLayout = new XmlLayout();
            IAppender fileAppender = new FileAppender(xmlLayout, "..\\..\\Log.txt");
            ILogger logger = new Logger(consoleAppender, fileAppender);

            logger.Info("Everything seems fine");
            logger.Warn("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }
    }
}
