namespace ACTS.Models
{
    using System;
    using ACTS.Utils;

    public class Report
    {
        public Report(string manufacturer, string model, bool mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public bool Mark { get; set; }

        public override string ToString()
        {
            string result;
            if (this.Mark)
            {
                result = "Passed";
            }
            else
            {
                result = "Failed";
            }

            string output = string.Format(
                "Report{0}{1}{0}Manufacturer: {2}{0}Model: {3}{0}Mark: {4}{0}{1}",
                Environment.NewLine,
                Constants.Border,
                this.Manufacturer,
                this.Model,
                result);

            return output;
        }
    }
}
