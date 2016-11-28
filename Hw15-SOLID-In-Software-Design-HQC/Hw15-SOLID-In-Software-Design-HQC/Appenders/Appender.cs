namespace Pr01Logger.Appenders
{
    using System;
    using Enums;
    using Interfaces;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ReportLevel ReportTreshold { get; set; }

        public ILayout Layout { get; private set; }

        public abstract void Append(string message, ReportLevel reportLevel, DateTime date);
    }
}
