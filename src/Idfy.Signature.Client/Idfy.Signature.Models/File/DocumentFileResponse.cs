﻿using System;

namespace Idfy.Signature.Models.File
{

    public class AttachmentFileResponse : DocumentFileResponse
    {
        public Guid AttachmentId { get; set; }
    }

    public class AttachmentSignerFileResponse : SignerFileResponse
    {
        public Guid AttachmentId { get; set; }
    }

    public class DocumentFileResponse
    {
        public Guid DocumentId { get; set; }
        public byte[] Document { get; set; }
        public FileFormat FileFormat { get; set; }
        public string FileName { get; set; }
    }

    public class SignerFileResponse
    {
        public Guid DocumentId { get; set; }
        public byte[] Document { get; set; }
        public SignerFileFormat FileFormat { get; set; }

        public string FileName { get; set; }

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