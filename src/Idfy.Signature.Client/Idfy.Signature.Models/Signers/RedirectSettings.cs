using System.ComponentModel.DataAnnotations;
using Idfy.Signature.Models.Misc;

namespace Idfy.Signature.Models.Signers
{
    public class RedirectSettings
    {
        /// <summary>
        /// Define if you want redirect or webmessaging or both
        /// </summary>
        [Required]
        public RedirectMode RedirectMode { get; set; }
        /// <summary>
        /// The domain your website is hosted on  <span style="color: red;">Required if you specify iframe on any of the signers</span>)
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// The signer is returned to this url if something goes wrong. <span style="color: red;">Required if you specify redirect on any of the signers </span>
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// The signer is returned to this url if the signing has been canceled  <span style="color: red;">Required if you specify redirect on any of the signers </span>
        /// </summary>
        public string Cancel { get; set; }
        /// <summary>
        /// The signer is returned to this url after a successfull signing  <span style="color: red;">Required if you specify redirect on any of the signers </span>
        /// </summary>
        public string Success { get; set; }
 

        
    }

}
