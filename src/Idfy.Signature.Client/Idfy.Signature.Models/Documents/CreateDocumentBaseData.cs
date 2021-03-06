﻿using System.ComponentModel.DataAnnotations;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Documents
{
    public class CreateDocumentBaseData
    {
        /// <summary>
        /// Signjob title
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Signjob description
        /// </summary>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// Your reference to this signjob
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 4, ErrorMessage = "External Document Id must be between 4 and 255 characters long")]
        public string ExternalId { get; set; }
        [Required]
        public DataToSign DataToSign { get; set; }

        /// <summary>
        /// The companys contact information
        /// </summary>
        [Required]
        public ContactDetails ContactDetails { get; set; }
        /// <summary>
        /// Manage notifications
        /// </summary>
        public Notification Notification { get; set; }
    }
}