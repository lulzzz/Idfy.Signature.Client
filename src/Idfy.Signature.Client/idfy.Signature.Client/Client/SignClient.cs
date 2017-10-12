using System;
using System.Threading.Tasks;
using Idfy.Signature.Models;
using Idfy.Signature.Models.Attachment;
using Idfy.Signature.Models.DocumentFile;
using Idfy.Signature.Models.DocumentInfo;
using Idfy.Signature.Models.Misc;
using Idfy.Signature.Models.Sign;

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

        public async Task<CreateDocumentResponse> Create(CreateDocumentRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.Create(AccountId);

            var result = await HttpWrapper.RunPostQueryAsync(url, request, Token);

            return Extensions.Deserialize<CreateDocumentResponse>(result);
        }

        public async Task<CreateDocumentResponse> Get(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.Get(AccountId, documentId);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);
            return Extensions.Deserialize<CreateDocumentResponse>(result);
        }

        public async Task<UpdateDocumentRequest> Update(Guid documentId, UpdateDocumentRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.Update(AccountId, documentId);

            var result = await HttpWrapper.RunPutAsync(url, request, Token);

            return Extensions.Deserialize<UpdateDocumentRequest>(result);
        }

        public async Task Cancel(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.Cancel(AccountId, documentId);

            var result = await HttpWrapper.RunPutAsync(url, "", Token);
        }

        public async Task<DocumentStatus> GetStatus(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.Status(AccountId, documentId);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);

            return Extensions.Deserialize<DocumentStatus>(result);
        }
        
        public async Task<DocumentInfoResponse> GetSummary(Guid documentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.GetSummary(AccountId, documentId);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);

            return Extensions.Deserialize<DocumentInfoResponse>(result);
        }

        public async Task<DocumentInfoResponse> List(DocumentInfoRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.GetList(AccountId);

            var result = await HttpWrapper.RunPostQueryAsync(url, request, Token);

            return Extensions.Deserialize<DocumentInfoResponse>(result);
        }

        public async Task<DocumentFileResponse> GetDocumentFile(Guid documentId, FileFormat? fileFormat)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.GetDocumentFile(AccountId, documentId, fileFormat);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);

            return Extensions.Deserialize<DocumentFileResponse>(result);
        }


        public async Task<Guid> AddAttachment(AttachmentRequest request)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.AddAttachment(AccountId);

            var result = await HttpWrapper.RunPostQueryAsync(url, request, Token);

            var attachment = Extensions.Deserialize<AttachmentResponse>(result);

            return attachment.Id;
        }

        public async Task<Attachment> GetAttachment(Guid attachmentId)
        {
            Token = OauthClient.GetAccessToken(Scope);
            var url = BaseUrl + SignatureEnpoints.GetAttachment(AccountId, attachmentId);

            var result = await HttpWrapper.RunGetQueryAsync(url, Token);

            return Extensions.Deserialize<Attachment>(result);
        }

    }
}