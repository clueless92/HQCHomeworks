namespace MyOOPExam20Dec2015.Interfaces
{
    /// <summary>
    /// Defines public members of classes that implement it.
    /// </summary>
    public interface IBlob : IDestroyable, IUpdateable
    {
        /// <summary>
        /// Gets attack damage of blob for current turn.
        /// Can be modified by attack type and behavior of blob.
        /// </summary>
        /// <returns></returns>
        int GetAttackDamage();

        /// <summary>
        /// Gets name of blob.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets damage of blob.
        /// </summary>
        int Damage { get; }
    }
}
