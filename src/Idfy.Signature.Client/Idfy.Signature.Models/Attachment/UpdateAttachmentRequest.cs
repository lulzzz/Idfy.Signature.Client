using System;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Attachment
{
    public class UpdateAttachmentRequest : AttachmentRequest
    {
        public Guid Id { get; set; }
    }

    public class AttachmentListItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AttachmentType Type { get; set; }
        public string FileName { get; set; }
    }

}