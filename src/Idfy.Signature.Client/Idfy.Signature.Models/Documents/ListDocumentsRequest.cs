using System;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Documents
{
    public class ListDocumentsRequest
    {
        public long? FromDate { get; set; }
        public long? LastUpdated { get; set; }
        public long? SignedDate { get; set; }
       
        public DocumentStatus? Status { get; set; }
        public string NameOfSigner { get; set; }
        public Guid? SignerId { get; set; }
        public string ExternalId { get; set; }
        public string Tags { get; set; }
        public string ExternalSignerId { get; set; }
        public long? ToDate { get; set; }
    }
}