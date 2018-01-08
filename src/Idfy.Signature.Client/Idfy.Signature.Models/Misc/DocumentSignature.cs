using System;

namespace Idfy.Signature.Models.Misc
{
    public class ExtendedDocumentSignature : DocumentSignature
    {
        /// <summary>
        /// The signer Id
        /// </summary>
        public Guid SignerId { get; set; }
        /// <summary>
        /// Your reference for the signer
        /// </summary>
        public string ExternalSignerId { get; set; }
    }

    public class DocumentSignature
    {
        /// <summary>
        /// The signature method used to sign the document
        /// </summary>
        public SignatureMethod SignatureMethod { get; set; }
        /// <summary>
        /// Full name of the signer retrieved from the signature-method provider
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// First name of the signer
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the signer
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Middle name of the signer
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// The time signature was registered (unix format)
        /// </summary>
        public long? SignedTime { get; set; }
        /// <summary>
        /// The signers date of birth (ddMMyy)
        /// </summary>
        public string DateOfBirth { get; set; }
        /// <summary>
        /// The signature method unique Id
        /// </summary>
        public string SignatureMethodUniqueId { get; set; }
        /// <summary>
        /// The signers social security number, this will get a value if you specified that you wanted social security number in your request (if you are allowed to)
        /// </summary>
        public string SocialSecurityNumber { get; set; }
        /// <summary>
        /// The Ip address of the signer
        /// </summary>
        public string ClientIp { get; set; }
    }
}