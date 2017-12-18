using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Idfy.Signature.Models;
using Idfy.Signature.Models.Attachment;
using Idfy.Signature.Models.Documents;
using Idfy.Signature.Models.File;
using Idfy.Signature.Models.JWT;
using Idfy.Signature.Models.Notifications;
using Idfy.Signature.Models.Signers;

namespace Idfy.Signature.Client.Client
{
    public class SignClient : BaseSignClient, ISignClient
    {

        public SignClient(string oauthClientId, string oauthSecret, string scope = OauthScopes.Root, bool isProd = false) :
            base(oauthClientId, oauthSecret, scope, isProd)
        {
        }

        public string OverrideBaseUrl
        {
            set => BaseUrl = value;
        }

        public string OverrideOauthTokenUrl
        {
            set => TokenEnpoint = value;
        }

        public async Task<CreateDocumentResponse> CreateDocument(CreateDocumentRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunPostAsync(SignatureEndpoints.CreateDocument, request, Token);
            return result.Deserialize<CreateDocumentResponse>();
        }

        public async Task<CreateDocumentResponse> RetrieveDocument(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunGetQueryAsync(SignatureEndpoints.RetrieveDocument(documentId), Token);
            return result.Deserialize<CreateDocumentResponse>();
        }
        
        public async Task<IEnumerable<CreateDocumentResponse>> ListDocuments()
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunGetQueryAsync(SignatureEndpoints.ListDocuments, Token);
            return result.Deserialize<List<CreateDocumentResponse>>();
        }

        public async Task<UpdateDocumentRequest> UpdateDocument(Guid documentId, UpdateDocumentRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunPatchAsync(SignatureEndpoints.UpdateDocument(documentId), request, Token);
            return result.Deserialize<UpdateDocumentRequest>();
        }

        public async Task CancelDocument(Guid documentId, string reason)
        {
            Token = OauthClient.GetAccessToken(Scope);
            await HttpWrapper.RunPostAsync(SignatureEndpoints.CancelDocument(documentId, reason), "", Token);
        }

        public async Task<Status> RetrieveDocumentStatus(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunGetQueryAsync(SignatureEndpoints.RetrieveDocumentStatus(documentId), Token);
            return result.Deserialize<Status>();
        }
        
        public async Task<DocumentSummary> RetrieveDocumentSummary(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunGetQueryAsync(SignatureEndpoints.RetrieveDocumentSummary(documentId), Token);
            return result.Deserialize<DocumentSummary>();
        }

        public async Task<IEnumerable<DocumentSummary>> ListDocumentSummaries(ListDocumentsRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = SignatureEndpoints.ListDocumentSummaries;

            if (!string.IsNullOrEmpty(request.ExternalId))
            {
                url += $"&externalId={request.ExternalId}";
            }
            if (!string.IsNullOrEmpty(request.NameOfSigner))
            {
                url += $"&nameOfSigner={request.NameOfSigner}";
            }
            if (!string.IsNullOrEmpty(request.Tags))
            {
                url += $"&tags={request.Tags}";
            }
            if (request.FromDate != null)
            {
                url += $"&fromDate={request.FromDate}";
            }
            if (request.ToDate != null)
            {
                url += $"&toDate={request.ToDate}";
            }
            if (request.SignedDate != null)
            {
                url += $"&signedDate={request.SignedDate}";
            }
            if (request.SignerId != null)
            {
                url += $"&signerId={request.SignerId}";
            }
            if (!string.IsNullOrEmpty(request.ExternalSignerId))
            {
                url += $"&externalSignerId={request.ExternalSignerId}";
            }
            if (request.LastUpdated != null)
            {
                url += $"&lastUpdated={request.LastUpdated}";
            }
            if (request.Status != null)
            {
                url += $"&status={request.Status}";
            }

            url = url.ReplaceFirst("&", "?");
            var result = await HttpWrapper.RunPostAsync(url, request, Token);
            return result.Deserialize<IEnumerable<DocumentSummary>>();
        }

        public async Task<IEnumerable<NotificationLogItem>> ListNotifications(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunGetQueryAsync(SignatureEndpoints.ListNotifications(documentId), Token);
            return result.Deserialize<List<NotificationLogItem>>();
        }

        public async Task<DocumentFileResponse> RetrieveFile(Guid documentId, FileFormat fileFormat)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunDownloadAsync(SignatureEndpoints.RetrieveFile(documentId, fileFormat), Token);
            return new DocumentFileResponse()
            {
                Document = result.Bytes,
                DocumentId = documentId,
                FileFormat = fileFormat,
                FileName=result.Filename,
            };
        }

        public async  Task<DocumentFileResponse> RetrieveSignerFile(Guid documentId, Guid signerId, SignerFileFormat fileFormat)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunDownloadAsync(
                SignatureEndpoints.RetrieveSignerFile(documentId, signerId, fileFormat), Token);
            
            return new DocumentFileResponse()
            {
                Document = result.Bytes,
                DocumentId = documentId,
                FileFormat = fileFormat==SignerFileFormat.native ? FileFormat.native : FileFormat.standard_packaging,
                FileName = result.Filename,
            };
        }


        public async Task<Guid> CreateAttachment(Guid documentId, AttachmentRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunPostAsync(SignatureEndpoints.CreateAttachment(documentId), request, Token);
            var attachment = result.Deserialize<AttachmentResponse>();
            return attachment.Id;
        }

        public async Task<AttachmentResponse> RetrieveAttachment(Guid documentId, Guid attachmentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunGetQueryAsync(SignatureEndpoints.RetrieveAttachment(documentId, attachmentId), Token);
            return result.Deserialize<AttachmentResponse>();
        }

        public async Task<List<AttachmentListItem>> ListAttachments(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunGetQueryAsync(SignatureEndpoints.ListAttachments(documentId), Token);
            return result.Deserialize<List<AttachmentListItem>>();
        }

        public async Task DeleteAttachment(Guid documentId, Guid attachmentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            await HttpWrapper.RunDeleteAsync(SignatureEndpoints.DeleteAttachment(documentId, attachmentId), Token);
        }

        public async Task<AttachmentResponse> UpdateAttachment(Guid documentId, Guid attachmentId, UpdateAttachmentRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var response = await HttpWrapper.RunPatchAsync(
                SignatureEndpoints.UpdateAttachment(documentId, attachmentId), request,Token);
            return response.Deserialize<AttachmentResponse>();
        }

        public async Task<AttachmentFileResponse> RetrieveAttachmentFile(Guid documentId, Guid attachmentId, FileFormat fileFormat)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunDownloadAsync(
                SignatureEndpoints.RetrieveAttachmentFile(documentId, attachmentId, fileFormat), Token);
            
            return new AttachmentFileResponse()
            {
                Document = result.Bytes,
                DocumentId = documentId,
                FileFormat = fileFormat,
                FileName = result.Filename,
                AttachmentId = attachmentId
            };
        }

        public async Task<AttachmentFileResponse> RetrieveAttachmentSignerFile(Guid documentId, Guid attachmentId, Guid signerId, SignerFileFormat fileFormat)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunDownloadAsync(
                SignatureEndpoints.RetrieveAttachmentSignerFile(documentId, attachmentId, signerId, fileFormat), Token);

            return new AttachmentFileResponse()
            {
                AttachmentId = attachmentId,
                Document = result.Bytes,
                DocumentId = documentId,
                FileFormat = fileFormat == SignerFileFormat.native ? FileFormat.native : FileFormat.standard_packaging,
                FileName = result.Filename,
            };
        }

        public async Task<SignerResponse> RetrieveSigner(Guid documentId, Guid signerId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunGetQueryAsync(SignatureEndpoints.RetrieveSigner(documentId, signerId), Token);
            return result.Deserialize<SignerResponse>();
        }

        public async Task<SignerResponse> CreateSigner(Guid documentId, Signer signer)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunPostAsync(SignatureEndpoints.CreateSigner(documentId), signer, Token);
            return result.Deserialize<SignerResponse>();
        }

        public async Task DeleteSigner(Guid documentId, Guid signerId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            await HttpWrapper.RunDeleteAsync(SignatureEndpoints.DeleteSigner(documentId, signerId), Token);
        }

        public async Task<UpdateSignerRequest> UpdateSigner(Guid documentId, Guid signerId, UpdateSignerRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var result = await HttpWrapper.RunPatchAsync(SignatureEndpoints.UpdateSigner(documentId, signerId), request, Token);
            return result.Deserialize<UpdateSignerRequest>();
        }

        public async Task<IEnumerable<SignerResponse>> ListSigners(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var response = await HttpWrapper.RunGetQueryAsync(SignatureEndpoints.ListSigners(documentId), Token);
            return response.Deserialize<IEnumerable<SignerResponse>>();
        }

        public async Task<JwtValidationResponse> ValidateJwt(JwtValidationRequest jwt)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var response = await HttpWrapper.RunPostAsync(SignatureEndpoints.ValidateJwt, jwt, Token);
            return response.Deserialize<JwtValidationResponse>();
        }
    }
}