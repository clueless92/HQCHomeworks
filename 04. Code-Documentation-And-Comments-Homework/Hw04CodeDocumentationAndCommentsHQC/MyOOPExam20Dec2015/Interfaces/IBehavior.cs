namespace MyOOPExam20Dec2015.Interfaces
{
    /// <summary>
    /// Defines public members of classes that implement it.
    /// </summary>
    public interface IBehavior
    {
        // Behaviors can effect both health and damage.
        // For further extensivbility when implementing behaviors:
        // return both health and damage respectivly in the 0 and 1 element of int[]

        /// <summary>
        /// Gets new values to be assigned to stats based on health, damage and internal innitial behavior logic.
        /// Must be triggered only once.
        /// </summary>
        /// <param name="health">Int32 health.</param>
        /// <param name="damage">Int32 damage.</param>
        /// <returns>Int32[]</returns>
        int[] InnitialBehavior(int health, int damage);

        /// <summary>
        /// Gets new values to be assigned to stats based on health, damage and consecutive behavior logic.
        /// Must be triggered once each turn after the turn that triggered the innitial behavior.
        /// </summary>
        /// <param name="health">Int32 health.</param>
        /// <param name="damage">Int32 damage.</param>
        /// <returns>Int32[]</returns>
        int[] ConsecutiveBehavior(int health, int damage);
    }
}
