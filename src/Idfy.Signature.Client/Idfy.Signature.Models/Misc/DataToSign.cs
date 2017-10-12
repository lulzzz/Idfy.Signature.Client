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
        /// Coming soon
        /// </summary>
        public bool ConvertToPDF { get; set; }
        /// <summary>
        /// Set to true if you want a pades when a pdf file is signed
        /// </summary>
        public bool CreatePades { get; set; }


    }
}
