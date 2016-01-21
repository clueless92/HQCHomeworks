using System;
using System.Globalization;

namespace Methods
{
    class Student
    {
        private string firstName;
        private string lastName;

        public Student(string firstName,
            string lastName,
            string birthDate,
            string homeTown = null,
            string mainInterest = null,
            string results = "Average")
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = DateTime.Parse(birthDate, CultureInfo.CreateSpecificCulture("bg-BG"));
            this.MainInterest = mainInterest;
            this.HomeTown = homeTown;
            this.Results = results;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name cannot be null or whitespace.");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name cannot be null or whitespace.");
                }
                this.lastName = value;
            }
        }

        public DateTime BirthDate { get; set; }

        public string MainInterest { get; set; }

        public string HomeTown { get; set; }

        public string Results { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = this.BirthDate;
            DateTime secondDate = other.BirthDate;
            return firstDate.CompareTo(secondDate) < 0;
        }
    }
}
