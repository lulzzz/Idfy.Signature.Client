using System.ComponentModel.DataAnnotations;

namespace Idfy.Signature.Models.Misc
{
    public class ContactDetails
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Url { get; set; }
    }
}
