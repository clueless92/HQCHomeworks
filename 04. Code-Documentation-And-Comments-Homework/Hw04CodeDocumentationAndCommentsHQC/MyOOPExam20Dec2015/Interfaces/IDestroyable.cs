namespace MyOOPExam20Dec2015.Interfaces
{
    /// <summary>
    /// Defines public members of classes that implement it.
    /// </summary>
    public interface IDestroyable
    {
        /// <summary>
        /// Gets health.
        /// </summary>
        int Health { get; }

        /// <summary>
        /// Gives IBlobs the ability to respond to another IBlobs attack.
        /// Helps to make code for IBlob interactions more readable.
        /// </summary>
        /// <param name="damageTaken">Int32 damage taken.</param>
        void RespondToAttack(int damageTaken);
    }
}
