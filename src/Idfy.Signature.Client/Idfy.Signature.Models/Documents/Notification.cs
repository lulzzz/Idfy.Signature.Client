using System.Collections.Generic;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Documents
{
    public class Notification
    {
        /// <summary>
        /// Here you can setup email/sms notifications notifying the signer that they have a new document to sign. Info: you also has to enable notifications on the signers you want to notify.
        /// </summary>
        public SignRequest SignRequest { get; set; }
        /// <summary>
        /// Here you can setup email/sms notifications reminding the signers that they have unsigned documents. Info: you also has to enable notifications on the signers you want to notify.
        /// </summary>
        public Reminder Reminder { get; set; }
        /// <summary>
        /// Here you can setup email/sms notifications as a receipt for a retrieved signature
        /// </summary>
        public SignatureReceipt SignatureReceipt { get; set; }
        /// <summary>
        /// Here you can setup email/sms notifications as a receipt for a signed document (when all the required signatures is registered). 
        /// </summary>
        public FinalReceipt FinalReceipt { get; set; }

    }
    /// <summary>
    /// Here you can setup email/sms notifications notifying the signer that they have a new document to sign. Info: you also has to enable notifications on the signers you want to notify.
    /// </summary>
    public class SignRequest
    {
        /// <summary>
        /// Set which notfication service to use (is off by default)
        /// </summary>
        public NotificationSetting Setting { get; set; }
        /// <summary>
        /// Create your own email messages. <span style="color: red;">Insert {signlink} where you want the sign url to be presented</span>
        /// </summary>
        /// <summary>
        /// Define your own email texts (Our default texts can be used by leaving this blank)
        /// </summary>
        public List<Email> Email { get; set; }
        /// <summary>
        /// Define your own sms texts (Our default texts can be used by leaving this blank)
        /// </summary>
        public List<SMS> SMS { get; set; }
    }
    /// <summary>
    ///  Here you can setup email/sms notifications reminding the signers that they have unsigned documents. Info: you also has to enable notifications on the signers you want to notify.
    /// </summary>
    public class Reminder
    {
        /// <summary>
        /// Set which notfication service to use (is off by default)
        /// </summary>
        public NotificationSetting Setting { get; set; }
        /// <summary>
        /// Define your own email texts (Our default texts can be used by leaving this blank)
        /// </summary>
        public List<Email> Email { get; set; }
        /// <summary>
        /// Define your own sms texts (Our default texts can be used by leaving this blank)
        /// </summary>
        public List<SMS> SMS { get; set; }
        /// <summary>
        /// Define a chron expression to control the interval of the reminders (Use utc time). We use quartz cron expressions, read more about it here: http://www.quartz-scheduler.org/documentation/quartz-2.x/tutorials/crontrigger.html.
        /// </summary>
        public string ChronSchedule { get; set; }
        /// <summary>
        /// Set the maximum number of reminders to be sent for each signer
        /// </summary>
        public int? MaxReminders { get; set; }
    }
    /// <summary>
    /// Here you can setup email/sms notifications as a receipt for a signed document (when all the required signatures is registered). 
    /// </summary>
    public class FinalReceipt
    {
        /// <summary>
        /// Set which notfication service to use (is off by default)
        /// </summary>
        public NotificationSetting Setting { get; set; }
        /// <summary>
        /// You can include the signed document as an attachment in the receipt if you wish (We don't recommend to do this with sensitive documents).
        /// </summary>
        public bool IncludeSignedFile { get; set; }
        /// <summary>
        /// Define your own email texts (Our default texts can be used by leaving this blank)
        /// </summary>
        public List<Email> Email { get; set; }
        /// <summary>
        /// Define your own sms texts (Our default texts can be used by leaving this blank)
        /// </summary>
        public List<SMS> SMS { get; set; }
    }

    /// <summary>
    /// Here you can setup email/sms notifications as a receipt for a retrieved signature
    /// </summary>
    public class SignatureReceipt
    {
        /// <summary>
        /// Set which notfication service to use (is off by default)
        /// </summary>
        public NotificationSetting Setting { get; set; }
        /// <summary>
        /// Define your own email texts (Our default texts can be used by leaving this blank)
        /// </summary>
        public List<Email> Email { get; set; }
        /// <summary>
        /// Define your own sms texts (Our default texts can be used by leaving this blank)
        /// </summary>
        public List<SMS> SMS { get; set; }
    }
    
    public class Email
    {
        /// <summary>
        /// Email language
        /// </summary>
        public NotificationLanguage Language { get; set; }
        /// <summary>
        /// Email subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Insert your email text, we support plain text and markdown
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Name of sender
        /// </summary>
        public string SenderName { get; set; }
    }

    public class SMS
    {
        /// <summary>
        /// Sms language
        /// </summary>
        public NotificationLanguage Language { get; set; }
        /// <summary>
        /// Sms text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Sender name
        /// </summary>
        public string Sender { get; set; }
    }


}