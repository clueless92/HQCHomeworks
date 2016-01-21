using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyOOPExam20Dec2015.Interfaces;

namespace MyOOPExam20Dec2015.Models
{
    public class Blob : IBlob
    {
        private const int DeffaultConcecutiveBehaviorDeley = 2;

        private bool hasTriggeredBehavior;
        private int concecutiveBehaviorDeley;
        private readonly int initialHealth;
        private readonly int initialDamage;

        private string name;
        private int health;
        private int damage;

        private readonly IAttackFactory attackFactory;
        private readonly IBehaviorFactory behaviorFactory;

        private IAttack attack;
        private IBehavior behavior;

        public Blob(string name, int health, int damage, 
            IAttackFactory attackFactory, IBehaviorFactory behaviorFactory, 
            string attackType, string behaviorType)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;

            this.attackFactory = attackFactory;
            this.behaviorFactory = behaviorFactory;

            this.attack = this.attackFactory.DefineAttack(attackType);
            this.behavior = this.behaviorFactory.DefineBehavior(behaviorType);

            this.initialHealth = health;
            this.initialDamage = damage;

            this.hasTriggeredBehavior = false;
            this.concecutiveBehaviorDeley = DeffaultConcecutiveBehaviorDeley;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Name cannot be null or whitespace.");
                }
                this.name = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            private set
            {
//                if (value <= 0)
//                {
//                    throw new ArgumentOutOfRangeException("health", "Initial health should be positive.");
//                }
                this.health = value;
            }
        }

        public int Damage
        {
            get { return this.damage; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("damage", "Initial damage should be positive.");
                }
                this.damage = value;
            }
        }

//        private bool IsOdd(int n)
//        {
//            bool result = n % 2 == 1;
//            return result;
//        }

        public int GetAttackDamage()
        {
//            int adder = 0;
//            if (IsOdd(this.Health))
//            {
//                adder = 1;
//            }
            this.Health = (this.Health / this.attack.Modifier); //+ adder; // fix this to -= Health / 2
            this.AttemptToTriggerInitialBehavior();
            int currentAttackDamage = this.Damage * this.attack.Modifier;
            //RespondToAttack(currentAttackDamage);
            return currentAttackDamage;
        }

        public void RespondToAttack(int damageTaken)
        {
            this.Health -= damageTaken;
            this.AttemptToTriggerInitialBehavior();
        }

        public void Update()
        {
            this.AttemptToTriggerInitialBehavior();
            this.AttemptToTriggerConsecutiveBehavior();
        }
        
        protected virtual void AttemptToTriggerConsecutiveBehavior()
        {
            if (this.hasTriggeredBehavior)
            {
                if (this.concecutiveBehaviorDeley == 0)
                {
                    int[] newStats = this.behavior.ConsecutiveBehavior(this.Health, this.Damage);
                    this.Health = newStats[0];
                    this.Damage = newStats[1];
                }
                if (this.concecutiveBehaviorDeley == 1)
                {
                    this.concecutiveBehaviorDeley--;
                }
            }
        }

        protected virtual void AttemptToTriggerInitialBehavior()
        {
            if (this.hasTriggeredBehavior)
            {
                return;
            }
            if (this.Health <= this.initialHealth / 2)
            {
                int[] newStats = this.behavior.InnitialBehavior(this.Health, this.Damage);
                this.Health = newStats[0];
                this.Damage = newStats[1];
                this.hasTriggeredBehavior = true;
                this.concecutiveBehaviorDeley--;
            }
        }

        public override string ToString()
        {
            string info;
            if (this.Health <= 0 && this.hasTriggeredBehavior)
            {
                info = string.Format("Blob {0} KILLED", this.Name);
            }
            else
            {
                info = string.Format("Blob {0}: {1} HP, {2} Damage", this.Name, this.Health, this.Damage);
            }
            return info;
        }
    }
}
