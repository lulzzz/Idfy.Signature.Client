using System;
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
        [StringLength(255, MinimumLength = 4, ErrorMessage = "External Signer Id must be between 4 and 255 characters long")]
        public string ExternalSignerId { get; set; }
        /// <summary>
        /// Return urls and domain settings
        /// </summary>
        [Required]
        public RedirectSettings RedirectSettings { get; set; }
        [Required]
        public SignatureType SignatureType { get; set; }
        /// <summary>
        /// Define the signers name, mobile and email if you are using notifications
        /// </summary>
        public SignerInfo SignerInfo { get; set; }

        /// <summary>
        /// Do you want the signer to authenticate before they can see the document?
        /// </summary>
        public Authentication Authentication { get; set; }
        /// <summary>
        ///Coming soon: Do you want to collect extra info about this specific signer? (for example personal information)
        /// </summary>
        public ExtraInfoSignerRequest ExtraInfo { get; set; }
        /// <summary>
        /// Here you can set language, styling and create dialogs the signer have to read before/after the signing
        /// </summary>
        public UI Ui { get; set; }
        /// <summary>
        /// Enable and setup email/sms notifications for this specific signer
        /// </summary>
        public Notifications Notifications { get; set; }
        /// <summary>
        /// Coming soon
        /// </summary>
        public List<string> Tags { get; set; }
        /// <summary>
        /// You can define a specific sign order /queue for the signers if you want to.
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// If some of the signers are marked as required, the other signers are not allowed to sign before the required ones have signed the document
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// How long before the signers url should expire? (ISO 8601). This can be set if you only want a limited time to live for each sign url (If you generate a new url at a later time this will also have this limited lifetime). Defaults to the document lifetime.
        /// </summary>
        public DateTime? SignUrlExpires { get; set; }
    }

    public class Notifications
    {
        /// <summary>
        /// Setup what kind of notifications this signer should get. Defaults to off
        /// </summary>
        public Dictionary<NotificationType, NotificationSetting> Setup { get; set; }
        /// <summary>
        /// If you create your own notifications texts (See the root object -> Notification), you can create your own merge fields with your own keys. 
        /// You can then specify the text you want to insert in these fields per signer in this dictionary. Set the dictionary key to the same value as the merge field value in your notification text, and the value to the text you want us to merge in.
        /// </summary>
        public Dictionary<string, string> MergeFields { get; set; }
    }

    public class UI
    {
        /// <summary>
        /// You can create dialogs that will be showed to the signer in the signature process
        /// </summary>
        public Dialogs Dialogs { get; set; }
        /// <summary>
        /// The signers preferred language, this setting is used when signing the document and in email/sms notifications.<span style="color: blue;">If you set it to browser language the notifications will be delievered in english unless you specify custom notification messages with browser as language in your request.</span> 
        /// </summary>
        public Language Language { get; set; }
        /// <summary>
        /// Customize styling to make the the signature application look perfect in combination with your application
        /// </summary>
        public Styling Styling { get; set; }
    }
}