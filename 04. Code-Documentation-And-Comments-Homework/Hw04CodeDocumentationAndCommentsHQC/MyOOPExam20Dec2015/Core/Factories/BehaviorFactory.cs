using System.Linq;
using System.Reflection;

namespace MyOOPExam20Dec2015.Core.Factories
{
    using System;
    using Interfaces;
    using Models.Behaviors;
    class BehaviorFactory : IBehaviorFactory
    {
        public IBehavior DefineBehavior(string behaviorType)
        {
//            switch (behaviorType)
//            {
//                case "Aggressive":
//                    return new Aggressive();
//                case "Inflated":
//                    return new Inflated();
//                default:
//                    throw new ArgumentException("Unknown behavior type.");
//            }

            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == behaviorType);
            if (type == null)
            {
                throw new ArgumentException("Unknown behavior type.");
            }
            var behavior = (IBehavior)Activator.CreateInstance(type);
            return behavior;
        }
    }
}
