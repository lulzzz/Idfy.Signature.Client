using System;

namespace Idfy.Signature.Models.Misc
{
    public class DocumentSignature
    {
        public SignatureMethod SignatureMethod { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string SignerId { get; set; }
        public DateTime? SignedTime { get; set; }
    }
}