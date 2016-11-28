namespace ACTSTests
{
    using System;
    using System.Collections.Generic;
    using ACTS.Core;
    using ACTS.Core.UI;
    using ACTS.Exceptions;
    using ACTS.Interfaces;
    using ACTS.Models;
    using ACTS.Models.AirConditioners;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RegisterStationaryAirConditionerTests
    {
        public CommandExecutor CommandExecutor;

        [TestInitialize]
        public void Initialize()
        {
            IUserInterface userInterface = new ConsoleUserInterface();
            DataBase dataBase = new DataBase(); // TODO: extract interface
            dataBase.Reports = new List<Report>();

            var engine = new Engine(userInterface, dataBase);
            this.CommandExecutor = new CommandExecutor(engine);
        }

        [TestMethod]
        public void Test_ValidParams_ExpectSuccess()
        {
            const string expected = "Air Conditioner model Model from Manuf registered successfully.";
            string actual = this.CommandExecutor.RegisterStationaryAirConditioner(
                "Manuf", "Model", EnergyRating.C, 1000);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_InvalidManufacturer_ExpectArgumentException()
        {
            this.CommandExecutor.RegisterStationaryAirConditioner(
                "Man", "Model", EnergyRating.C, 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_InvalidModel_ExpectArgumentException()
        {
            this.CommandExecutor.RegisterStationaryAirConditioner(
                "Manuf", "M", EnergyRating.C, 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_InvalidPower_ExpectArgumentException()
        {
            this.CommandExecutor.RegisterStationaryAirConditioner(
                "Manuf", "Model", EnergyRating.C, -1000);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEntryException))]
        public void Test_InvalidPower_ExpectDuplicateEntryException()
        {
            this.CommandExecutor.RegisterStationaryAirConditioner(
                "Manuf", "Model", EnergyRating.C, 1000);

            this.CommandExecutor.RegisterStationaryAirConditioner(
                "Manuf", "Model", EnergyRating.C, 1000);
        }
    }
}
