using System.Collections.Generic;
using Idfy.Signature.Models.File;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Documents
{
    public class Status
    {
        /// <summary>
        /// The overall status for the document
        /// </summary>
        public DocumentStatus DocumentStatus { get; set; }
        /// <summary>
        /// A list of all the completed files/packages on this document.
        /// </summary>
        public IList<FileFormat> CompletedPackages { get; set; }
    }
}