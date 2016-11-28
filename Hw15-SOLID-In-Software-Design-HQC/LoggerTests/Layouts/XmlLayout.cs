namespace EndUserProject.Layouts
{
    using System;
    using Pr01Logger.Enums;
    using Pr01Logger.Interfaces;

    public class XmlLayout : ILayout
    {
        private const string XmlLayoutFormat =
            "<log>{0}{4}<date>{1}</date>{0}{4}<level>{2}</level>{0}{4}<message>{3}</message>{0}</log>";

        private static readonly string Offset = new string(' ', 3);

        public string FormatLog(string message, ReportLevel reportLevel, DateTime date)
        {
            string output = string.Format(
                XmlLayoutFormat,
                Environment.NewLine,
                date.ToString("m/d/yyyy h:mm:ss tt"),
                reportLevel,
                message,
                Offset);

            return output;
        }
    }
}
