namespace ACTS.Interfaces
{
    /// <summary>
    /// Defines methods to manipulate a report.
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Gets or sets Manufacturer.
        /// </summary>
        string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets Model.
        /// </summary>
        string Model { get; set; }

        /// <summary>
        /// Gets or sets Mark.
        /// </summary>
        bool Mark { get; set; }
    }
}
