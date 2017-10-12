using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Idfy.Signature.Client
{
    public class HttpWrapper
    {
        public string RunPost<T>(string url, T data, string token)
        {
            using (var client = new HttpClient())
            {
                if (token != null)
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(data.Serialize(), Encoding.UTF8, "application/json");
                var response = Extensions.RunSync(() => client.PostAsync(url, content));
                if (response.IsSuccessStatusCode)
                {
                    return Extensions.RunSync(() => response.Content.ReadAsStringAsync());
                }
                else
                {
                    var errorContent = Extensions.RunSync(() => response.Content.ReadAsStringAsync());
                    throw new ApiResponseException((int)response.StatusCode, response.ReasonPhrase, Extensions.RunSync(() => response.Content.ReadAsStringAsync()));
                }
            }
        }


        public async Task<string> RunPostAsync<T>(string url, T data, string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(data.Serialize(), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new ApiResponseException((int)response.StatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());
                }
            }
        }

        public async Task<string> RunGetQueryAsync(string url, string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new ApiResponseException((int)response.StatusCode, response.ReasonPhrase, Extensions.RunSync(() => response.Content.ReadAsStringAsync()));
                }
            }
        }

        public async Task<string> RunPutAsync<T>(string url, T data, string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(data.Serialize(), Encoding.UTF8, "application/json");
                var response = await client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new ApiResponseException((int)response.StatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());
                }
            }
        }

        public async Task<string> RunDeleteAsync(string url, string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new ApiResponseException((int)response.StatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());
                }
            }
        }


        public async Task<string> RunPatchAsync<T>(string url, T data, string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(data.Serialize(), Encoding.UTF8, "application/json");
                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, url)
                {
                    Content = content
                };

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new ApiResponseException((int)response.StatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());
                }
            }
        }


    }
}