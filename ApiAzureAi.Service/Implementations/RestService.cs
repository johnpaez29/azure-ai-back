using ApiAzureAi.Service.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace ApiAzureAi.Service.Implementations
{
    public class RestService(HttpClient _httpClient, IOptions<JsonSerializerOptions> jsonOptions) : IRestService
    {

        private readonly JsonSerializerOptions _jsonOptions = jsonOptions.Value;
        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data, IDictionary<string, string>? headers = null)
        {
            if (headers?.Any() ?? false)
            {
                foreach (var header in headers)
                {
                    _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            var response = await _httpClient.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions);
        }
    }
}
