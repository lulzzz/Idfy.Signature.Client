using System;
using Idfy.Signature.Models.DocumentFile;

namespace Idfy.Signature.Client.Client
{
    internal static class SignatureEnpoints
    {
        internal const string BaseUrlProd = "https://sign-api.idfy.io/";
        internal const string BaseUrlTest = "https://sign-api-test.idfy.io/";

        #region Documents
        internal static string Create(Guid accountId) => $"api/documents/{accountId}";
        internal static string Get(Guid accountId, Guid documentId) => $"api/documents/{accountId}/{documentId}";
        internal static string Update(Guid accountId, Guid documentId) => $"api/documents/{accountId}/{documentId}";
        internal static string Cancel(Guid accountId, Guid documentId) => $"api/documents/cancel/{accountId}/{documentId}";
        internal static string Status(Guid accountId, Guid documentId) => $"api/documents/status/{accountId}/{documentId}";
        internal static string GetSummary(Guid accountId, Guid documentId) => $"api/documents/summary/{accountId}/{documentId}";
        internal static string GetList(Guid accountId) => $"api/documents/list/{accountId}";

        #endregion


        #region Files

        internal static string GetDocumentFile(Guid accountId, Guid documentId, FileFormat? fileFormat) => $"api/files/{accountId}?documentId={documentId}&fileFormat={fileFormat}";


        #endregion

        #region Attachements

        internal static string AddAttachment(Guid accountId) => $"api/attachments/{accountId}";
        internal static string GetAttachment(Guid accountId, Guid id) => $"api/attachments/{accountId}/{id}";


        #endregion

    }
}