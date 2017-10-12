using System.ComponentModel.DataAnnotations;

namespace Idfy.Signature.Models.Attachment
{
    /// <summary>
    /// Jwt validation request
    /// </summary>
    public class JwtValidationRequest
    {
        /// <summary>
        /// The JWT to be validated as an string
        /// </summary>
        [Required]
        public string Jwt { get; set; }
    }
}