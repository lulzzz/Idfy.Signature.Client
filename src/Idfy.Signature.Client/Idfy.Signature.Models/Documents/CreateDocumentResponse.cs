﻿using System;
using System.Collections.Generic;
using Idfy.Signature.Models.Signers;

namespace Idfy.Signature.Models.Documents
{
    public class CreateDocumentResponse: CreateDocumentBaseData
    {
        public Guid DocumentId { get; set; }
        public List<SignerResponse> Signers { get; set; }
    }
}