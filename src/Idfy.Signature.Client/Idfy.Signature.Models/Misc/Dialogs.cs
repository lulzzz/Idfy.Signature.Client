namespace Idfy.Signature.Models.Misc
{
    public class Dialogs
    {
        /// <summary>
        /// Will be presented before the document is signed
        /// </summary>
        public Dialog Before { get; set; }
        /// <summary>
        /// Will be presented after the document is signed
        /// </summary>
        public Dialog After { get; set; }
    }

    public class Dialog
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
    
}