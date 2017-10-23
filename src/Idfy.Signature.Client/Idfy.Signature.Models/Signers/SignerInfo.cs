using System.ComponentModel.DataAnnotations;
using Idfy.Signature.Models.Attributes;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Signers
{
    public class SignerInfo
    {
        /// <summary>
        /// The signers first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The signers last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The signers email adress, define this if you are using notifications
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// The signers mobile, define this if you are using notifications
        /// </summary>
        [ValidateMobileSimple]
        public Mobile Mobile { get; set; }
        /// <summary>
        /// The signers organization info
        /// </summary>
        public OrganizationInfo OrganizationInfo { get; set; }
    }
}