using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Idfy.Signature.Models.Signers;

namespace Idfy.Signature.Models.Documents
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