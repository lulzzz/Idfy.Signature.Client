using System.Collections.Generic;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Sign
{
    public class Notification
    {
        public SignRequest SignRequest { get; set; }
        public Receipt Receipt { get; set; }
        public Reminder Reminder { get; set; }
    }

    public class SignRequest
    {
        public bool Enabled { get; set; }
        /// <summary>
        /// Create your own email messages. <span style="color: red;">Insert [signlink] where you want the sign url to be presented</span>
        /// </summary>
        public List<Email> Email { get; set; }
        public List<SMS> SMS { get; set; }
    }
    public class Reminder
    {
        public bool Enabled { get; set; }
        public List<Email> Email { get; set; }
        public List<SMS> SMS { get; set; }
        /// <summary>
        /// Define a chron expression to control the interval of the reminders (Use utc time). We use quartz cron expressions, read more about it here: http://www.quartz-scheduler.org/documentation/quartz-2.x/tutorials/crontrigger.html
        /// </summary>
        public string ChronSchedule { get; set; }
        /// <summary>
        /// Set the maximum number of reminders to be sent for each signer
        /// </summary>
        public int? MaxReminders { get; set; }
    }

    public class Receipt
    {
        public bool Enabled { get; set; }
        public List<Email> Email { get; set; }
        public List<SMS> SMS { get; set; }
    }
    
    public class Email
    {
        public Language Language { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SenderName { get; set; }
    }

    public class SMS
    {
        public Language Language { get; set; }
        public string Text { get; set; }
        public string Sender { get; set; }
    }
}