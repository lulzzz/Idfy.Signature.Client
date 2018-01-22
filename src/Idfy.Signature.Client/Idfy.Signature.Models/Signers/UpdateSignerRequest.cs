using System.Collections.Generic;
using Idfy.Signature.Models.Misc;
using System.ComponentModel.DataAnnotations;

namespace Idfy.Signature.Models.Signers
{
    public class UpdateSignerRequest
    {
        /// <summary>
        /// Return urls and domain settings
        /// </summary>
        public RedirectSettings RedirectSettings { get; set; }
        /// <summary>
        /// Define the signers name, mobile and email if you are using notifications
        /// </summary>
        public SignerInfo SignerInfo { get; set; }
        /// <summary>
        ///Coming soon: Do you want to collect extra info about this specific signer? (for example personal information)
        /// </summary>
        public ExtraInfoSignerRequest ExtraInfo { get; set; }
        /// <summary>
        /// Here you can set language, styling and create dialogs the signer have to read before/after the signing
        /// </summary>
        public UI Ui { get; set; }
        /// <summary>
        /// Enable / setup email/sms notifications for this specific signer
        /// </summary>
        public Notifications Notifications { get; set; }
        /// <summary>
        /// Signer tags
        /// </summary>
        public List<string> Tags { get; set; }
        /// <summary>
        /// You can define a specific sign order /queue for the signers if you want to.
        /// </summary>
        public int? Order { get; set; }
        /// <summary>
        /// If some of the signers are marked as required, the other signers are not allowed to sign before the required ones have signed the document
        /// </summary>
        public bool? Required { get; set; }
        /// <summary>
        /// How long before the signers url should expire? Utc date as unix timestamp. This can be set if you only want a limited time to live for each sign url (If you generate a new url at a later time this will also have this limited lifetime). Defaults to the document lifetime.
        /// </summary>
        public long? SignUrlExpires { get; set; }
    }
}