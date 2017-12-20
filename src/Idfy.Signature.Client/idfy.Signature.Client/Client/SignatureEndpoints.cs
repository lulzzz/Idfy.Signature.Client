using System;
using Idfy.Signature.Models.File;

namespace Idfy.Signature.Client.Client
{
    internal static class SignatureEndpoints
    {
        internal const string BaseUrl = "https://api.idfy.io/signature/";

        #region Documents
        
        internal static string CreateDocument => $"documents";
        internal static string RetrieveDocument(Guid documentId) => $"documents/{documentId}";
        internal static string ListDocuments => $"documents";
        internal static string UpdateDocument(Guid documentId) => $"documents/{documentId}";
        internal static string CancelDocument(Guid documentId, string reason) => $"documents/{documentId}/cancel?reason={reason}";
        internal static string RetrieveDocumentStatus(Guid documentId) => $"documents/{documentId}/status";
        internal static string RetrieveDocumentSummary(Guid documentId) => $"documents/{documentId}/summary";
        internal static string ListDocumentSummaries => $"documents/summary";
        
        #endregion


        #region Files

        internal static string RetrieveFile(Guid documentId, FileFormat? fileFormat) =>
            $"files/documents/{documentId}?fileFormat={fileFormat}";

        internal static string RetrieveSignerFile(Guid documentId, Guid signerId, SignerFileFormat? fileFormat) =>
            $"files/documents/{documentId}/signers/{signerId}?fileFormat={fileFormat}";
        
        internal static string RetrieveAttachmentFile(Guid documentId, Guid attachmentId, FileFormat? fileFormat) =>
            $"files/documents/{documentId}/attachments/{attachmentId}?fileFormat={fileFormat}";

        internal static string RetrieveAttachmentSignerFile(Guid documentId, Guid attachmentId, Guid signerId, SignerFileFormat? fileFormat) =>
            $"files/documents/{documentId}/attachments/{attachmentId}/signers/{signerId}?fileFormat={fileFormat}";

        #endregion

        #region Attachments

        internal static string CreateAttachment(Guid documentId) => $"documents/{documentId}/attachments";
        internal static string RetrieveAttachment(Guid documentId, Guid id) => $"documents/{documentId}/attachments/{id}";

        internal static string DeleteAttachment(Guid documentId, Guid id) => $"documents/{documentId}/attachments/{id}";
        internal static string UpdateAttachment(Guid documentId, Guid id) => $"documents/{documentId}/attachments/{id}";
        internal static string ListAttachments(Guid documentId) => $"documents/{documentId}/attachments";

        #endregion

        #region Signers
        
        internal static string RetrieveSigner(Guid documentId, Guid signerId) => $"documents/{documentId}/signers/{signerId}";
        internal static string CreateSigner(Guid documentId) => $"documents/{documentId}/signers";
        internal static string DeleteSigner(Guid documentId, Guid signerId) => $"documents/{documentId}/signers/{signerId}";
        internal static string UpdateSigner(Guid documentId, Guid signerId) => $"documents/{documentId}/signers/{signerId}";
        internal static string ListSigners(Guid documentId) => $"documents/{documentId}/signers";
        
        #endregion
        
        #region JWT
        
        public static string ValidateJwt => $"jwt";
        
        #endregion

        #region Notifications

        internal static string ListNotifications(Guid documentId) => $"documents/{documentId}/notifications";

        #endregion

    }
}