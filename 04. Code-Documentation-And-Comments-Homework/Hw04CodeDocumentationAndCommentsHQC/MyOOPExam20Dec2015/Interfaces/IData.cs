namespace MyOOPExam20Dec2015.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines public members of classes that implement it.
    /// </summary>
    public interface IData
    {
        /// <summary>
        /// Gets all created IBlob entities stored in a IDictionary with KeyValuePair of String, IBlob.
        /// </summary>
        IDictionary<string, IBlob> Blobs { get; }

        /// <summary>
        /// Adds a new IBlob to Blobs.
        /// </summary>
        /// <param name="blobName">String name.</param>
        /// <param name="blob">IBlob.</param>
        void AddBlob(string blobName, IBlob blob);

        /// <summary>
        /// Gets IBlob drom Blobs by its name.
        /// </summary>
        /// <param name="blobName">String name.</param>
        /// <returns>IBlob.</returns>
        IBlob GetBlob(string blobName);
    }
}
