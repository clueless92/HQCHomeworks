namespace MyOOPExam20Dec2015.Interfaces
{
    /// <summary>
    /// Defines public members of classes that implement it.
    /// </summary>
    public interface IAttack
    {
        /// <summary>
        /// Gets attack modifier, which in some attack types may also be used to modify other stats (like health).
        /// </summary>
        int Modifier { get; }
    }
}
