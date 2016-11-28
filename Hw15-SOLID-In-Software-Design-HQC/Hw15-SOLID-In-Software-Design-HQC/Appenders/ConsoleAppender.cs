namespace Pr01Logger.Appenders
{
    using System;
    using Enums;
    using Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string message, ReportLevel reportLevel, DateTime date)
        {
            if (this.ReportTreshold > reportLevel)
            {
                return;
            }

            string formattedLog = this.Layout.FormatLog(message, reportLevel, date);
            Console.WriteLine(formattedLog);
        }
    }
}
