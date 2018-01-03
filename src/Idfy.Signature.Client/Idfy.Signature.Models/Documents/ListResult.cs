using System.Collections.Generic;

namespace Idfy.Signature.Models.Documents
{
    public class ListResult<T>
    {
        /// <summary>
        /// Link to the next results if not set there are less then the return limit of 1000
        /// </summary>
        public string NextLink { get; set; }

        /// <summary>
        /// The total amount of links (pages) for the list
        /// </summary>
        public int? TotalLinks { get; set; }

        /// <summary>
        /// List of results
        /// </summary>
        public IEnumerable<T> List { get; set; }
    }
}