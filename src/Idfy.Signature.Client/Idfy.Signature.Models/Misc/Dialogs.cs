namespace Idfy.Signature.Models.Misc
{
    public class Dialogs
    {
        /// <summary>
        /// Will be presented before the document is signed
        /// </summary>
        public DialogBefore Before { get; set; }
        /// <summary>
        /// Will be presented after the document is signed
        /// </summary>
        public Dialog After { get; set; }
    }

    public class DialogBefore : Dialog
    {
        /// <summary>
        /// Adds a checkbox the user have to check to confirm that the have read the dialog before they can continue
        /// </summary>
        public bool UseCheckBox { get; set; }
    }

    public class Dialog
    {
        /// <summary>
        /// The dialog title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The dialog text
        /// </summary>
        public string Message { get; set; }
    }
    
}