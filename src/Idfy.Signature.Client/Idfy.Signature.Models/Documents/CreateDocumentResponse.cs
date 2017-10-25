using System;
using System.Collections.Generic;
using Idfy.Signature.Models.Signers;

namespace Idfy.Signature.Models.Documents
{
    public class CreateDocumentResponse: CreateDocumentBaseData
    {
        /// <summary>
        /// A unique document Id
        /// </summary>
        public Guid DocumentId { get; set; }
        /// <summary>
        /// List of all the signers
        /// </summary>
        public List<SignerResponse> Signers { get; set; }


        /// <summary>
        /// A dicitonary with extra information from additional services. See developer documentation for more information
        /// </summary>
        public Dictionary<string, string> MetaData { get; set; }

        /// <summary>
        /// Overall document status
        /// </summary>
        public Status Status { get; set; }

    }
}
