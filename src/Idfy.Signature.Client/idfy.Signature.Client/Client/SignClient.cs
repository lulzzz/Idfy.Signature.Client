using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Idfy.Signature.Models;
using Idfy.Signature.Models.Attachment;
using Idfy.Signature.Models.Documents;
using Idfy.Signature.Models.File;
using Idfy.Signature.Models.Misc;
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
            var url = BaseUrl + SignatureEnpoints.Create(AccountId);

            var result = await HttpWrapper.RunPostAsync(url, request, Token);

            return result.Deserialize<CreateDocumentResponse>();
        }

        public async Task<CreateDocumentResponse> GetDocument(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.Get(AccountId, documentId);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);
            return result.Deserialize<CreateDocumentResponse>();
        }

        public async Task<UpdateDocumentRequest> UpdateDocument(Guid documentId, UpdateDocumentRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.Update(AccountId, documentId);

            var result = await HttpWrapper.RunPatchAsync(url, request, Token);

            return result.Deserialize<UpdateDocumentRequest>();
        }

        public async Task CancelDocument(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.Cancel(AccountId, documentId);
            await HttpWrapper.RunPutAsync(url, "", Token);
        }

        public async Task<DocumentStatus> GetDocumentStatus(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.Status(AccountId, documentId);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);

            return result.Deserialize<DocumentStatus>();
        }
        
        public async Task<DocumentSummary> GetDocumentSummary(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.GetSummary(AccountId, documentId);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);

            return result.Deserialize<DocumentSummary>();
        }

        public async Task<DocumentSummary> ListDocuments(ListDocumentsRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.GetList(AccountId);

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

        public async Task<DocumentFileResponse> GetFile(Guid documentId, FileFormat fileFormat)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.GetDocumentFile(AccountId, documentId, fileFormat);

            var result = await HttpWrapper.RunDownloadAsync(url, Token);

            return new DocumentFileResponse()
            {
                Document = result.Bytes,
                DocumentId = documentId,
                FileFormat = fileFormat,
                FileName=result.Filename,
            };
        }


        public async Task<Guid> AddAttachment(AttachmentRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.AddAttachment(AccountId);

            var result = await HttpWrapper.RunPostAsync(url, request, Token);

            var attachment = result.Deserialize<AttachmentResponse>();

            return attachment.Id;
        }

        public async Task<Attachment> GetAttachment(Guid attachmentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.GetAttachment(AccountId, attachmentId);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);

            return result.Deserialize<Attachment>();
        }

        public async Task<SignerResponse> GetSigner(Guid documentId, Guid signerId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.GetSigner(AccountId, documentId, signerId);
            var result = await HttpWrapper.RunGetQueryAsync(url, Token);
            return result.Deserialize<SignerResponse>();
        }

        public async Task<SignerResponse> AddSigner(Guid documentId, Signer signer)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.AddSigner(AccountId, documentId);
            var result = await HttpWrapper.RunPostAsync(url, signer, Token);
            return result.Deserialize<SignerResponse>();
        }

        public async Task RemoveSigner(Guid documentId, Guid signerId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.RemoveSigner(AccountId, documentId, signerId);
            await HttpWrapper.RunDeleteAsync(url, Token);
        }

        public async Task UpdateSigner(Guid documentId, Guid signerId, UpdateSignerRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.UpdateSigner(AccountId, documentId, signerId);
            await HttpWrapper.RunPatchAsync(url, request, Token);
        }

        public async Task<IEnumerable<SignerResponse>> ListSigners(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.ListSigners(AccountId, documentId);
            var response = await HttpWrapper.RunGetQueryAsync(url, Token);
            return response.Deserialize<IEnumerable<SignerResponse>>();
        }

    }
}