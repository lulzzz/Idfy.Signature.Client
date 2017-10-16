using System;

namespace Idfy.Signature.Models.File
{
    public class DocumentFileResponse
    {
        public Guid DocumentId { get; set; }
        public byte[] Document { get; set; }
        public FileFormat FileFormat { get; set; }
    }

    public class SignerFileResponse
    {
        public Guid DocumentId { get; set; }
        public byte[] Document { get; set; }
        public SignerFileFormat FileFormat { get; set; }
    }

    public enum FileFormat
    {
        unsigned,
        native,
        standard_packaging,
        pades,
        xades
    }

    public enum SignerFileFormat
    {
        native,
        packaged
    }
}