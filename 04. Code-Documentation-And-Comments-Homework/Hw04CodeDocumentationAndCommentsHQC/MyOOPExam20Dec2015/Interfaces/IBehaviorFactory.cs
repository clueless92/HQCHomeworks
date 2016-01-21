namespace MyOOPExam20Dec2015.Interfaces
{
    /// <summary>
    /// Defines public members of classes that implement it.
    /// </summary>
    public interface IBehaviorFactory
    {
        /// <summary>
        /// Encapsulates creation of new IBehavior.
        /// </summary>
        /// <param name="behaviorType">String behavior type.</param>
        /// <returns>new IBehavior.</returns>
        IBehavior DefineBehavior(string behaviorType);
    }
}
