﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Attachment
{
    public class UpdateAttachmentRequest
    {
        /// <summary>
        /// Filename with file extension. <span style="color:red;">We only support PDF for attachments</span>
        /// </summary>
        public  string FileName { get; set; }
        /// <summary>
        /// Give the attachment a title that will be presented to the user
        /// </summary>
        public  string Title { get; set; }
        /// <summary>
        /// base 64 encoded attachment (utf-8)
        /// </summary>
        /// <summary>
        /// Optional: Specify which signers that should be able to see / sign this attachment
        /// </summary>
        public IList<Guid> Signers { get; set; }
        /// <summary>
        /// Optional: An optional description of the document
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// base 64 encoded attachment (utf-8)
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Choose between the following:
        /// * <b>show_accept:</b> The signer will see the attachment before signing the main document (is default now)
        /// * <b>read_accept:</b> The signer have to see the entire document before they can continue, 
        /// * <b>sign:</b> The signer has to sign the attachment (extra cost per signature)
        /// </summary>
        public AttachmentType? Type { get; set; }
    }
}