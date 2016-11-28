namespace ACTSTests
{
    using ACTS.Core;
    using ACTS.Core.UI;
    using ACTS.Interfaces;
    using ACTS.Models;
    using ACTS.Models.AirConditioners;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindAllReportsByManufacturerTests
    {
        public CommandExecutor CommandExecutor;

        [TestInitialize]
        public void Initialize()
        {
            IUserInterface userInterface = new ConsoleUserInterface();
            DataBase dataBase = new DataBase(); // TODO: extract interface

            var engine = new Engine(userInterface, dataBase);
            this.CommandExecutor = new CommandExecutor(engine);
        }

        [TestMethod]
        public void TestEmptyReportList_ExpectNoReports()
        {
            const string expected = "No reports.";
            string actual = this.CommandExecutor.FindAllReportsByManufacturer("Manuf");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReportListWithOneItem_ExpectSuccess()
        {
            const string expected = @"Reports from Manuf:
Report
====================
Manufacturer: Manuf
Model: Model
Mark: Passed
====================";

            AirConditioner ac1 = new StationaryAirConditioner("Manuf", "Model", EnergyRating.C, 1000);
            this.CommandExecutor.RegisterStationaryAirConditioner("Manuf", "Model", EnergyRating.C, 1000);
            this.CommandExecutor.TestAirConditioner("Manuf", "Model");
            string actual = this.CommandExecutor.FindAllReportsByManufacturer("Manuf");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReportListWithTwoItems_CheckForRightOrder_ExpectSuccess()
        {
            const string expected = @"Reports from Manuf:
Report
====================
Manufacturer: Manuf
Model: Model
Mark: Passed
====================
Report
====================
Manufacturer: Manuf
Model: ModelXL
Mark: Failed
====================";

            AirConditioner ac1 = new StationaryAirConditioner("Manuf", "Model", EnergyRating.C, 1000);
            this.CommandExecutor.RegisterStationaryAirConditioner("Manuf", "Model", EnergyRating.C, 1000);
            this.CommandExecutor.RegisterStationaryAirConditioner("Manuf", "ModelXL", EnergyRating.C, 9000);
            this.CommandExecutor.TestAirConditioner("Manuf", "Model");
            this.CommandExecutor.TestAirConditioner("Manuf", "ModelXL");
            string actual = this.CommandExecutor.FindAllReportsByManufacturer("Manuf");

            Assert.AreEqual(expected, actual);
        }


    }
}
