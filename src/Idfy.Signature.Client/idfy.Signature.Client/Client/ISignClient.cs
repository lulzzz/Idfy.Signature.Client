using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Idfy.Signature.Models.Attachment;
using Idfy.Signature.Models.Documents;
using Idfy.Signature.Models.File;
using Idfy.Signature.Models.Misc;
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
        Task<CreateDocumentResponse> GetDocument(Guid documentId);
        /// <summary>
        /// Update an asynchronous signing process
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateDocumentRequest> UpdateDocument(Guid documentId, UpdateDocumentRequest request);
        /// <summary>
        /// Cancel an async sign job
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task CancelDocument(Guid documentId);
        /// <summary>
        /// Get document status
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<Status> GetDocumentStatus(Guid documentId);

        /// <summary>
        /// Get information about a specific document
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<DocumentSummary> GetDocumentSummary(Guid documentId);
        /// <summary>
        /// Query your documents
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DocumentSummary> ListDocuments(ListDocumentsRequest request);

        /// <summary>
        /// Get a document file
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Task<DocumentFileResponse> GetFile(Guid documentId, FileFormat fileFormat);

        /// <summary>
        /// Add an attachement to use in the sign process. Returns attachment ID
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Guid> AddAttachment(AttachmentRequest request);

        /// <summary>
        /// Get an attachement
        /// </summary>
        /// <param name="attachmentId"></param>
        /// <returns></returns>
        Task<Attachment> GetAttachment(Guid attachmentId);

        /// <summary>
        /// Get a signer
        /// </summary>
        /// <returns></returns>
        Task<SignerResponse> GetSigner(Guid documentId, Guid signerId);
        
        /// <summary>
        /// Adds a signer to an existing document
        /// </summary>
        /// <returns></returns>
        Task<SignerResponse> AddSigner(Guid documentId, Signer signer);

        /// <summary>
        /// Removes a signer from a document
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerId"></param>
        /// <returns></returns>
        Task RemoveSigner(Guid documentId, Guid signerId);

        /// <summary>
        /// Update a signer on a document
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerId"></param>
        /// <returns></returns>
        Task<UpdateSignerRequest> UpdateSigner(Guid documentId, Guid signerId, UpdateSignerRequest request);

        /// <summary>
        /// Lists all the signers for a an existing document
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<IEnumerable<SignerResponse>> ListSigners(Guid documentId);



        string OverrideBaseUrl { set; }
        string OverrideOauthTokenUrl { set; }
    }
}