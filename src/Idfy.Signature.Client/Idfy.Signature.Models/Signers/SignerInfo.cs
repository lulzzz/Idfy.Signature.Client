using System.ComponentModel.DataAnnotations;

namespace Idfy.Signature.Models.Misc
{
    public class SignerInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public Mobile Mobile { get; set; }
        /// <summary>
        /// The signers organization info
        /// </summary>
        public OrganizationInfo OrganizationInfo { get; set; }
    }
}