namespace ACTS.Models.AirConditioners
{
    using System;
    using ACTS.Utils;

    public abstract class AirConditioner
    {
        private string manufacturer;
        private string model;

        protected AirConditioner(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.ManufacturerMinLength)
                {
                    throw new ArgumentException(string.Format(
                        Constants.IncorrectPropertyLength,
                        "Manufacturer",
                        Constants.ManufacturerMinLength));
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.ModelMinLength)
                {
                    throw new ArgumentException(string.Format(
                        Constants.IncorrectPropertyLength,
                        "Model", 
                        Constants.ModelMinLength));
                }

                this.model = value;
            }
        }

        public abstract bool Test();

        public override string ToString()
        {
            string print = string.Format(
                "Air Conditioner{0}{1}{0}Manufacturer: {2}{0}Model: {3}{0}",
                Environment.NewLine,
                Constants.Border,
                this.Manufacturer,
                this.Model);

            return print;
        }
    }
}
