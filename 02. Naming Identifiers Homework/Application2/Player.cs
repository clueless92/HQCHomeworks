namespace Minesweeper
{
    using System;

    public class Player
    {
        private string name;
        private int points;

        public Player(string name = "Anonymous", int points = 0)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Name cannot be null or whitespace.");
                }
                name = value;
            }
        }

        public int Points
        {
            get { return points; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("points", "Points cannot be negative.");
                }
                points = value;
            }
        }
    }
}
