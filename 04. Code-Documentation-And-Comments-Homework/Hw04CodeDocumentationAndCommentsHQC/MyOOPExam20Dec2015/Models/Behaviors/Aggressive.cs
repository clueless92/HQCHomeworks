namespace MyOOPExam20Dec2015.Models.Behaviors
{
    using Interfaces;
    class Aggressive : IBehavior
    {
        private int initialDamage;
        public Aggressive()
        {
            this.initialDamage = -1;
        }

        public int[] InnitialBehavior(int health, int damage)
        {
            int[] stats = new int[2];
            stats[0] = health;
            stats[1] = damage * 2;
            return stats;
        }

        public int[] ConsecutiveBehavior(int health, int damage)
        {
            if (this.initialDamage == -1)
            {
                this.initialDamage = damage / 2;
            }
            int[] stats = new int[2];
            stats[0] = health;
            if (damage > this.initialDamage)
            {
                stats[1] = damage - 5;
            }
            else
            {
                stats[1] = damage;
            }
            return stats;
        }
    }
}
