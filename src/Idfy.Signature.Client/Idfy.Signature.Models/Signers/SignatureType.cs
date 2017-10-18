using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Signers
{
    public class SignatureType
    {
        /// <summary>
        /// Define which signature methods the signer are allowed to sign the document with, if empty all available methods for the account will be displayed to the user
        /// </summary>
        public List<SignatureMethod> SignatureMethods { get; set; }

        [Required]
        public Mechanisms Mechanism { get; set; }

        public bool OnEacceptUseHandWrittenSignature { get; set; }
    }
}