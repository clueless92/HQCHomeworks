namespace ACTS.Models.AirConditioners
{
    using System;
    using ACTS.Utils;

    public class CarAirConditioner : AirConditioner
    {
        private int volumeCoverage;

        public CarAirConditioner(string manufacturer, string model, int volumeCoverage)
            : base(manufacturer, model)
        {
            this.VolumeCoverage = volumeCoverage;
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
            if (sqrtVolume < Constants.MinCarVolume)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            string print = string.Format(
                "Volume Covered: {0}{1}{2}",
                this.VolumeCoverage,
                Environment.NewLine,
                Constants.Border);

            return base.ToString() + print;
        }
    }
}
