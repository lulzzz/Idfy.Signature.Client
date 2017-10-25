using System;
using System.Collections.Generic;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Signers
{
    public class SignerResponse: Signer
    {
        /// <summary>
        /// Signer Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// This is the url that the signer should use to sign the document
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// This property will get it's values when the signing is done, it contains name, date of birth of the signer and mroe.
        /// </summary>
        public DocumentSignature DocumentSignature { get; set; }

        /// <summary>
        /// A dicitonary with extra information from each identityprovider, and extra services. See developer documentation for more information
        /// </summary>
        public Dictionary<string, string> MetaData { get; set; }
    }
}