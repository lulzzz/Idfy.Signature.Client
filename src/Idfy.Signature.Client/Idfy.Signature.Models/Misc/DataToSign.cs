using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Idfy.Signature.Models.Attributes;

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
        /// The document FileName, has to include a valid extension (.pdf, .xml, .txt)
        /// </summary>
        [Required]
        [ValidateFileName]
        public string FileName { get; set; }
        /// <summary>
        /// Convert a non PDF file to PDF, supported formats are word documents, rich texformat and open office (.doc, docx, .rtf .odt and ott), Remark the document that is signed is not the original document.
        /// </summary>
        public bool ConvertToPDF { get; set; }

        /// <summary>
        /// The format(s) that you will be able to fetch the signed document afterwards. Read more about SignaturePackage format in the documentation. (The native package format is included automatically (i.e. bankid sdo)
        /// </summary>
        public List<SignaturePackageFormat> SignaturePackageFormat { get; set; }
    }
}
