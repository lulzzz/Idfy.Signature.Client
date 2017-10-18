using System.ComponentModel.DataAnnotations;

namespace Idfy.Signature.Models.Misc
{
    public class Mobile
    {
        [Required]
        public string CountryCode { get; set; }
        [Required]
        public string Number { get; set; }
    }
}