﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Idfy.Signature.Models.Misc
{
    /// <summary>
    /// Data that should be signed
    /// </summary>
    public class DataToSign
    {
        /// <summary>
        /// Base 64 encoded string of content, utf-8
        /// </summary>
        [Required]
        public string Base64Content { get; set; }
        /// <summary>
        /// Stylesheet to be included if you are uploading xml
        /// </summary>
        public string Base64ContentStyleSheet { get; set; }
        /// <summary>
        /// The document FileName, has to include a valid extension (.pdf, .xml, .txt, .doc, .docx, .rtf, .ott, odt)
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Document title must be between 3 and 100 characters long")]
        public string FileName { get; set; }
        /// <summary>
        /// Convert a non PDF file to PDF, supported formats are word documents, rich texformat and open office (.doc, docx, .rtf .odt and ott), Remark the document that is signed is not the original document.
        /// </summary>
        public bool ConvertToPDF { get; set; }
        /// <summary>
        /// Set how you want the signed file to be packaged
        /// </summary>
        public Packaging Packaging { get; set; }
    }

    public class Packaging
    {
        /// <summary>
        /// The format(s) that you will be able to fetch the signed document afterwards. Read more about SignaturePackage format in the documentation. (The native package format is included automatically (i.e. bankid sdo)
        /// </summary>
        public List<SignaturePackageFormat> SignaturePackageFormats { get; set; }
        /// <summary>
        /// If you are using pades as a signature package format you can define settings here
        /// </summary>
        public PadesSettings PadesSettings { get; set; }

    }

    public class PadesSettings
    {
        /// <summary>
        /// Set the primary language of the pades explanatory page. Defaults to english
        /// </summary>
        public NotificationLanguage? PrimaryLanguage { get; set; }
        /// <summary>
        /// Set the secondary language of the pades explanatory page.
        /// </summary>
        public NotificationLanguage? SecondaryLanguage { get; set; }
        /// <summary>
        /// Include your own pades template
        /// </summary>
        public string PadesTemplateId { get; set; }
    }
}
