namespace Idfy.Signature.Models.Documents
{
    public class CollectionWithPaging<T> : Collection<T>
    {
        /// <summary>
        /// The offset of the current page.
        /// </summary>
        /// <value>The offset of the current page.</value>
        public int? Offset { get; set; }

        /// <summary>
        /// The limit of the current paging options.
        /// </summary>
        /// <value>The limit of the current paging options.</value>
        public int? Limit { get; set; }

        /// <summary>
        /// The total size of the collection (irrespective of any paging options).
        /// </summary>
        /// <value>The total size of the collection.</value>
        public long Size { get; set; }

        public Links Links { get; set; }
    }

    public class Links
    {
        public string Next { get; set; }
        public string Previous { get; set; }
        public string First { get; set; }
    }

    public class Collection<T>
    {
        public T[] Data { get; set; }
    }
}