using System.Collections.Generic;
using Idfy.Signature.Models.File;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Documents
{
    public class Status
    {
        public DocumentStatus DocumentStatus { get; set; }
        public IList<FileFormat> CompletedPackages { get; set; }
    }
}