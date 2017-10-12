using System.Collections.Generic;

namespace Idfy.Signature.Models.Misc
{
    public class ExtraInfo
    {
        public Addon Addon { get; set; }
        public IDictionary<string, string> SpecialProperties { get; set; }
    }
}