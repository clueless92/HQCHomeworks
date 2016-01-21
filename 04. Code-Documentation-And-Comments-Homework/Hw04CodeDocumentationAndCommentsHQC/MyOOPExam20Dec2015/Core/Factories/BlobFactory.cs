namespace MyOOPExam20Dec2015.Core.Factories
{
    using Interfaces;
    using Models;
    public class BlobFactory : IBlobFactory
    {
        public IBlob CreateBlob(string name, int health, int damage, IAttackFactory attackFactory, IBehaviorFactory behaviorFactory,
            string attackType, string behaviorType)
        {
            IBlob blob = new Blob(name, health, damage, attackFactory, behaviorFactory, attackType, behaviorType);
            return blob;
        }
    }
}
