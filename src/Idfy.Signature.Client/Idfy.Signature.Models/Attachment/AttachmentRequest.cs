using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Attachment
{
    public class AttachmentRequest
    {
        /// <summary>
        /// The document Id you retrieved when you created a new signature job
        /// </summary>
        [Required]
        public Guid DocumentId { get; set; }
        /// <summary>
        /// Filename with file extension. <span style="color:red;">We only support PDF for attachments</span>
        /// </summary>
        [Required]
        public string FileName { get; set; }
        /// <summary>
        /// Give the attachement a title that will be presented to the user
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// base 64 encoded attachement (utf-8)
        /// </summary>
        [Required]
        public string Data { get; set; }

        /// <summary>
        /// Optional: Specify which signers that should be able to see / sign this attachment
        /// </summary>
        public IList<Guid> Signers { get; set; }

        /// <summary>
        /// Optional: An optional description of the document
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Coming soon: Choose between the following:
        /// * <b>show_accept:</b> The signer will see the attachment before signing the main document (is default now)
        /// * <b>read_accept:</b> The signer have to see the entire document before they can continue, 
        /// * <b>sign:</b> The signer has to sign the attachment (extra cost per signature)
        /// </summary>
        public AttachmentType Type { get; set; }
    }

    

}