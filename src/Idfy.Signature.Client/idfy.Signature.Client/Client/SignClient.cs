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

        public SignClient(Guid accountId, string oauthClientId, string oauthSecret, string scope = OauthScopes.Root, bool isProd = false) :
            base(accountId, oauthClientId, oauthSecret, scope, isProd)
        {
        }

        public string OverrideBaseUrl
        {
            set
            {
                if (!value.EndsWith("/"))
                    value += "/";
                BaseUrl = value;
            }
        }

        public string OverrideOauthTokenUrl
        {
            set
            {
                if (!value.EndsWith("/"))
                    value += "/";
                base.TokenEnpoint = value;
            }
        }

        public async Task<CreateDocumentResponse> CreateDocument(CreateDocumentRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.Create(AccountId);

            var result = await HttpWrapper.RunPostAsync(url, request, Token);

            return result.Deserialize<CreateDocumentResponse>();
        }

        public async Task<CreateDocumentResponse> GetDocument(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.Get(AccountId, documentId);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);
            return result.Deserialize<CreateDocumentResponse>();
        }

        public async Task<UpdateDocumentRequest> UpdateDocument(Guid documentId, UpdateDocumentRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.Update(AccountId, documentId);

            var result = await HttpWrapper.RunPatchAsync(url, request, Token);

            return result.Deserialize<UpdateDocumentRequest>();
        }

        public async Task CancelDocument(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.Cancel(AccountId, documentId);
            await HttpWrapper.RunPutAsync(url, "", Token);
        }

        public async Task<Status> GetDocumentStatus(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.Status(AccountId, documentId);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);

            return result.Deserialize<Status>();
        }
        
        public async Task<DocumentSummary> GetDocumentSummary(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.GetSummary(AccountId, documentId);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);

            return result.Deserialize<DocumentSummary>();
        }

        public async Task<DocumentSummary> ListDocuments(ListDocumentsRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.GetList(AccountId);

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

            return result.Deserialize<DocumentSummary>();
        }

        public async Task<IEnumerable<NotificationLogItem>> ListNotifications(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.ListNotifications(AccountId, documentId);
            var result = await HttpWrapper.RunGetQueryAsync(url, Token);
            return result.Deserialize<List<NotificationLogItem>>();
        }

        public async Task<DocumentFileResponse> GetFile(Guid documentId, FileFormat fileFormat)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.GetDocumentFile(AccountId, documentId, fileFormat);

            var result = await HttpWrapper.RunDownloadAsync(url, Token);

            return new DocumentFileResponse()
            {
                Document = result.Bytes,
                DocumentId = documentId,
                FileFormat = fileFormat,
                FileName=result.Filename,
            };
        }

        public async  Task<DocumentFileResponse> GetSignerFile(Guid documentId, Guid signerId, SignerFileFormat fileFormat)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.GetSignerFile(AccountId, documentId,signerId, fileFormat);

            var result = await HttpWrapper.RunDownloadAsync(url, Token);

            return new DocumentFileResponse()
            {
                Document = result.Bytes,
                DocumentId = documentId,
                FileFormat = fileFormat==SignerFileFormat.native ? FileFormat.native : FileFormat.standard_packaging,
                FileName = result.Filename,
            };
        }


        public async Task<Guid> AddAttachment(AttachmentRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.AddAttachment(AccountId);

            var result = await HttpWrapper.RunPostAsync(url, request, Token);

            var attachment = result.Deserialize<AttachmentResponse>();

            return attachment.Id;
        }

        public async Task<AttachmentResponse> GetAttachment(Guid documentId, Guid attachmentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.GetAttachment(AccountId, documentId, attachmentId);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);

            return result.Deserialize<AttachmentResponse>();
        }

        public async Task<List<AttachmentListItem>> ListAttachments(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.ListAttachments(AccountId, documentId);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);

            return result.Deserialize<List<AttachmentListItem>>();
        }

        public async Task DeleteAttachment(Guid documentId, Guid attachmentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.DeleteAttachment(AccountId, documentId, attachmentId);

            await HttpWrapper.RunDeleteAsync(url, Token);
        }

        public async Task<AttachmentResponse> UpdateAttachment(Guid documentId, UpdateAttachmentRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.UpdateAttachment(AccountId, documentId);
            var response = await HttpWrapper.RunPutAsync(url, request, Token);

            return response.Deserialize<AttachmentResponse>();
        }

        public async Task<AttachmentFileResponse> GetAttachmentFile(Guid documentId, Guid attachmentId, FileFormat fileFormat)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.GetAttachmentFile(AccountId, documentId, attachmentId, fileFormat);

            var result = await HttpWrapper.RunDownloadAsync(url, Token);

            return new AttachmentFileResponse()
            {
                Document = result.Bytes,
                DocumentId = documentId,
                FileFormat = fileFormat,
                FileName = result.Filename,
                AttachmentId = attachmentId
            };
        }

        public async Task<AttachmentFileResponse> GetAttachmentFileForSigner(Guid documentId, Guid attachmentId, Guid signerId, SignerFileFormat fileFormat)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.GetAttachmentSignerFile(AccountId, documentId, attachmentId, signerId, fileFormat);

            var result = await HttpWrapper.RunDownloadAsync(url, Token);

            return new AttachmentFileResponse()
            {
                AttachmentId = attachmentId,
                Document = result.Bytes,
                DocumentId = documentId,
                FileFormat = fileFormat == SignerFileFormat.native ? FileFormat.native : FileFormat.standard_packaging,
                FileName = result.Filename,
            };
        }

        public async Task<SignerResponse> GetSigner(Guid documentId, Guid signerId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.GetSigner(AccountId, documentId, signerId);
            var result = await HttpWrapper.RunGetQueryAsync(url, Token);
            return result.Deserialize<SignerResponse>();
        }

        public async Task<SignerResponse> AddSigner(Guid documentId, Signer signer)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.AddSigner(AccountId, documentId);
            var result = await HttpWrapper.RunPostAsync(url, signer, Token);
            return result.Deserialize<SignerResponse>();
        }

        public async Task RemoveSigner(Guid documentId, Guid signerId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.RemoveSigner(AccountId, documentId, signerId);
            await HttpWrapper.RunDeleteAsync(url, Token);
        }

        public async Task<UpdateSignerRequest> UpdateSigner(Guid documentId, Guid signerId, UpdateSignerRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.UpdateSigner(AccountId, documentId, signerId);
            var result = await HttpWrapper.RunPatchAsync(url, request, Token);
            return result.Deserialize<UpdateSignerRequest>();
        }

        public async Task<IEnumerable<SignerResponse>> ListSigners(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.ListSigners(AccountId, documentId);
            var response = await HttpWrapper.RunGetQueryAsync(url, Token);
            return response.Deserialize<IEnumerable<SignerResponse>>();
        }

        public async Task<JwtValidationResponse> ValidateJwt(JwtValidationRequest jwt)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEndpoints.ValidateJwt(AccountId);
            var response = await HttpWrapper.RunPostAsync(url, jwt, Token);
            return response.Deserialize<JwtValidationResponse>();
        }


    }
}