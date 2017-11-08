using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
#if IS_NET
using System.Runtime.Caching;
#else
using Microsoft.Extensions.Caching.Memory;
#endif

namespace Idfy.Signature.Client.Oauth
{
    /// <summary>
    /// Client interface to get access token to our API
    /// </summary>
    public interface IOauthClient
    {
        string GetAccessToken(string scope);
    }

    /// <summary>
    /// Client to get access token to our API
    /// </summary>
    public class OauthClient : IOauthClient
    {
        private readonly string _clientId;
        private readonly string _secret;
        private readonly string _oauthTokenUrl;
        private readonly MemoryCache _cache;

        public OauthClient(string clientId, string secret, string oauthTokenUrl)
        {
            _clientId = clientId;
            _secret = secret;
            _oauthTokenUrl = oauthTokenUrl;
#if IS_NET
            _cache = MemoryCache.Default;
#else
            _cache = new MemoryCache(new MemoryCacheOptions()
            {

            });
#endif
        }

        public OauthClient(string clientId, string secret, OauthTokenEndpoint oauthTokenEndpoint)
        {
            _clientId = clientId;
            _secret = secret;
#if IS_NET
            _cache = MemoryCache.Default;
#else
            _cache = new MemoryCache(new MemoryCacheOptions()
            {

            });
#endif
            switch (oauthTokenEndpoint)
            {
                case OauthTokenEndpoint.SignereTest:
                    _oauthTokenUrl = OauthEnpoints.TokenEndpointTest;
                    break;
                case OauthTokenEndpoint.SignereProd:
                    _oauthTokenUrl = OauthEnpoints.TokenEndpointProd;
                    break;
                default:
                    _oauthTokenUrl = OauthEnpoints.TokenEndpointTest;
                    break;
            }
        }

        public string GetAccessToken(string scope)
        {
            var cacheKey = $"token:{_clientId}-{scope}";
#if IS_NET
            if (_cache.Contains(cacheKey))
            {
                var cachedToken = _cache[cacheKey] as SecureString;
                return Extensions.SecureStringToString(cachedToken);
            }
#else
            if (_cache.TryGetValue<SecureString>(cacheKey, out var cachedToken))
            {
                return Extensions.SecureStringToString(cachedToken);
            }
#endif

            var headervalue = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{_clientId}:{_secret}")));

            var pairs = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("scope", scope)
            });

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = headervalue;
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = Extensions.RunSync(() => client.PostAsync(_oauthTokenUrl, pairs));

                if (result.IsSuccessStatusCode)
                {
                    var raw = Extensions.RunSync(() => result.Content.ReadAsStringAsync());
                    var tokenData = raw.Deserialize<AccessToken>();
                    var secureToken = tokenData.access_token.ToSecureString();
#if IS_NET
                    _cache.Add(cacheKey, secureToken,new CacheItemPolicy()
                    {
                        AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(tokenData.expires_in - 1000)
                    });
#else
                    _cache.Set(cacheKey, secureToken, new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(tokenData.expires_in - 1000)
                    });
#endif
                    return tokenData.access_token;
                }
                else
                {
                    throw new Exception($"Error getting access token, status code: {result.StatusCode}");
                }
            }
        }
    }
}