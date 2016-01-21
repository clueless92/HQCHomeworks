using System.Linq;
using System.Reflection;

namespace MyOOPExam20Dec2015.Core.Factories
{
    using System;
    using Interfaces;
    using Models.Attacks;
    public class AttackFactory : IAttackFactory
    {
        public IAttack DefineAttack(string attackType)
        {
//            switch (attackType)
//            {
//                case "Blobplode":
//                    return new Blobplode();
//                case "PutridFart":
//                    return new PutridFart();
//                default:
//                    throw new ArgumentException("Unknown attack type.");
//            }

            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == attackType);
            if (type == null)
            {
                throw new ArgumentException("Unknown attack type.");
            }
            var attack = (IAttack)Activator.CreateInstance(type);
            return attack;
        }
    }
}
