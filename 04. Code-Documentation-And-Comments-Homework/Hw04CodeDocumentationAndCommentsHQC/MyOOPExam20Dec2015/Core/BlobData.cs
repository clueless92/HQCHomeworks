using System;
using System.Collections;
using System.Collections.Generic;

namespace MyOOPExam20Dec2015.Core
{
    using Interfaces;
    public class BlobData : IData
    {
        public BlobData()
        {
            this.Blobs = new Dictionary<string, IBlob>();
        }

        public IDictionary<string, IBlob> Blobs { get; private set; }

        public void AddBlob(string blobName, IBlob blob)
        {
            this.Blobs.Add(blobName, blob);
        }

        public IBlob GetBlob(string blobName)
        {
            if (!this.Blobs.ContainsKey(blobName))
            {
                throw new ArgumentException(String.Format("No blob named {0} found in data.", blobName));
            }
            return this.Blobs[blobName];
        }
    }
}
