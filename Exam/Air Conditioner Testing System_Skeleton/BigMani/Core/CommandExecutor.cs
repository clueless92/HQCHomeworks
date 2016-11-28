namespace ACTS.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using ACTS.Exceptions;
    using ACTS.Models;
    using ACTS.Models.AirConditioners;
    using ACTS.Utils;

    public class CommandExecutor
    {
        private readonly Engine engine;

        public CommandExecutor(Engine engine)
        {
            this.engine = engine;
        }

        public string ExecuteCommand()
        {
            var command = this.engine.Command;
            string output;
            try
            {
                switch (command.Name)
                {
                    case "RegisterStationaryAirConditioner":
                        this.ValidateParametersCount(command, 4);
                        output = this.RegisterStationaryAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            (EnergyRating)Enum.Parse(typeof(EnergyRating), command.Parameters[2]),
                            int.Parse(command.Parameters[3]));
                        break;
                    case "RegisterCarAirConditioner":
                        this.ValidateParametersCount(command, 3);
                        output = this.RegisterCarAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]));
                        break;
                    case "RegisterPlaneAirConditioner":
                        this.ValidateParametersCount(command, 4);
                        output = this.RegisterPlaneAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]),
                            int.Parse(command.Parameters[3]));
                        break;
                    case "TestAirConditioner":
                        this.ValidateParametersCount(command, 2);
                        output = this.TestAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]);
                        break;
                    case "FindAirConditioner":
                        this.ValidateParametersCount(command, 2);
                        //// BUG: paramteres were swapped - FIXED
                        output = this.FindAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]);
                        break;
                    case "FindReport":
                        this.ValidateParametersCount(command, 2);
                        output = this.FindReport(
                            command.Parameters[0],
                            command.Parameters[1]);
                        break;
                    case "FindAllReportsByManufacturer":
                        this.ValidateParametersCount(command, 1);
                        output = this.FindAllReportsByManufacturer(
                            command.Parameters[0]);
                        break;
                    case "Status":
                        this.ValidateParametersCount(command, 0);
                        output = this.Status();
                        break;
                    default:
                        throw new InvalidOperationException(Constants.InvalidCommand);
                }
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException(Constants.InvalidCommand, ex.InnerException);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(Constants.InvalidCommand, ex.InnerException);
            }

            return output;
        }

        /// <summary>
        /// Gets the ratio between tested and not tested ACs in the database.
        /// </summary>
        /// <returns>The string representation of the ratio.</returns>
        public string Status()
        {
            int reports = this.engine.DataBase.GetReportsCount();
            double airConditioners = this.engine.DataBase.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;
            return string.Format(Constants.StatusMessage, percent);
        }

        public string RegisterStationaryAirConditioner(
            string manufacturer,
            string model,
            EnergyRating energyEfficiencyRating,
            int powerUsage)
        {
            AirConditioner airConditioner = new StationaryAirConditioner(
                manufacturer,
                model,
                energyEfficiencyRating,
                powerUsage);

            if (this.engine.DataBase.ContainsAirConditioner(manufacturer, model))
            {
                throw new DuplicateEntryException(Constants.DuplicateEntryMessage);
            }

            this.engine.DataBase.AddAirConditioner(airConditioner);

            return string.Format(
                Constants.RegisterMessage,
                airConditioner.Model,
                airConditioner.Manufacturer);
        }

        public string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            AirConditioner airConditioner = new CarAirConditioner(manufacturer, model, volumeCoverage);

            if (this.engine.DataBase.ContainsAirConditioner(manufacturer, model))
            {
                throw new DuplicateEntryException(Constants.DuplicateEntryMessage);
            }

            this.engine.DataBase.AddAirConditioner(airConditioner);

            return string.Format(
                Constants.RegisterMessage,
                airConditioner.Model,
                airConditioner.Manufacturer);
        }

        /// <summary>
        /// Registers a plane air conditioner (PAC) in the database with given params.
        /// </summary>
        /// <param name="manufacturer">Manufacturer of the PAC.</param>
        /// <param name="model">Model of the PAC.</param>
        /// <param name="volumeCoverage">Volume coverage of the PAC.</param>
        /// <param name="electricityUsed">Electricity used of the PAC.</param>
        /// <returns>String message indicating whether AC was registered succesfully or not.</returns>
        public string RegisterPlaneAirConditioner(
            string manufacturer,
            string model,
            int volumeCoverage,
            int electricityUsed)
        {
            AirConditioner airConditioner = 
                new PlaneAirConditioner(manufacturer, model, volumeCoverage, electricityUsed);

            if (this.engine.DataBase.ContainsAirConditioner(manufacturer, model))
            {
                throw new DuplicateEntryException(Constants.DuplicateEntryMessage);
            }

            this.engine.DataBase.AddAirConditioner(airConditioner);

            return string.Format(
                Constants.RegisterMessage,
                airConditioner.Model,
                airConditioner.Manufacturer);
        }

        public string TestAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.engine.DataBase.GetAirConditioner(manufacturer, model);
            if (airConditioner == null)
            {
                throw new NonExistantEntryException(Constants.NonExistantEntryMessage);
            }

            ///airConditioner.energyRating += 5; // BUG: this is not required
            var mark = airConditioner.Test();
            var report = new Report(airConditioner.Manufacturer, airConditioner.Model, mark);
            if (this.engine.DataBase.ContainsReport(manufacturer, model))
            {
                throw new DuplicateEntryException(Constants.DuplicateEntryMessage);
            }

            this.engine.DataBase.AddReport(report);
            return string.Format(Constants.TestMessage, manufacturer, model);
        }

        /// <summary>
        /// Gets a string representing an AC from the Database.
        /// </summary>
        /// <param name="manufacturer">Manufacturer of AC.</param>
        /// <param name="model">Model of AC.</param>
        /// <returns>String representation of AC.</returns>
        public string FindAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.engine.DataBase.GetAirConditioner(manufacturer, model);

            if (airConditioner == null)
            {
                throw new NonExistantEntryException(Constants.NonExistantEntryMessage);
            }

            return airConditioner.ToString();
        }

        public string FindReport(string manufacturer, string model)
        {
            Report report = this.engine.DataBase.GetReport(manufacturer, model);

            if (report == null)
            {
                throw new NonExistantEntryException(Constants.NonExistantEntryMessage);
            }

            return report.ToString();
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            List<Report> reports = this.engine.DataBase.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                return Constants.NoReports;
            }

            // BUG: ordering was by Mark - FIXED to Model
            reports = reports.OrderBy(x => x.Model).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            return reportsPrint.ToString();
        }

        private void ValidateParametersCount(Command command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException(Constants.InvalidCommand);
            }
        }
    }
}
