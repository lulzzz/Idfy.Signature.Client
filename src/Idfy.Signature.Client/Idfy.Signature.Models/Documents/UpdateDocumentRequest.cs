using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Documents
{
    public class UpdateDocumentRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Notification Notification { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public Advanced Advanced { get; set; }
    }
}