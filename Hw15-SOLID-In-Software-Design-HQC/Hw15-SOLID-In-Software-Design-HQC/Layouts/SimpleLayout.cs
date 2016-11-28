namespace Pr01Logger.Layouts
{
    using System;
    using Enums;
    using Interfaces;

    public class SimpleLayout : ILayout
    {
        private const string SimpleLayoutFormat = "{0} - {1} - {2}";

        public string FormatLog(string message, ReportLevel reportLevel, DateTime date)
        {
            string output = string.Format(
                SimpleLayoutFormat,
                date.ToString("M/d/yyyy h:mm:ss tt"),
                reportLevel,
                message);

            return output;
        }
    }
}
