namespace Pr01Logger.Interfaces
{
    using System;
    using Enums;

    public interface IAppender
    {
        ReportLevel ReportTreshold { get; set; }

        ILayout Layout { get; }

        void Append(string message, ReportLevel reportLevel, DateTime date);
    }
}
