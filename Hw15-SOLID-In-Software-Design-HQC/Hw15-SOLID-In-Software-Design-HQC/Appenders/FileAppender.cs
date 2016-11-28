namespace Pr01Logger.Appenders
{
    using System;
    using System.IO;
    using Enums;
    using Interfaces;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, string filePath) : base(layout)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; set; }

        public override void Append(string message, ReportLevel reportLevel, DateTime date)
        {
            if (this.ReportTreshold > reportLevel)
            {
                return;
            }

            using (FileStream fs = new FileStream(this.FilePath, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    string formattedLog = this.Layout.FormatLog(message, reportLevel, date);
                    sw.WriteLineAsync(formattedLog);
                }
            }
        }
    }
}
