namespace Idfy.Signature.Models.Signers
{
    public class Authentication
    {
        /// <summary>
        /// If this is set to true, you have to include the social security number or SignatureMethod unique id for the signer
        /// </summary>
        public bool AuthBeforeSign { get; set; }
        /// <summary>
        /// The signers social security number
        /// </summary>
        public string SocialSecurityNumber { get; set; }

        /// <summary>
        /// Define this if you have the signers unique signaturemethod id (i.e. the norwegian bankid pid). Only the person supposed to sign the document will then be allowed to sign it.
        /// </summary>
        public string SignatureMethodUniqueId { get; set; }

    }
}