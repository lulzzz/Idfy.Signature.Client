using System;
using System.Threading.Tasks;
using Idfy.Signature.Models.Attachment;
using Idfy.Signature.Models.DocumentFile;
using Idfy.Signature.Models.DocumentInfo;
using Idfy.Signature.Models.Misc;
using Idfy.Signature.Models.Sign;

namespace Idfy.Signature.Client.Client
{
    public interface ISignClient
    {
        /// <summary>
        /// Start an asynchronous signing process (Signer is notified by mail/sms and can sign when they want to)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateDocumentResponse> Create(CreateDocumentRequest request);
        /// <summary>
        /// Get the entire document data object except data to sign
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<CreateDocumentResponse> Get(Guid documentId);
        /// <summary>
        /// Update an asynchronous signing process
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateDocumentRequest> Update(Guid documentId, UpdateDocumentRequest request);
        /// <summary>
        /// Cancel an async sign job
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task Cancel(Guid documentId);
        /// <summary>
        /// Get document status
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<DocumentStatus> GetStatus(Guid documentId);

        /// <summary>
        /// Get information about a specific document
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<DocumentInfoResponse> GetSummary(Guid documentId);
        /// <summary>
        /// Query your documents
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DocumentInfoResponse> List(DocumentInfoRequest request);

        /// <summary>
        /// Get a document file
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Task<DocumentFileResponse> GetDocumentFile(Guid documentId, FileFormat? fileFormat);

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



        string OverrideBaseUrl { set; }
        string OverrideOauthTokenUrl { set; }
    }
}