using System;

namespace Idfy.Signature.Models.JWT
{
    public class JwtValidationResponse
    {
        public bool JwtValid { get; set; }
        public Guid DocumentId { get; set; }
        public Guid AccountId { get; set; }
    }
}