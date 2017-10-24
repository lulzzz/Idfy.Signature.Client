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
        /// Security settings
        /// </summary>
        public Security Security { get; set; }
        /// <summary>
        /// Customize the time to live for the document and urls
        /// </summary>
        public TimeToLive TimeToLive { get; set; }
        /// <summary>
        /// Include your own pades template
        /// </summary>
        public string PadesTemplateId { get; set; }
        /// <summary>
        /// Set department Id to mark invoice with department
        /// </summary>
        public string DepartmentId { get; set; }
    }

    public class TimeToLive
    {
        /// <summary>
        /// Define when the document should expire (utc date in ticks), document is not signable after this (Default/maximum 45 days)
        /// </summary>
        public long Deadline { get; set; }
        /// <summary>
        /// How many hours should we keep the document after it is signed? Default/ maximum  7 days (168 hours)
        /// </summary>
        public int DeleteAfterHours { get; set; }
    }
}
