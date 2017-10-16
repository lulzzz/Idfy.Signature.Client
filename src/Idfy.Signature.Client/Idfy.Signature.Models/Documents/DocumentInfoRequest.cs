using System;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Documents
{
    public class DocumentInfoRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? SignedDate { get; set; }
       
        public DocumentStatus? Status { get; set; }
        public string NameOfSigner { get; set; }
        public Guid IdOfSigner { get; set; }
        public string ExternalId { get; set; }
        public string Tags { get; set; }
    }
}