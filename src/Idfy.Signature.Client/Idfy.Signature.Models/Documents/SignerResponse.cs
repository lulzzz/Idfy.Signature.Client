using System;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Sign
{
    public class SignerResponse: Signer
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
    }
}