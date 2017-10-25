using System;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.JWT
{
    public class JwtValidationResponse
    {
        public string JwtKeyVersion { get; set; }
        /// <summary>
        /// true if jwt is valid
        /// </summary>
        public bool JwtValid { get; set; }
        /// <summary>
        /// Payload (valid data if jwt is valid)
        /// </summary>
        public JwtPayload JwtPayload { get; set; }
    }

    public class JwtPayload
    {
        /// <summary>
        /// Account Id
        /// </summary>
        public Guid AccountId { get; set; }
        /// <summary>
        /// Document Id
        /// </summary>
        public Guid DocumentId { get; set; }
        /// <summary>
        /// External document Id
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Signer Id
        /// </summary>
        public Guid SignerId { get; set; }
        /// <summary>
        /// External signer Id
        /// </summary>
        public string ExternalSignerId { get; set; }
        /// <summary>
        /// Error object, will be included on error
        /// </summary>
        public Error Error { get; set; }
        /// <summary>
        /// Success object, will be included on sign success
        /// </summary>
        public SignSuccess SignSuccess { get; set; }
        /// <summary>
        /// Set to true if user aborted
        /// </summary>
        public bool? Aborted { get; set; }
    }


    public class Error
    {
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
    }

    public class SignSuccess
    {
        /// <summary>
        /// The signers first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The signers last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The signers date of birth
        /// </summary>
        public string DateOfBirth { get; set; }
        /// <summary>
        /// The signaturemethod used to sign the document
        /// </summary>
        public SignatureMethod SignatureMethod { get; set; }
        /// <summary>
        /// Signed time
        /// </summary>
        public long? SignedTime { get; set; }
    }

}