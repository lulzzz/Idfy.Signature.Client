using System.ComponentModel.DataAnnotations;

namespace Idfy.Signature.Models.Misc
{
    public class Advanced
    {
        /// <summary>
        /// Mark the document with tags, these tags can be used to query for document data / events at a later time. Please separate the tags with comma (ie: "Tags":"awesome,contract")
        /// </summary>
        [RegularExpression("^[a-zA-Z,0-9]+$", ErrorMessage = "A tag may only contain letters from a-z/A-Z, and or numbers")]
        public string Tags { get; set; }
        /// <summary>
        /// Set how many attachments this signjob should have, when the document is created you can upload the attachments [here](#operation/Attachment_Create). <span style="color: red">
        /// Beware: if you set this value to 3, you MUST upload 3 attachments before anyone can sign this document.</span>
        /// </summary>
        public int Attachments { get; set; }
        /// <summary>
        /// Set how many signatures this document needs before it can be sealed and sat to complete
        /// </summary>
        public int RequiredSignatures { get; set; }

        public string CreatedByApplication { get; set; }
     
        /// <summary>
        /// If your certificate allows it you can retrieve the signers social security number after a successful sign session
        /// </summary>
        public bool GetSocialSecurityNumber { get; set; }

        /// <summary>
        /// Define this to get information about the sign process in a webhook
        /// </summary>
        public string Webhook { get; set; }
        /// <summary>
        ///Coming soon: Do you want to collect extra info about the signature process? (for example prokura info)
        /// </summary>
        public ExtraInfo ExtraInfo { get; set; }
        /// <summary>
        /// Customize styling to make the the signature application look perfect in combination with your application
        /// </summary>
        public Styling Styling { get; set; }
        /// <summary>
        /// Security settings
        /// </summary>
        public Security Security { get; set; }
        /// <summary>
        /// Customize the time to live for the document and urls
        /// </summary>
        public TimeToLive TimeToLive { get; set; }
    }

    public class TimeToLive
    {
        /// <summary>
        /// How long before the signers url should expire? Utc date in ticks. This can be set if you only want a limited time to live for each sign url (If you generate a new url at a later time this will also have this limited lifetime). Defaults to the document lifetime.
        /// </summary>
        public int SignUrlExpires { get; set; }
        /// <summary>
        /// Define when the document should expire (utc date in ticks), document is not signable after this (Default/maximum 45 days)
        /// </summary>
        public long Expires { get; set; }
        /// <summary>
        /// How many days should we keep the document after it is signed? Default/ maximum 14 days
        /// </summary>
        public int DeleteAfterDays { get; set; }
    }
}
