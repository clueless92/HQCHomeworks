namespace Pr01Logger.Loggers
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Interfaces;

    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = new List<IAppender>(appenders);
        }

        public IList<IAppender> Appenders { get; private set; }

        public void Info(string message)
        {
            this.Log(message, ReportLevel.Info);
        }

        public void Warn(string message)
        {
            this.Log(message, ReportLevel.Warn);
        }

        public void Error(string message)
        {
            this.Log(message, ReportLevel.Error);
        }

        public void Critical(string message)
        {
            this.Log(message, ReportLevel.Critical);
        }

        public void Fatal(string message)
        {
            this.Log(message, ReportLevel.Fatal);
        }

        private void Log(string message, ReportLevel reportLevel)
        {
            DateTime date = DateTime.Now;
            foreach (IAppender appender in this.Appenders)
            {
                appender.Append(message, reportLevel, date);
            }
        }
    }
}
