using System;
using System.Collections.Generic;

namespace Idfy.Signature.Models.Sign
{
    public class CreateDocumentResponse: CreateDocumentBaseData
    {
        public Guid DocumentId { get; set; }
        public List<SignerResponse> Signers { get; set; }
    }
}
