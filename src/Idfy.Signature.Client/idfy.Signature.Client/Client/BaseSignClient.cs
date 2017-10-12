using System;
using Idfy.Signature.Client.Oauth;
using Idfy.Signature.Models;

namespace Idfy.Signature.Client.Client
{
    public class BaseSignClient
    {
        protected readonly Guid AccountId;
        private readonly string _oauthClientId;
        private readonly string _oauthSecret;
        protected readonly string Scope;
        protected readonly HttpWrapper HttpWrapper;
        protected IOauthClient OauthClient;
        protected string Token;
        protected string BaseUrl { get; set; }

        protected string TokenEnpoint
        {
            set { OauthClient = new OauthClient(_oauthClientId, _oauthSecret, value); }
        }

        public BaseSignClient(Guid accountId, string oauthClientId, string oauthSecret, string scope = OauthScopes.Root, bool isProd = false)
        {
            if (accountId.Equals(Guid.Empty))
                throw new ArgumentNullException(nameof(accountId));
            if (string.IsNullOrEmpty(oauthClientId))
                throw new ArgumentNullException(nameof(oauthClientId));
            if (string.IsNullOrEmpty(oauthSecret))
                throw new ArgumentNullException(nameof(oauthSecret));

            AccountId = accountId;
            _oauthClientId = oauthClientId;
            _oauthSecret = oauthSecret;
            Scope = scope;
            HttpWrapper = new HttpWrapper();
            TokenEnpoint = isProd ? OauthEnpoints.TokenEndpointProd : OauthEnpoints.TokenEndpointTest;
            BaseUrl = isProd ? SignatureEnpoints.BaseUrlProd : SignatureEnpoints.BaseUrlTest;

            if (!BaseUrl.EndsWith("/"))
                BaseUrl += "/";
        }

    }
}
