namespace MyOOPExam20Dec2015.Interfaces
{
    /// <summary>
    /// Defines public members of classes that implement it.
    /// </summary>
    public interface IBlobFactory
    {
        /// <summary>
        /// Encapsulates creation of new IBlob.
        /// </summary>
        /// <param name="name">String name.</param>
        /// <param name="health">Int32 health.</param>
        /// <param name="damage">Int32 damage.</param>
        /// <param name="attackFactory">IAttackFactory.</param>
        /// <param name="behaviorFactory">IBehaviorFactory.</param>
        /// <param name="attackType">String attack type.</param>
        /// <param name="behaviorType">String behavior type.</param>
        /// <returns>new IBlob.</returns>
        IBlob CreateBlob(string name, int health, int damage,
            IAttackFactory attackFactory, IBehaviorFactory behaviorFactory,
            string attackType, string behaviorType);
    }
}
