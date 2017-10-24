using System;
using System.Collections.Generic;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Documents
{
    public class DocumentSummary
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? SignedDate { get; set; }
        public Status Status { get; set; }
        public string ExternalId { get; set; }
        public IList<ExtendedDocumentSignature> DocumentSignatures { get; set; }
        public int RequiredSignatures { get; set; }
        public int CurrentSignatures { get; set; }
        public string Tags { get; set; }
        public List<Guid> Attachments { get; set; }
    }
}