using System;
using Idfy.Signature.Models.File;

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
        internal static string Cancel(Guid accountId, Guid documentId) => $"api/documents/{accountId}/{documentId}/cancel";
        internal static string Status(Guid accountId, Guid documentId) => $"api/documents/{accountId}/{documentId}/status";
        internal static string GetSummary(Guid accountId, Guid documentId) => $"api/documents/{accountId}/{documentId}/summary";
        internal static string GetList(Guid accountId) => $"api/documents/{accountId}/list";

        #endregion


        #region Files

        internal static string GetDocumentFile(Guid accountId, Guid documentId, FileFormat? fileFormat) => $"api/files/{accountId}/{documentId}?fileFormat={fileFormat}";

        internal static string GetSignerFile(Guid accountId, Guid documentId, Guid signerId, SignerFileFormat? fileFormat) => $"api/files/{accountId}/{documentId}?fileFormat={fileFormat}&signerId={signerId}";


        #endregion

        #region Attachements

        internal static string AddAttachment(Guid accountId) => $"api/attachments/{accountId}";
        internal static string GetAttachment(Guid accountId, Guid id) => $"api/attachments/{accountId}/{id}";


        #endregion

        internal static string GetSigner(Guid accountId, Guid documentId, Guid signerId) => $"api/signers/{accountId}/{documentId}/{signerId}";
        internal static string AddSigner(Guid accountId, Guid documentId) => $"api/signers/{accountId}/{documentId}";
        internal static string RemoveSigner(Guid accountId, Guid documentId, Guid signerId) => $"api/signers/{accountId}/{documentId}/{signerId}";
        internal static string UpdateSigner(Guid accountId, Guid documentId, Guid signerId) => $"api/signers/{accountId}/{documentId}/{signerId}";
        internal static string ListSigners(Guid accountId, Guid documentId) => $"api/signers/{accountId}/{documentId}";
    }
}