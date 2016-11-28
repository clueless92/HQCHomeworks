namespace ACTS.Models.AirConditioners
{
    using System;
    using ACTS.Utils;

    public class PlaneAirConditioner : AirConditioner
    {
        private int electricityUsage;
        private int volumeCoverage;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCoverage, int electricityUsage)
            : base(manufacturer, model)
        {
            this.VolumeCoverage = volumeCoverage;
            this.ElectricityUsage = electricityUsage;
        }

        public int ElectricityUsage
        {
            get
            {
                return this.electricityUsage;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(
                        Constants.NonPositiveMessage,
                        "Electricity Used"));
                }

                this.electricityUsage = value;
            }
        }

        public int VolumeCoverage
        {
            get
            {
                return this.volumeCoverage;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(
                        Constants.NonPositiveMessage,
                        "Volume Covered"));
                }

                this.volumeCoverage = value;
            }
        }

        public override bool Test()
        {
            double sqrtVolume = Math.Sqrt(this.VolumeCoverage);
            if (this.ElectricityUsage / sqrtVolume < Constants.MinPlaneElectricity)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            string print = string.Format(
                "Volume Covered: {0}{1}Electricity Used: {2}{1}{3}",
                this.VolumeCoverage,
                Environment.NewLine,
                this.ElectricityUsage,
                Constants.Border);

            return base.ToString() + print;
        }
    }
}
