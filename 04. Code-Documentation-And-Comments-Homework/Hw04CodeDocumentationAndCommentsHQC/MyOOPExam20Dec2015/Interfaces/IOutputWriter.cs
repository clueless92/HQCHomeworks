namespace MyOOPExam20Dec2015.Interfaces
{
    /// <summary>
    /// Defines public members of classes that implement it.
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// Writes the specified string value, followed by the current line terminator.
        /// </summary>
        /// <param name="output">String output.</param>
        void PrintLine(string output);

        /// <summary>
        /// Writes the specified string value.
        /// </summary>
        /// <param name="output">String output.</param>
        void Print(string output);
    }
}
