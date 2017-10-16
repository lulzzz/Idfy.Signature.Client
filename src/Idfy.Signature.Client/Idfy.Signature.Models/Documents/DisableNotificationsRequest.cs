using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Idfy.Signature.Models.Documents
{
    public class DisableNotificationsRequest    
    {
        [Required]
        public Guid DocumentId { get; set; }
        /// <summary>
        /// If you only want to stop notifications for specific receivers, please specify their email address here
        /// </summary>
        public IEnumerable<string> EmailFilter { get; set; }
        /// <summary>
        /// Disable request notifications for the current document
        /// </summary>
        public bool DisableRequest { get; set; }
        /// <summary>
        /// Disable reminder notifications for the current document
        /// </summary>
        public bool DisableReminder { get; set; }
        /// <summary>
        /// Disable receipt notifications for the current document
        /// </summary>
        public bool DisableReceipt { get; set; }

    }
}