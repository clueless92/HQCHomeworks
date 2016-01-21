namespace MyOOPExam20Dec2015.Models.Behaviors
{
    using System;
    using Interfaces;
    public class Inflated : IBehavior
    {
        public Inflated()
        {
        }

        public int[] InnitialBehavior(int health, int damage)
        {
            int[] stats = new int[2];
            if (health <= 0)
            {
                stats[0] = 50;
            }
            else
            {
                stats[0] = health + 50;
            }
            stats[1] = damage;
            return stats;
        }

        public int[] ConsecutiveBehavior(int health, int damage)
        {
            int[] stats = new int[2];
            stats[0] = health - 10;
            stats[1] = damage;
            return stats;
        }
    }
}
