namespace Pr01Logger.Interfaces
{
    using System;
    using Enums;

    public interface ILayout
    {
        string FormatLog(string message, ReportLevel reportLevel, DateTime date);
    }
}
