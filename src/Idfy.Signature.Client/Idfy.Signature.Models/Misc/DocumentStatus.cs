namespace Idfy.Signature.Models.Misc
{
    public enum DocumentStatus
    {
        unsigned,
        waiting_for_attachments,
        partialsigned,
        signed,
        canceled,
        expired
    }
}