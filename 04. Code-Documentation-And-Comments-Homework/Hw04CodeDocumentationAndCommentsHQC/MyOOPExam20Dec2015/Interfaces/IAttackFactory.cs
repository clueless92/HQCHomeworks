namespace MyOOPExam20Dec2015.Interfaces
{
    /// <summary>
    /// Defines public members of classes that implement it.
    /// </summary>
    public interface IAttackFactory
    {
        /// <summary>
        /// Encapsulates creation of new IAttack.
        /// </summary>
        /// <param name="attackType">String attack type.</param>
        /// <returns>new IAttack.</returns>
        IAttack DefineAttack(string attackType);
    }
}
