using System;

namespace Idfy.Signature.Models.Attachment
{
    public class AttachmentResponse
    {
        public AttachmentResponse()
        {
            
        }
        public AttachmentResponse(Guid id)
        {
            this.Id = id;
        }
        public Guid Id { get; set; }
    }
}
