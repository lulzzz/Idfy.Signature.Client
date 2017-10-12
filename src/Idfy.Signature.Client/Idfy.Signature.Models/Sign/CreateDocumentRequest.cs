using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Sign
{
    public class CreateDocumentRequest : CreateDocumentBaseData
    {
        /// <summary>
        /// Signers list
        /// </summary>
        [Required]
        public List<Signer> Signers { get; set; }
    }
}