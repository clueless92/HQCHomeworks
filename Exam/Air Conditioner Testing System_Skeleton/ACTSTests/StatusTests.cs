namespace ACTSTests
{
    using ACTS.Core;
    using ACTS.Core.UI;
    using ACTS.Interfaces;
    using ACTS.Models.AirConditioners;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StatusTests
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
        public void TestNoReports_ExpectZero()
        {
            const string expected = "Jobs complete: 0.00%";
            this.CommandExecutor.RegisterStationaryAirConditioner("Manuf", "Model", EnergyRating.C, 1000);
            string actual = this.CommandExecutor.Status();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTwoReportsThreeACs_ExpectSuccess()
        {
            const string expected = "Jobs complete: 66.67%";
            this.CommandExecutor.RegisterStationaryAirConditioner("Manuf", "Model", EnergyRating.C, 1000);
            this.CommandExecutor.RegisterStationaryAirConditioner("Manuf", "Model1", EnergyRating.C, 1000);
            this.CommandExecutor.RegisterStationaryAirConditioner("Manuf", "Model2", EnergyRating.C, 1000);
            this.CommandExecutor.TestAirConditioner("Manuf", "Model");
            this.CommandExecutor.TestAirConditioner("Manuf", "Model2");
            string actual = this.CommandExecutor.Status();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOneReportTwoACs_ExpectSuccess()
        {
            const string expected = "Jobs complete: 50.00%";
            this.CommandExecutor.RegisterStationaryAirConditioner("Manuf", "Model", EnergyRating.C, 1000);
            this.CommandExecutor.RegisterStationaryAirConditioner("Manuf", "Model1", EnergyRating.C, 1000);
            this.CommandExecutor.TestAirConditioner("Manuf", "Model");
            string actual = this.CommandExecutor.Status();

            Assert.AreEqual(expected, actual);
        }
    }
}
