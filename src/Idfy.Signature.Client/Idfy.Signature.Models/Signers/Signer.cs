using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Signers
{
    public class Signer
    {
        /// <summary>
        /// Your reference for the signer
        /// </summary>
        [Required]
        public string ExternalSignerId { get; set; }
        /// <summary>
        /// Return urls and domain settings
        /// </summary>
        [Required]
        public RedirectSettings RedirectSettings { get; set; }
       
        public SignatureType SignatureType { get; set; }
        /// <summary>
        /// Define the signers name, mobile and email if you are using notifications
        /// </summary>
        public SignerInfo SignerInfo { get; set; }
        /// <summary>
        /// You can create dialogs that will be showed to the signer in the signature process
        /// </summary>
        public Dialogs Dialogs { get; set; }
        /// <summary>
        /// Do you want the signer to authenticate before they can see the document?
        /// </summary>
        public Authentication Authentication { get; set; }
        /// <summary>
        ///Coming soon: Do you want to collect extra info about this specific signer? (for example personal information)
        /// </summary>
        public ExtraInfo ExtraInfo { get; set; }
        /// <summary>
        /// Enable email/sms notifications for this specific signer
        /// </summary>
        public bool NotificationsEnabled { get; set; }
        /// <summary>
        /// The signers preferred language, this setting is used when signing the document and in email/sms notifications.<span style="color: blue;">If you set it to browser language the notifications will be delievered in english unless you specify custom notification messages with browser as language in your request.</span> 
        /// </summary>
        public Language Language { get; set; }
        /// <summary>
        /// Coming soon
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// You can define a specific sign order /queue for the signers if you want to.
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// If some of the signers are marked as required, the other signers are not allowed to sign before the required ones have signed the document
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// How long before the signers url should expire? Utc date in ticks. This can be set if you only want a limited time to live for each sign url (If you generate a new url at a later time this will also have this limited lifetime). Defaults to the document lifetime.
        /// </summary>
        public int SignUrlExpires { get; set; }

    }

    public class SignatureType
    {
        /// <summary>
        /// Define which signature methods the signer are allowed to sign the document with, if empty all available methods for the account will be displayed to the user
        /// </summary>
        public List<SignatureMethod> SignatureMethods { get; set; }

        [Required]
        public Mechanisms Mechanism { get; set; }

        public bool OnEacceptUseHandWrittenSignature { get; set; }
    }

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

    public class Mobile
    {
        [Required]
        public string CountryCode { get; set; }
        [Required]
        public string Number { get; set; }
    }

    public class OrganizationInfo
    {
        public string OrgNo { get; set; }
        public string CompanyName { get; set; }
    }

}