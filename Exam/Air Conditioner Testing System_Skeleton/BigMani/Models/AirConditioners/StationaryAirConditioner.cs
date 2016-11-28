namespace ACTS.Models.AirConditioners
{
    using System;
    using ACTS.Utils;

    public class StationaryAirConditioner : AirConditioner
    {
        private int powerUsage;

        public StationaryAirConditioner(string manufacturer, string model, EnergyRating energyRating, int powerUsage)
            : base(manufacturer, model)
        {
            this.EnergyRating = energyRating;
            this.PowerUsage = powerUsage;
        }

        public EnergyRating EnergyRating { get; private set; }

        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(
                        Constants.NonPositiveMessage,
                        "Power Usage"));
                }

                this.powerUsage = value;
            }
        }

        public override bool Test()
        {
            if (this.PowerUsage <= (int)this.EnergyRating)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            string print = string.Format(
                "Required energy efficiency rating: {0}{1}Power Usage(KW / h): {2}{1}{3}",
                this.EnergyRating,
                Environment.NewLine,
                this.PowerUsage,
                Constants.Border);

            return base.ToString() + print;
        }
    }
}
