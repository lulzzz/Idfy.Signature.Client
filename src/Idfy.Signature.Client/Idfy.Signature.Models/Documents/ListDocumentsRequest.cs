using System;
using System.Collections.Generic;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Documents
{
    /// <summary>
    /// Query documents
    /// </summary>
    public class ListDocumentsRequest
    {
        /// <summary>
        /// Show documents created from a specific date (in ticks)
        /// </summary>
        public long? FromDate { get; set; }
        /// <summary>
        /// Show documents created from a specific last updated date (in ticks)
        /// </summary>
        public long? LastUpdated { get; set; }
        /// <summary>
        /// Show documents signed from a specific date (in ticks)
        /// </summary>
        public long? SignedDate { get; set; }
        /// <summary>
        /// Filter on document status
        /// </summary>
        public DocumentStatus? Status { get; set; }
        /// <summary>
        /// Search for a signer name
        /// </summary>
        public string NameOfSigner { get; set; }
        /// <summary>
        /// Search for a signer Id
        /// </summary>
        public Guid? SignerId { get; set; }
        /// <summary>
        /// Find a document with external Id
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Search for tags, separate tags with ,
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// Search for external signer Id
        /// </summary>
        public string ExternalSignerId { get; set; }
        /// <summary>
        /// Search for document title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Documents created before this date
        /// </summary>
        public long? ToDate { get; set; }
    }
}