using System;
using Idfy.Signature.Models.File;

namespace Idfy.Signature.Client.Client
{
    internal static class SignatureEndpoints
    {
        internal const string BaseUrl = "https://api.idfy.io/signature";

        #region Documents
        
        internal static string CreateDocument => $"{BaseUrl}/documents";
        internal static string RetrieveDocument(Guid documentId) => $"{BaseUrl}/documents/{documentId}";
        internal static string ListDocuments => $"{BaseUrl}/documents";
        internal static string UpdateDocument(Guid documentId) => $"{BaseUrl}/documents/{documentId}";
        internal static string CancelDocument(Guid documentId, string reason) => $"{BaseUrl}/documents/{documentId}/cancel?reason={reason}";
        internal static string RetrieveDocumentStatus(Guid documentId) => $"{BaseUrl}/documents/{documentId}/status";
        internal static string RetrieveDocumentSummary(Guid documentId) => $"{BaseUrl}/documents/{documentId}/summary";
        internal static string ListDocumentSummaries => $"{BaseUrl}/documents/summary";
        
        #endregion


        #region Files

        internal static string RetrieveFile(Guid documentId, FileFormat? fileFormat) =>
            $"{BaseUrl}/files/documents/{documentId}?fileFormat={fileFormat}";

        internal static string RetrieveSignerFile(Guid documentId, Guid signerId, SignerFileFormat? fileFormat) =>
            $"{BaseUrl}/files/documents/{documentId}/signers/{signerId}?fileFormat={fileFormat}";
        
        internal static string RetrieveAttachmentFile(Guid documentId, Guid attachmentId, FileFormat? fileFormat) =>
            $"{BaseUrl}/files/documents/{documentId}/attachments/{attachmentId}?fileFormat={fileFormat}";

        internal static string RetrieveAttachmentSignerFile(Guid documentId, Guid attachmentId, Guid signerId, SignerFileFormat? fileFormat) =>
            $"{BaseUrl}/files/documents/{documentId}/attachments/{attachmentId}/signers/{signerId}?fileFormat={fileFormat}";

        #endregion

        #region Attachments

        internal static string CreateAttachment(Guid documentId) => $"{BaseUrl}/documents/{documentId}/attachments";
        internal static string RetrieveAttachment(Guid documentId, Guid id) => $"{BaseUrl}/documents/{documentId}/attachments/{id}";

        internal static string DeleteAttachment(Guid documentId, Guid id) => $"{BaseUrl}/documents/{documentId}/attachments/{id}";
        internal static string UpdateAttachment(Guid documentId, Guid id) => $"{BaseUrl}/documents/{documentId}/attachments/{id}";
        internal static string ListAttachments(Guid documentId) => $"{BaseUrl}/documents/{documentId}/attachments";

        #endregion

        #region Signers
        
        internal static string RetrieveSigner(Guid documentId, Guid signerId) => $"{BaseUrl}/documents/{documentId}/signers/{signerId}";
        internal static string CreateSigner(Guid documentId) => $"{BaseUrl}/documents/{documentId}/signers";
        internal static string DeleteSigner(Guid documentId, Guid signerId) => $"{BaseUrl}/documents/{documentId}/signers/{signerId}";
        internal static string UpdateSigner(Guid documentId, Guid signerId) => $"{BaseUrl}/documents/{documentId}/signers/{signerId}";
        internal static string ListSigners(Guid documentId) => $"{BaseUrl}/documents/{documentId}/signers";
        
        #endregion
        
        #region JWT
        
        public static string ValidateJwt => $"{BaseUrl}/jwt";
        
        #endregion

        #region Notifications

        internal static string ListNotifications(Guid documentId) => $"{BaseUrl}/documents/{documentId}/notifications";

        #endregion

    }
}