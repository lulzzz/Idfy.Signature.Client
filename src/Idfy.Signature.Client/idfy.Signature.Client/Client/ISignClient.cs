using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Idfy.Signature.Models.Attachment;
using Idfy.Signature.Models.Documents;
using Idfy.Signature.Models.File;
using Idfy.Signature.Models.JWT;
using Idfy.Signature.Models.Notifications;
using Idfy.Signature.Models.Signers;

namespace Idfy.Signature.Client.Client
{
    /// <summary>
    /// Idfy Signature client, this can be used with our signature api
    /// </summary>
    public interface ISignClient
    {
        /// <summary>
        /// Start an asynchronous signing process (Signer is notified by mail/sms and can sign when they want to)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateDocumentResponse> CreateDocument(CreateDocumentRequest request);
        
        /// <summary>
        /// Get the entire document data object except data to sign
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<CreateDocumentResponse> RetrieveDocument(Guid documentId);

        /// <summary>
        /// List documents
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CreateDocumentResponse>> ListDocuments();

        /// <summary>
        /// Update an asynchronous signing process
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateDocumentRequest> UpdateDocument(Guid documentId, UpdateDocumentRequest request);

        /// <summary>
        /// Cancel an async sign job
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="reason">Why is the document canceled?</param>
        /// <returns></returns>
        Task CancelDocument(Guid documentId, string reason);
        /// <summary>
        /// Get document status
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<Status> RetrieveDocumentStatus(Guid documentId);

        /// <summary>
        /// Get information about a specific document
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<DocumentSummary> RetrieveDocumentSummary(Guid documentId);

        /// <summary>
        /// Query your documents
        /// </summary>
        /// <param name="request"></param>
        /// <param name="nextLink">If you have multiple pages with result, insert the nextlink you retrive here</param>
        /// <returns></returns>
        Task<ListResult<DocumentSummary>> ListDocumentSummaries(ListDocumentsRequest request, string nextLink = null);
        
        /// <summary>
        /// Get a document file
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Task<DocumentFileResponse> RetrieveFile(Guid documentId, FileFormat fileFormat);


        /// <summary>
        /// Get a document file
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Task<DocumentFileResponse> RetrieveSignerFile(Guid documentId, Guid signerId, SignerFileFormat fileFormat);

        /// <summary>
        /// Add an attachment to use in the sign process. Returns attachment ID
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Guid> CreateAttachment(Guid documentId, AttachmentRequest request);

        /// <summary>
        /// Get an attachment
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        /// <returns></returns>
        Task<AttachmentResponse> RetrieveAttachment(Guid documentId, Guid attachmentId);

        /// <summary>
        /// List all attachments for a document
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<List<AttachmentListItem>> ListAttachments(Guid documentId);

        /// <summary>
        /// Delete an attachment on a specified document
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        /// <returns></returns>
        Task DeleteAttachment(Guid documentId, Guid attachmentId);

        /// <summary>
        /// Update an attachment on a specified document
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AttachmentResponse> UpdateAttachment(Guid documentId, Guid attachmentId, UpdateAttachmentRequest request);

        /// <summary>
        /// Get an attachment file
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Task<AttachmentFileResponse> RetrieveAttachmentFile(Guid documentId, Guid attachmentId, FileFormat fileFormat);

        /// <summary>
        /// Retrieves a signed attachment file for a specific signer
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        /// <param name="signerId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Task<AttachmentFileResponse> RetrieveAttachmentSignerFile(Guid documentId, Guid attachmentId, Guid signerId, SignerFileFormat fileFormat);

        /// <summary>
        /// Get a signer
        /// </summary>
        /// <returns></returns>
        Task<SignerResponse> RetrieveSigner(Guid documentId, Guid signerId);
        
        /// <summary>
        /// Adds a signer to an existing document
        /// </summary>
        /// <returns></returns>
        Task<SignerResponse> CreateSigner(Guid documentId, Signer signer);

        /// <summary>
        /// Removes a signer from a document
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerId"></param>
        /// <returns></returns>
        Task DeleteSigner(Guid documentId, Guid signerId);

        /// <summary>
        /// Update a signer on a document
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateSignerRequest> UpdateSigner(Guid documentId, Guid signerId, UpdateSignerRequest request);

        /// <summary>
        /// Lists all the signers for a an existing document
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<IEnumerable<SignerResponse>> ListSigners(Guid documentId);

        /// <summary>
        /// Validate and parse jwt you receive on redirect
        /// </summary>
        /// <param name="jwt"></param>
        /// <returns></returns>
        Task<JwtValidationResponse> ValidateJwt(JwtValidationRequest jwt);

        /// <summary>
        /// List all sent/attemped to send notifications for a document
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<IEnumerable<NotificationLogItem>> ListNotifications(Guid documentId);


        string OverrideBaseUrl { set; }
        string OverrideOauthTokenUrl { set; }
    }
}