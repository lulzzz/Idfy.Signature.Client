using System.Collections.Generic;

namespace Idfy.Signature.Models.Misc
{
    public class ExtraInfoDocumentRequest
    {
        /// <summary>
        /// Add a list of the addons you want to order, some of them requires specialproperties (read more in our documentation). (Extra costs will occur for addons (except difi company info))
        /// </summary>
        public List<DocumentAddon> Addon { get; set; }
        /// <summary>
        /// Add a dictionay of special properties, see our documentation for more info
        /// </summary>
        public IDictionary<SpesialProperty, string> SpecialProperties { get; set; }
    }

    public class ExtraInfoDocumentResponse : ExtraInfoDocumentRequest
    {
        /// <summary>
        /// Results as a dictionary with json
        /// </summary>
        public IDictionary<DocumentAddon, string> Results { get; set; }
    }

    public class ExtraInfoSignerRequest
    {
        /// <summary>
        /// Add a list of the addons you want to order, some of them requires specialproperties (read more in our documentation). (Extra costs will occur for addons (except difi company info))
        /// </summary>
        public List<SignerAddon> Addon { get; set; }
        /// <summary>
        /// Add a dictionay of special properties, see our documentation for more info
        /// </summary>
        public IDictionary<SpesialProperty, string> SpecialProperties { get; set; }
    }

    public class ExtraInfoSignerResponse : ExtraInfoSignerRequest
    {
        /// <summary>
        /// Results as a dictionary with json result. See our documentation for model examples.
        /// </summary>
        public IDictionary<SignerAddon, string> Results { get; set; }
    }

}