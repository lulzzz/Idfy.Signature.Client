using System.Collections.Generic;

namespace Idfy.Signature.Models.Misc
{
    public class Security
    {
        /// <summary>
        /// (Coming soon) The link can only be used one time 
        /// </summary>
        public bool OneTimeUse { get; set; }

        /// <summary>
        /// (Coming soon) Define a list of IP's that are allowed to see / sign the document 
        /// </summary>
        public List<string> IpWhiteList { get; set; }
    }
}