using System;
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
    }
}