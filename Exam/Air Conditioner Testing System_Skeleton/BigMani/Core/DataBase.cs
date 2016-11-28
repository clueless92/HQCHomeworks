namespace ACTS.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using ACTS.Models;
    using ACTS.Models.AirConditioners;

    public class DataBase
    {
        public DataBase()
        {
            this.AirConditioners = new List<AirConditioner>();
            this.Reports = new List<Report>();
        }

        public List<AirConditioner> AirConditioners { get; set; }

        public List<Report> Reports { get;  set; }

        public void AddAirConditioner(AirConditioner airConditioner)
        {
            this.AirConditioners.Add(airConditioner);
        }

        public void RemoveAirConditioner(AirConditioner airConditioner)
        {
            this.AirConditioners.Remove(airConditioner);
        }

        public AirConditioner GetAirConditioner(string manufacturer, string model)
        {
            // BUG: possible bottleneck - redundant where call - FIXED
            AirConditioner airConditioner = this.AirConditioners.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            return airConditioner;
        }

        public int GetAirConditionersCount()
        {
            return this.AirConditioners.Count;
        }

        public void AddReport(Report report)
        {
            this.Reports.Add(report);
        }

        public void RemoveReport(Report report)
        {
            this.Reports.Remove(report);
        }

        public Report GetReport(string manufacturer, string model)
        {
            // BUG: possible bottleneck - redundant where call - FIXED
            return this.Reports.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int GetReportsCount()
        {
            return this.Reports.Count;
        }

        public List<Report> GetReportsByManufacturer(string manufacturer)
        {
            return this.Reports.Where(x => x.Manufacturer == manufacturer).ToList();
        }

        public bool ContainsAirConditioner(string manufacturer, string model)
        {
            return this.AirConditioners.Contains(this.GetAirConditioner(manufacturer, model));
        }

        public bool ContainsReport(string manufacturer, string model)
        {
            return this.Reports.Contains(this.GetReport(manufacturer, model));
        }
    }
}
